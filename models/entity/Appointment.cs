using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.users;

namespace HealthCareInfromationSystem.models.entity
{
	public enum AppointmentType
	{
		physical,
		operation
	}
	public class Appointment
	{
		int id;
		Person doctor;
		Person patient;
		Premise premise;
		DateTime beginning;
		int duration;
		AppointmentType operation;
		string comment;

		public Appointment()
		{
		}

		public Appointment(int id, Person doctor, Person patient, Premise premise,
			DateTime beginning, int duration, AppointmentType operation, string comment)
		{
			this.id = id;
			this.doctor = doctor;
			this.patient = patient;
			this.premise = premise;
			this.beginning = beginning;
			this.duration = duration;
			this.operation = operation;
			this.comment = comment;
		}
	}
}
