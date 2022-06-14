using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.Core.Equipment.Service;
using System.Data;
using System.Globalization;

namespace HealthCareInfromationSystem.Core.Equipment.Repository
{
	class EquipmentSQL : IEquipmentRepo
	{
		public List<Equipment> GetEquipmentFromPremise(string premiseId)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select name, quantity, equipment_id from equipment where new_premises_id=\"" + premiseId + "\"", connection);

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

		public void EditQuantity(string id, int newQuantity)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update equipment set quantity=\"{newQuantity}\" where equipment_id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public Equipment GetByNameFromPremise(string name, string premiseId)
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

        public DataTable LoadAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"" +
                    $"select eq.equipment_id, eq.name, eq.quantity, eq.type, pr1.name as old_premise, pr2.name as new_premise, eq.move_date as move_date " +
                    $"from equipment as eq, premises as pr1, premises as pr2 " +
                    $"where eq.old_premises_id=pr1.premises_id and eq.new_premises_id=pr2.premises_id";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                return table;
            }
        }

        public DataTable SearchByTerm(string term)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"" +
                    $"select eq.equipment_id, eq.name, eq.quantity, eq.type, pr1.name as old_premise, pr2.name as new_premise, eq.move_date as move_date " +
                    $"from equipment as eq, premises as pr1, premises as pr2 " +
                    $"where eq.old_premises_id=pr1.premises_id and eq.new_premises_id=pr2.premises_id and " +
                    $"(" +
                    $"eq.equipment_id like \"%{term}%\" or " +
                    $"eq.name like \"%{term}%\" or " +
                    $"eq.quantity like \"%{term}%\" or " +
                    $"eq.type like \"%{term}%\" or " +
                    $"eq.move_date like \"%{term}%\" or " +
                    $"pr1.name like \"%{term}%\" or " +
                    $"pr2.name like \"%{term}%\"" +
                    $")";

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                return table;
            }
        }

        public DataTable SearchByCriteria(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                return table;
            }
        }

        public void Transfer(string id, string newPremiseId, string date)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update equipment set new_premises_id=\"{newPremiseId}\", move_date=\"{date}\" where equipment_id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Equipment> GetDynamicEquipment()
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
        
        public List<Equipment> GetDynamicEquipmentOutOfStock()
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

        public List<Equipment> GetEquipmentLowOnStock(string equipmentName)
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

        public List<Equipment> GetEquipmentWithSufficentStock(string equipmentName)
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

        public List<string> GetDistinctEquipmentNames()
        {
            List<string> names = new List<string>();
            foreach (Equipment equipment in GetDynamicEquipment())
            {
                if (!names.Contains(equipment.Name)) names.Add(equipment.Name);
            }
            return names;
        }

    }
}
