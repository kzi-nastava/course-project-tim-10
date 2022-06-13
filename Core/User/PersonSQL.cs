using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.Core.User
{
	class PersonSQL : IPersonRepo
	{
		public Dictionary<string, string> LoadFullNameAndId(string role)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select id, name, last_name from users where role = \"" + role + "\" ", connection);

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

		public Person LoadOnePerson(string id)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select * from users where id=\"" + id + "\"", connection);

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
