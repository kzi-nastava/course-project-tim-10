using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.Data.OleDb;
using HealthCareInfromationSystem.models.users;

namespace HealthCareInfromationSystem.contollers
{
	class PersonController
	{
        /*
	    * Retrieves a specific person from dataset

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    Person or null if the person is not found.
	    * */
        public static Person LoadOnePerson(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Person person = null;

                while (reader.Read())
                {
                    person = Person.Parse(reader);

                }
                reader.Close();
                return person;
            }
        }
    }
}
