using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository
{
	interface IAppointmentRequestRepo
	{
		void DeleteByPatientId(string id);
		AppointmentRequest LoadOneRequest(string id);
	}
}
