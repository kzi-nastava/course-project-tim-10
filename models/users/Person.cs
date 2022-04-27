using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.models.users
{
	public enum Role
	{
		manager,
		patient,
		doctor,
		secretary
	}
	public class Person
	{
		private int id;
		string name;
		string lastName;
		Role role;
		string username;
		string password;
		bool blocked;
		int blocker;

		public Person() { }

		public Person(int id, string name, string lastName, Role role,
					  string password, bool blocked, int blocker, string username)
		{
			this.id = id;
			this.blocked = blocked;
			this.name = name;
			this.lastName = lastName;
			this.role = role;
			this.password = password;
			this.blocker = blocker;
			this.username = username;

		}

		

		public Person DeepCopy()
		{
			return new Person(id, name, lastName, role,
						  password, blocked, blocker, username);
		}


		public static Person Parse(OleDbDataReader reader)
		{
			int id = int.Parse(reader[0].ToString());
			string name = reader[1].ToString();
			string lastName = reader[2].ToString();
			Enum.TryParse(reader[3].ToString(), out Role role);
			string username = reader[4].ToString();
			string password = reader[5].ToString();
			bool blocked = Convert.ToBoolean(reader[6].ToString());
			int blocker = int.Parse(reader[7].ToString());
			return new Person(id, name, lastName, role,
			  password, blocked, blocker, username);
		}
	}
}

