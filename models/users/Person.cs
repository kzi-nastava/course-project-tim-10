using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.models.users
{



	
	public class Person
	{
		public enum Roles
		{
			patient,
			doctor,
			secretary,
			manager
		}

		private int _id;
		private String _firstname;
		private String _lastname;
		private Roles _role;
		private String _username;
		private String _password;
		private bool _blocked;
		private int _blocker;


		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}


		public String FirstName
		{
			get { return _firstname; }
			set { _firstname = value; }
		}


		public String LastName
		{
			get { return _lastname; }
			set { _lastname = value; }
		}


		public Roles Role
		{
			get { return _role; }
			set { _role = value; }
		}


		public String Username
		{
			get { return _username; }
			set { _username = value; }
		}


		public String Password
		{
			get { return _password; }
			set { _password = value; }
		}


		public bool Blocked
		{
			get { return _blocked; }
			set { _blocked = value; }
		}


		public int Blocker
		{
			get { return _blocker; }
			set { _blocker = value; }
		}
		//private int id;
		//string name;
		//string lastName;
		//Role role;
		//string username;
		//string password;
		//bool blocked;
		//int blocker;

		public Person() { }

		public Person(int id, string name, string lastName, Roles role, 
			          string password, bool blocked, int blocker, string username) {
			this._id = id;
			this._blocked = blocked;
			this._firstname = name;
			this._lastname = lastName;
			this._role = role;
			this._password = password;
			this._blocker = blocker;
			this._username = username;
		
		}


		public Person DeepCopy()
		{
			return new Person(_id, _firstname, _lastname, _role,
						  _password, _blocked, _blocker, _username);
		}

		

		public static Person Parse(OleDbDataReader reader)
		{
			int id = int.Parse(reader[0].ToString());
			string name = reader[1].ToString();
			string lastName = reader[2].ToString();
			Enum.TryParse(reader[3].ToString(), out Roles role);
			string username = reader[4].ToString();
			string password = reader[5].ToString();
			bool blocked = Convert.ToBoolean(reader[6].ToString());
			int blocker = int.Parse(reader[7].ToString());
			return new Person(id, name, lastName, role,
			  password, blocked, blocker, username);
		}

		
	}

}


