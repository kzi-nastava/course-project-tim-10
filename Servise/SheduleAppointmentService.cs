using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.Servise
{
	class SheduleAppointmentService
	{

		IAppointmentRepo appointmentRepo = new AppointmentSQL();
		IMedicalRecordRepo medicalRecordRepo = new MedicalRecordSQL();

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
