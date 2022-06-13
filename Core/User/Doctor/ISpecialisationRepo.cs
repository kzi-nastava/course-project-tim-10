using HealthCareInfromationSystem.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.User.Doctor
{
	interface ISpecialisationRepo
	{
		List<string> LoadSpecialisations();
		List<string> GetDoctorIds(string specName);
		List<Person> GetDoctors(string specialisationName);
	}
}
