using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.repository
{
	class MedicineSQL : IMedicineRepo
	{
		public void Edit(Medicine medicine)
		{
			String ingredients = String.Join(", ", medicine.Ingredients).Trim();
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				String query = $"update medicine set name=\"{medicine.Name}\", description=\"{medicine.Description}\", ingredients=\"{ingredients}\", status=\"{medicine.Status}\", comment=\"{medicine.Comment}\" where id=\"{medicine.Id}\"";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();
			}
		}

		public List<Medicine> LoadAll()
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{

				OleDbCommand command = new OleDbCommand("select * from medicine where status = \"in progress\" ", connection);

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

		public Dictionary<string, string> LoadNameAndId()
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{

				OleDbCommand command = new OleDbCommand("select id, name from medicine where status = \"accepted\" ", connection);

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

		public Medicine LoadOneById(string medicineId)
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
