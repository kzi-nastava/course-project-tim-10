using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.repository
{
	class AppointmentSQL : IAppointmentRepo
	{
		public void Add(Appointment appointment)
		{
			int id = GetFirstFreeId();
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				string date = appointment.Beginning.ToString();
				string query = $"insert into appointments values (\"{id}\", \"{appointment.Doctor.Id}\", \"{appointment.Patient.Id}\"," +
					$" \"{appointment.Premise.Id}\", \"{date.Substring(0, date.Length - 3)}\", \"{appointment.Duration}\", \"{appointment.Type}\", \"\")";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();
			}
		}

		private int GetFirstFreeId()
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{

				OleDbCommand command = new OleDbCommand("select * from appointments", connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();
				int maxId = 0;

				while (reader.Read())
				{
					int id = int.Parse(reader[0].ToString());
					if (id > maxId) { maxId = id; }
				}
				reader.Close();
				return maxId + 1;
			}
		}

		public void Delete(string id)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				string query = $"delete from appointments where id = \"{id}\"";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();
			}
		}

		public void Edit(Appointment appointment)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				string date = appointment.Beginning.ToString("dd.MM.yyyy. HH:mm");
				String query = $"update appointments set doctorId=\"{appointment.Doctor.Id}\", patientId=\"{appointment.Patient.Id}\", " +
					$"premiseId=\"{appointment.Premise.Id}\", beginning=\"{date.Substring(0, date.Length - 3)}\", duration=\"{appointment.Duration}\", type=\"{appointment.Type}\", comment=\"{appointment.Comment}\" where id=\"{appointment.Id}\"";
				OleDbCommand command = new OleDbCommand(query, connection);
				command.ExecuteNonQuery();
			}
		}

		public string GetPatientIdFromAppointment(string appointmentId)
		{
			throw new NotImplementedException();
		}

		public List<Appointment> LoadAllAppointments()
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				OleDbCommand command = new OleDbCommand("select * from appointments", connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();
				List<Appointment> appointments = new List<Appointment>();

				while (reader.Read())
				{
					Appointment appointment = Appointment.Parse(reader);
					appointments.Add(appointment);
				}
				reader.Close();
				return appointments;
			}
		}

		public List<Appointment> LoadAppointmentsForDate(string date)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{

				OleDbCommand command = new OleDbCommand("select * from appointments where doctorId=\"" + LoggedInUser.loggedIn.Id + "\"", connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();
				List<Appointment> appointments = new List<Appointment>();
				DateTime beginningDate = DateTime.ParseExact(date, "dd.MM.yyyy.", null);
				DateTime endingDate = beginningDate.AddDays(3);

				while (reader.Read())
				{
					DateTime appoinmentDate = DateTime.ParseExact(reader[4].ToString(), "dd.MM.yyyy. HH:mm", null);
					if (beginningDate <= appoinmentDate && appoinmentDate < endingDate)
					{
						Appointment appointment = Appointment.Parse(reader);
						appointments.Add(appointment);
					}

				}
				reader.Close();
				return appointments;
			}
		}

		public Appointment LoadOneAppointment(string id)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{

				OleDbCommand command = new OleDbCommand("select * from appointments where id=\"" + id + "\"", connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();
				Appointment appointment = null;

				while (reader.Read())
				{
					appointment = Appointment.Parse(reader);
				}
				reader.Close();
				return appointment;
			}
		}

		public List<Appointment> LoadAppointmentsForDoctor(string id)
		{
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				OleDbCommand command = new OleDbCommand("select * from appointments where doctorId=\"" + id + "\"", connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();
				List<Appointment> appointments = new List<Appointment>();

				while (reader.Read())
				{
					Appointment appointment = Appointment.Parse(reader);
					appointments.Add(appointment);
				}
				reader.Close();
				return appointments;
			}
		}
	}
}
