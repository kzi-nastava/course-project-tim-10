using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository
{
	interface IReferealLeterRepo
	{
		void Add(string patientId, string specialisation, string doctorId);
	}
}
