using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
    class SpecialisationController
    {
        // Returns list of ids from doctors who have specialisation with given name
        public static List<string> GetDoctorIds(string connectionString, string specName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"select doctorId from specialisations where name=\"{specName}\"";

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<string> doctorIds = new List<string>();

                while (reader.Read())
                {
                    doctorIds.Add(reader[0].ToString());
                }
                reader.Close();
                return doctorIds;

            }
        }
    }
}
