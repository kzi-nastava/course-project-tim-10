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
	class MedicineController
	{
        public static List<Medicine> LoadAll(string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Medicine> medicines = new List<Medicine>();

                while (reader.Read())
                {
                    Medicine medicine = Medicine.Parse(reader);
                    medicines.Add(medicine);
                }
                reader.Close();
                return medicines;
            }
        }

		internal static Dictionary<string, string> LoadPair(string queryString)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Dictionary<string, string> medicine = new Dictionary<string, string>();

                while (reader.Read())
                {
                    medicine.Add(reader[0].ToString(), reader[1].ToString());

                }
                reader.Close();
                return medicine;
            }
        }

		internal static Medicine LoadOneById(string medicineId)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select * from medicine where id=\"" + medicineId + "\"", connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Medicine medicine = null;

				while (reader.Read())
                {
                    medicine = Medicine.Parse(reader);
                }
				reader.Close();
                return medicine;
            }
        }

        public void Save(Medicine medicine)
        {
            String ingredients = String.Join(", ", medicine.Ingredients).Trim();
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into medicine values (\"{medicine.Id}\", \"{medicine.Name}\", \"{medicine.Description}\", \"{ingredients}\", \"{medicine.Status}\", \"{medicine.Comment}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
	}
}
