using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.Core.MedicalRecord
{
	class MedicalRecordSQL : IMedicalRecordRepo
	{
		public void AddNewByPatientId(string id)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				string query = $"insert into medical_record (id, patientId) values (\"{id}\", \"{id}\")";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();

			}
		}

		public void DeleteByPatientId(string id)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				string query = $"delete from medical_record where patientId=\"{id}\"";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();

			}
		}

		public void Edit(MedicalRecord medicalRecord)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				String query = $"update medical_record set height=\"{medicalRecord.Height}\", weight=\"{medicalRecord.Weight}\", " +
					$"bloodType=\"{medicalRecord.BloodType}\", disease=\"{medicalRecord.Disease}\", alergies=\"{medicalRecord.Alergies}\" where id=\"{medicalRecord.Id}\"";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();
			}
		}

		public MedicalRecord GetMedicalRecordByPatient(string patientId)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{

				OleDbCommand command = new OleDbCommand("select * from medical_record where patientId=\"" + patientId + "\"", connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();


				while (reader.Read())
				{
					return MedicalRecord.Parse(reader);
				}
				reader.Close();
				return null;
			}
		}
	}
}
