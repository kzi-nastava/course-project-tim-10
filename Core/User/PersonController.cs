using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.Data.OleDb;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.Core.User
{
	class PersonController
	{
        
        public static Person SearchPerson(string id)
        {
            return LoadOnePerson(Constants.connectionString,
                            "select * from users where id=\"" + id + "\"");
        }

        //dodato
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
