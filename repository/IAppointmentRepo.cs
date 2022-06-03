using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.repository
{
	interface IAppointmentRepo
	{
		void Add(Appointment appointment);
		void Edit(Appointment appointment);
		void Delete(string id);
		List<Appointment> LoadAllAppointments();
		List<Appointment> LoadAppointmentsForDoctor(string id);
		List<Appointment> LoadAppointmentsForDate(string date);
		string GetPatientIdFromAppointment(string appointmentId);
		Appointment LoadOneAppointment(string id);
	}
}
