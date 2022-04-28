using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.contollers
{
	class PremiseController
	{
        /*
	    * Retrieves a specific premise from dataset

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    Premise or null if the premise is not found.
	    * */
        public static Premise LoadOnePremise(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Premise premise = null;

                while (reader.Read())
                {
                    premise = Premise.Parse(reader);

                }
                reader.Close();
                return premise;
            }
        }

        /*
	    * Creates dictionary used for filling in a combobox

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    Dictionary where key = premise id(firs value in query) and value = premise name(second value in query).
	    * */
        public static Dictionary<string, string> RetrievePair(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Dictionary<string, string> premise = new Dictionary<string, string>();

                while (reader.Read())
                {
                    premise.Add(reader[0].ToString(), reader[1].ToString());

                }
                reader.Close();
                return premise;
            }
        }
    }
}
