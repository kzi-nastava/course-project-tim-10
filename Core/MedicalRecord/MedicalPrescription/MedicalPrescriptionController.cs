 
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.MedicalRecord.MedicalPrescription
{
	class MedicalPrescriptionController
	{
        
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
