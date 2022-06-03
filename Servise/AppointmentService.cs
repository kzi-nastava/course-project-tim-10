using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.repository;


namespace HealthCareInfromationSystem.Servise
{
	class AppointmentService
	{
		IAppointmentRepo appointmentRepo = new AppointmentSQL();
		IPersonRepo personRepo = new PersonSQL();
		IPremisseRepo premisseRepo = new PremisseSQL();

		public void SaveToBase(Appointment appointment) {
			appointmentRepo.Add(appointment);
		}

		public void EditInBase(Appointment appointment) {
			appointmentRepo.Edit(appointment);
		}

		public void DeleteInBase(string id) {
			appointmentRepo.Delete(id);
		}
		public Appointment GetAppointmentById(string id) {
			return appointmentRepo.LoadOneAppointment(id);
		}
		public List<Appointment> LoadAppointmentsForDoctor(string id) {
			return appointmentRepo.LoadAppointmentsForDoctor(id);
		}
		
		public Person GetPersonById(string id) {
			return personRepo.LoadOnePerson(id);
		}
		public Premise GetPremisseById(string id) {
			return premisseRepo.GetPremiseById(id);
		}
		public Dictionary<string, string> LoadFullNameAndId(string role) {
			return personRepo.LoadFullNameAndId(role);
		}

		public Dictionary<string, string> LoadPremiseNameAndId()
		{
			return premisseRepo.LoadNameAndId();
		}

		public bool IsAppointmentAvailable(Appointment appointment) {
			if (!IsDoctorAvailable(appointment))
			{
				MessageBox.Show("Doctor has an appointment.", "Error");
				return false;
			}

			if (!IsPremiseAvailable(appointment))
			{
				MessageBox.Show("Premise occupied.", "Error");
				return false;
			}

			//checking if the patient is available
			if (!IsPatientAvailable(appointment))
			{
				MessageBox.Show("Patient has an appointment.", "Error");
				return false;
			}

			return true;
		}
		public bool IsDoctorAvailable(Appointment appointment) {
			List<Appointment> allAppointments = appointmentRepo.LoadAllAppointments();
			foreach (Appointment oldAppointment in allAppointments)
			{
				if (appointment.Doctor.Id == oldAppointment.Doctor.Id && appointment.Id != oldAppointment.Id)
				{

					if (TimeOverlapses(appointment, oldAppointment)) return false;
				}
			}
			return true;
		}

		public bool IsPremiseAvailable(Appointment appointment)
		{
			List<Appointment> allAppointments = appointmentRepo.LoadAllAppointments();
			foreach (Appointment oldAppointment in allAppointments)
			{
				if (appointment.Premise.Id == oldAppointment.Premise.Id && appointment.Id != oldAppointment.Id)
				{

					if (TimeOverlapses(appointment, oldAppointment)) return false;
				}
			}
			return true;
		}

		public bool IsPatientAvailable(Appointment appointment)
		{
			List<Appointment> allAppointments = appointmentRepo.LoadAllAppointments();
			foreach (Appointment oldAppointment in allAppointments)
			{
				if (appointment.Patient.Id == oldAppointment.Patient.Id && appointment.Id != oldAppointment.Id)
				{

					if (TimeOverlapses(appointment, oldAppointment)) return false;
				}
			}
			return true;
		}

		private bool TimeOverlapses(Appointment appointment, Appointment oldAppointment) {
			DateTime endingNew = appointment.Beginning.AddMinutes(appointment.Duration);
			DateTime endingOld = oldAppointment.Beginning.AddMinutes(oldAppointment.Duration);
			if ((oldAppointment.Beginning <= appointment.Beginning && appointment.Beginning <= endingOld)
				|| (oldAppointment.Beginning <= endingNew && endingNew <= endingOld)
				|| (appointment.Beginning <= oldAppointment.Beginning && endingNew >= endingOld))
			{
				return true;
			}
			return false;
		}
	}
}
