using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.models.users
{
	class Doctor : Person
	{
		private string _specialisation;

		public String Specialisation
		{
			get { return _specialisation; }
			set { _specialisation = value; }
		}

		public Doctor() : base() { }
		public Doctor(int id, string name, string lastName,
					  string password, bool blocked, int blocker, string username, string specialisation) : base(id, name, lastName, Roles.doctor,
						  password, blocked, blocker, username)
		{
			this._specialisation = specialisation;
		}
	}
}
