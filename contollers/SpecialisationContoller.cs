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
	class SpecialisationContoller
	{
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
