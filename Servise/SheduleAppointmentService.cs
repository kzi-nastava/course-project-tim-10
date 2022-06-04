using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.models.entity;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.Servise
{
	class SheduleAppointmentService
	{

		IAppointmentRepo appointmentRepo = new AppointmentSQL();

		public bool IsAppointmentAvailable(Appointment appointment)
		{
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

			if (!IsPatientAvailable(appointment))
			{
				MessageBox.Show("Patient has an appointment.", "Error");
				return false;
			}

			return true;
		}
		public bool IsDoctorAvailable(Appointment appointment)
		{
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

		private bool TimeOverlapses(Appointment appointment, Appointment oldAppointment)
		{
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
