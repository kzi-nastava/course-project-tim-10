using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User
{
	interface IPersonRepo
	{
		Person LoadOnePerson(string id);

		Dictionary<string, string> LoadFullNameAndId(string role);
	}
}
