using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository
{
	interface IReferralLetterRepo
	{
		void Add(string patientId, string specialisation, string doctorId);
	}
}
