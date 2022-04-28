using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
    class MedicalRecordController
    {

        public static void AddNew(string patientId)
        {
            InsertMedicalRecord(patientId);
        }

        private static void InsertMedicalRecord(string patientId)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into medical_record (id, patientId) values (\"{patientId}\", \"{patientId}\")";
                Console.WriteLine(query);
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

    }
}
