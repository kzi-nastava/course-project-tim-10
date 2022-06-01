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
        
        public static void Save(MedicalPrescription medicalPrescription)
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

        public static List<MedicalPrescription> Load(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                List<MedicalPrescription> prescriptions = new List<MedicalPrescription>();
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    prescriptions.Add(MedicalPrescription.Parse(reader));

                reader.Close();
                connection.Close();

                return prescriptions;
            }
        }
            
        
    }
}
