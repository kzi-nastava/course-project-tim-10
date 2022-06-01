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

    }
}
