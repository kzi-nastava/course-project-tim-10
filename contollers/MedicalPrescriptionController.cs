using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
	class MedicalPrescriptionController
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
        public static void SaveToBase(MedicalPrescription medicalPrescription)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
				String query = $"insert into medical_prescription values (\"{GetFirstFreeId()}\", \"{medicalPrescription.Medicine.Id}\", " +
                                                                         $"\"{medicalPrescription.Quantity}\", \"{medicalPrescription.TimeOfConsumption}\", " +
                                                                         $"\"{medicalPrescription.Patient.Id}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
