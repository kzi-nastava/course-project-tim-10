using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.models.users
{
	class Patient : Person
	{
		MedicalRecord medicalRecord;

		public Patient() : base() { }
		public Patient(int id, string name, string lastName, Role role,
					  string password, bool blocked, int blocker, string username) : base(id, name, lastName, role,
						  password, blocked, blocker, username)
		{ }
	}
}
