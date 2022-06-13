using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.AppointmentRequest
{
	interface IAppointmentRequestRepo
	{
		AppointmentRequest Get(string id);
		void SetState(AppointmentRequest request, string state);
		List<AppointmentRequest> GetRequests();
		void DeleteByPatientId(string id);
		void Add(AppointmentRequest request);
	}
}
