using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.contollers
{
    class EquipmentController
    {
        public static List<Equipment> LoadEquipments(string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Equipment> equipments = new List<Equipment>();

                while (reader.Read())
                {
                    Equipment equipment = Equipment.Parse(reader);
                    equipments.Add(equipment);
                }
                reader.Close();
                return equipments;
            }
        }

        internal static void Save(string id, int newQuantity)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update equipment set quantity=\"{newQuantity}\" where equipment_id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private static Equipment GetByNameAndPremise(string name, string premiseId)
        {
            Equipment equipment = null;
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"select name, quantity, equipment_id, new_premises_id from equipment where new_premises_id=\"{premiseId}\" and name=\"{name}\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    equipment = Equipment.ParseWithPremise(reader);
                }
                reader.Close();
                return equipment;
            }
        }

        public static List<Equipment> GetDynamicEquipment()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = "select name, quantity, equipment_id, new_premises_id from equipment " +
                    "where type=\"examination equipment\" or type=\"equipment for operations\" or type=\"office supplies\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Equipment> equipment = new List<Equipment>();

                while (reader.Read())
                {
                    Equipment e = Equipment.ParseWithPremise(reader);
                    equipment.Add(e);
                }
                reader.Close();
                return equipment;
            }
        }

        public static List<Equipment> GetDynamicEquipmentOutOfStock()
        {
            List<Equipment> outOfStock = new List<Equipment>();
            foreach (Equipment equipment in GetDynamicEquipment())
            {
                if (equipment.Premise.Type == "warehouse" && equipment.Quantity == 0)
                {
                    outOfStock.Add(equipment);
                }
            }
            return outOfStock;
        }

        public static void SupplyFromReadyRequests()
        {
            foreach (EquipmentRequest request in DynamicEquipmentRequestController.GetRequestsReadyToSupply())
            {
                Save(request.EquipmentId.ToString(), request.Quantity); // supplies the requested quantity
                DynamicEquipmentRequestController.SetSuppliedStatus(request);
            }
        }

        public static List<string> GetDistinctEquipmentNames()
        {
            List<string> names = new List<string>();
            foreach (Equipment equipment in GetDynamicEquipment())
            {
                if (!names.Contains(equipment.Name)) names.Add(equipment.Name);
            }
            return names;
        }

        public static List<Equipment> GetEquipmentLowOnStock(string equipmentName)
        {
            List<Equipment> lowOnStock = new List<Equipment>();
            foreach (Equipment equipment in GetDynamicEquipment())
            {
                if (equipment.Name == equipmentName && equipment.Quantity < 5)
                {
                    lowOnStock.Add(equipment);
                }
            }
            return lowOnStock;
        }

        public static List<Equipment> GetEquipmentWithSufficentStock(string equipmentName)
        {
            List<Equipment> sufficentlyStocked = new List<Equipment>();
            foreach (Equipment equipment in GetDynamicEquipment())
            {
                if (equipment.Name == equipmentName && equipment.Quantity >= 5)
                {
                    sufficentlyStocked.Add(equipment);
                }
            }
            return sufficentlyStocked;
        }

        public static List<List<string>> GetRowsForEquipmentLowOnStock(string equipmentName)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (Equipment equipment in GetEquipmentLowOnStock(equipmentName))
            {
                rows.Add(GetTableRow(equipment));
                
            }
            return rows;
        }

        public static List<List<string>> GetRowsForEquipmentWithSufficentStock(string equipmentName)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (Equipment equipment in GetEquipmentWithSufficentStock(equipmentName))
            {
                rows.Add(GetTableRow(equipment));

            }
            return rows;
        }

        private static List<string> GetTableRow(Equipment equipment)
        {
            List<string> row = new List<string>();
            if (equipment.Quantity == 0) row.Add("Out Of Stock!");
            else row.Add("");
            row.Add(equipment.Id.ToString());
            row.Add(equipment.Premise.Id.ToString());
            row.Add(equipment.Premise.Name);
            row.Add(equipment.Quantity.ToString());
            return row;
        }

        public static void Move(string equipmentName, string oldPremiseId, string newPremiseId, int quantity)
        {
            Equipment fromOldPremise = GetByNameAndPremise(equipmentName, oldPremiseId);
            Equipment fromNewPremise = GetByNameAndPremise(equipmentName, newPremiseId);
            Save(fromOldPremise.Id.ToString(), fromOldPremise.Quantity - quantity);
            Save(fromNewPremise.Id.ToString(), fromNewPremise.Quantity + quantity);
        }

    }
}
