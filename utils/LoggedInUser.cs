using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.users;

namespace HealthCareInfromationSystem.utils
{
	public static class LoggedInUser
	{
		public static Person loggedIn;

		public static string GetId()
		{
			return loggedIn.Id.ToString();
	}
	}


}
