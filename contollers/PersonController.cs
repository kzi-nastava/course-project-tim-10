using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.Data.OleDb;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;

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

        public static Person SearchPerson(string id)
        {
            return LoadOnePerson(Constants.connectionString,
                            "select * from users where id=\"" + id + "\"");
        }

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

        /*
	    * Creates dictionary used for filling in a combobox

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    Dictionary where key = user id(firs value in query) and value = userd full name name(second value in query).
	    * */
        public static Dictionary<string, string> LoadPair(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Dictionary<string, string> personPair = new Dictionary<string, string>();

                while (reader.Read())
                {
                    personPair.Add(reader[0].ToString(), reader[1].ToString() + " " + reader[2].ToString());

                }
                reader.Close();
                return personPair;
            }
        }
    }
}
