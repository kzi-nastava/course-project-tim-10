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
        //dodato
        // Returns list of ids from doctors who have specialisation with given name
        public static List<string> GetDoctorIds(string connectionString, string specName)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"select doctors from specialisations where name=\"{specName}\"";

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
        //dodato
        public static List<string> LoadSpecialisations(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<string> specialisations = new List<string>();

                while (reader.Read())
                {
                    specialisations.Add(reader[0].ToString());
                }
                reader.Close();
                return specialisations;
            }
        }
    }
}
