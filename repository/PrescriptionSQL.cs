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
	class PrescriptionSQL : IPrescriptionRepo
	{
        private static int GetFirstFreeId()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                OleDbCommand command = new OleDbCommand("select * from medical_prescription", connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                int maxId = 0;

                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    if (id > maxId) { maxId = id; }
                }
                reader.Close();
                return maxId + 1;
            }
        }
        public void Add(MedicalPrescription medicalPrescription)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string beginning = medicalPrescription.Beginning.ToString("dd.MM.yyyy.");
                string ending = medicalPrescription.Ending.ToString("dd.MM.yyyy.");
                string takingTime = medicalPrescription.TimeTaking.ToString("HH:mm");

                String query = $"insert into medical_prescription values (\"{GetFirstFreeId()}\", \"{medicalPrescription.Medicine.Id}\", " +
                                                                         $"\"{medicalPrescription.Quantity}\", \"{medicalPrescription.TimeOfConsumption}\", " +
                                                                         $"\"{medicalPrescription.Patient.Id}\", \"{beginning}\", \"{ending}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
	}
}
