using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.Core.MedicalRecord;

namespace HealthCareInfromationSystem.Servise
{
	class AppointmentService
	{
		IAppointmentRepo appointmentRepo = new AppointmentSQL();
		IPersonRepo personRepo = new PersonSQL();
		IPremisseRepo premisseRepo = new PremisseSQL();
		IMedicalRecordRepo medicalRecordRepo = new MedicalRecordSQL();

		public void Add(Appointment appointment) {
			appointmentRepo.Add(appointment);
		}

		public void Edit(Appointment appointment) {
			appointmentRepo.Edit(appointment);
		}

		public void Delete(string id) {
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
		public Premise GetPremiseById(string id) {
			return premisseRepo.GetPremiseById(id);
		}
		public Dictionary<string, string> LoadFullNameAndId(string role) {
			return personRepo.LoadFullNameAndId(role);
		}

		public Dictionary<string, string> LoadPremiseNameAndId()
		{
			return premisseRepo.LoadNameAndId();
		}

		public MedicalRecord GetMedicalRecordByPatient(string patientId)
		{
			return medicalRecordRepo.GetMedicalRecordByPatient(patientId);
		}
		public List<Appointment> LoadAppointmentsForDoctorAtDate(string date)
		{
			return appointmentRepo.LoadAppointmentsForDate(date);
		}

		
	}
}
