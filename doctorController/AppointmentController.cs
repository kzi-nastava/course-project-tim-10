using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.doctorController
{
	class AppointmentController
	{
		AppointmentService appointmentService = new AppointmentService();
		SheduleAppointmentService sheduleAppointmentService = new SheduleAppointmentService();

		public void Add(Appointment appointment)
		{
			appointmentService.Add(appointment);
		}

		public void Edit(Appointment appointment)
		{
			appointmentService.Edit(appointment);
		}

		public void Delete(string id)
		{
			appointmentService.Delete(id);
		}
		public Appointment GetAppointmentById(string id)
		{
			return appointmentService.GetAppointmentById(id);
		}
		public List<Appointment> LoadAppointmentsForDoctor(string id)
		{
			return appointmentService.LoadAppointmentsForDoctor(id);
		}

		public Person GetPersonById(string id)
		{
			return appointmentService.GetPersonById(id);
		}
		public Premise GetPremiseById(string id)
		{
			return appointmentService.GetPremiseById(id);
		}
		public Dictionary<string, string> LoadFullNameAndId(string role)
		{
			return appointmentService.LoadFullNameAndId(role);
		}

		public Dictionary<string, string> LoadPremiseNameAndId()
		{
			return appointmentService.LoadPremiseNameAndId();
		}

		public MedicalRecord GetMedicalRecordByPatient(string patientId)
		{
			return appointmentService.GetMedicalRecordByPatient(patientId);
		}
		public List<Appointment> LoadAppointmentsForDoctorAtDate(string date)
		{
			return appointmentService.LoadAppointmentsForDoctorAtDate(date);
		}

		public bool IsAppointmentAvailable(Appointment appointment) {
			return sheduleAppointmentService.IsAppointmentAvailable(appointment);
		}
	}
}
