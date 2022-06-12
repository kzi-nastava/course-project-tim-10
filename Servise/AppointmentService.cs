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
		ISpecialisationRepo specialisationRepo = new SpecialisationSQL();
		SheduleAppointmentService scheduleService = new SheduleAppointmentService();

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

		// Finds doctor and time
		public bool BookEmergency(Appointment appointment, string specialisation)
        {
			List<Person> specializedDoctors = specialisationRepo.GetDoctors(specialisation);

			DateTime bookingStartTime = DateTime.Now.AddMinutes(5);
			DateTime beginningMinimum = bookingStartTime.AddMinutes(115); // Initialized to maximum value for comparing in sort
			Person selectedDoctor = null;

			// Checking availability in the next 2 hours for every doctor and finding the earliest 
			foreach (Person doctor in specializedDoctors)
			{
				DateTime beginning = bookingStartTime;
				appointment.Doctor = doctor;
				while (beginning <= bookingStartTime.AddMinutes(120) && beginning < beginningMinimum)
				{
					appointment.Beginning = beginning;
					if (scheduleService.IsDoctorAvailable(appointment) && scheduleService.IsPatientAvailable(appointment) && scheduleService.IsPremiseAvailable(appointment))
					{
						selectedDoctor = doctor;
						beginningMinimum = beginning;
						break; // Found earliest available time for current doctor, move on to next doctor
					}
					beginning = beginning.AddMinutes(5);
				}
			}

			if (selectedDoctor != null)
			{
				appointment.Beginning = beginningMinimum;
				return true;
			}

			return false;
		}

		public Dictionary<Appointment, DateTime> GetPotentialRescheduleTimes(string specialisationName)
		{
			Dictionary<Appointment, DateTime> earliestRescheduleTimes = new Dictionary<Appointment, DateTime>();
			List<Person> specializedDoctors = specialisationRepo.GetDoctors(specialisationName);

			// Get doctor's future appointments in the next two hours in ascending order
			DateTime timestampNow = DateTime.Now;
			DateTime timestampTwoHoursFromNow = DateTime.Now.AddMinutes(120);
			List<Appointment> appointments = appointmentRepo.LoadAllAppointments();

			// Finding the earliest reschedule time for every appointment for specialized doctors, in the next two hours
			foreach (Appointment appointment in appointments)
			{
				if (appointment.Beginning > timestampNow && appointment.Beginning < timestampTwoHoursFromNow 
					&& specializedDoctors.Any(item=>item.Id == appointment.Doctor.Id))
				{
					earliestRescheduleTimes[appointment] = GetEarliestRescheduleTime(appointment);
				}
			}

			return earliestRescheduleTimes;
		}

		private DateTime GetEarliestRescheduleTime(Appointment appointment)
		{
			// Rescheduled beginning time will be as early as the original appointment's ending
			DateTime originalBeginning = appointment.Beginning;
			DateTime beginning = appointment.Beginning.AddMinutes(appointment.Duration);

			while (true)
			{
				appointment.Beginning = beginning;
				if (scheduleService.IsDoctorAvailable(appointment) && scheduleService.IsPatientAvailable(appointment) && scheduleService.IsPremiseAvailable(appointment))
				{
					appointment.Beginning = originalBeginning;
					return beginning; // The first time found is earliest available time 
				}
				beginning = beginning.AddMinutes(5);
			}

		}
	}
}
