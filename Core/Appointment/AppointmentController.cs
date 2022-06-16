using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.Servise;
using HealthCareInfromationSystem.Core.MedicalRecord;
using HealthCareInfromationSystem.Core.PremiseManagment;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.Core.Appointment
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

		public MedicalRecord.MedicalRecord GetMedicalRecordByPatient(string patientId)
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

		public static Appointment LoadOneAppointment(string connectionString, string queryString)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{

				OleDbCommand command = new OleDbCommand(queryString, connection);

				connection.Open();
				OleDbDataReader reader = command.ExecuteReader();
				Appointment appointment = null;

				while (reader.Read())
				{
					appointment = Appointment.Parse(reader);
					//Console.WriteLine($"commet iz:{appointment.Comment}");
				}
				reader.Close();
				return appointment;
			}
		}


		private Dictionary<Appointment, TimeSpan> GetRescheduledTimeDifference(Dictionary<Appointment, DateTime> appointmentsByRescheduleTimes)
		{
			Dictionary<Appointment, TimeSpan> appointmentsByRescheduleDifference = new Dictionary<Appointment, TimeSpan>();
			foreach (KeyValuePair<Appointment, DateTime> pair in appointmentsByRescheduleTimes)
			{
				appointmentsByRescheduleDifference[pair.Key] = pair.Key.Beginning - pair.Value;
			}
			return appointmentsByRescheduleDifference;
		}


		public List<KeyValuePair<Appointment, DateTime>> SortEarliestToReschedule(Dictionary<Appointment, DateTime> appointmentsByRescheduleTimes)
		{
			Dictionary<Appointment, TimeSpan> appointmentsByRescheduleDifference = GetRescheduledTimeDifference(appointmentsByRescheduleTimes);

			// Sorting appointments by difference in ascending order
			List<KeyValuePair<Appointment, TimeSpan>> sortedEarliestToReschedule = appointmentsByRescheduleDifference.ToList();
			sortedEarliestToReschedule.Sort(delegate (KeyValuePair<Appointment, TimeSpan> pair1,
				KeyValuePair<Appointment, TimeSpan> pair2)
			{
				return pair2.Value.CompareTo(pair1.Value);
			});

			// Combining the results from the sort with time for reschedule beginning 
			List<KeyValuePair<Appointment, DateTime>> sortedAppointmentsByEarliestReschedule = new List<KeyValuePair<Appointment, DateTime>>();
			foreach (var pair in sortedEarliestToReschedule)
			{
				sortedAppointmentsByEarliestReschedule.Add(new KeyValuePair<Appointment, DateTime>(pair.Key, appointmentsByRescheduleTimes[pair.Key]));
			}

			return sortedAppointmentsByEarliestReschedule;

		}

		public List<List<string>> GetRowsForEarliestAppointments(string specialisationName)
		{
			// Get all appointments in the next two hours with the times possible to reschedule to
			Dictionary<Appointment, DateTime> appointmentsByRescheduleTimes = appointmentService.GetPotentialRescheduleTimes(specialisationName);

			List<KeyValuePair<Appointment, DateTime>> sortedAppointmentsByEarliestReschedule = SortEarliestToReschedule(appointmentsByRescheduleTimes);

			List<List<String>> rows = new List<List<string>>();
			int i = 0;
			foreach (KeyValuePair<Appointment, DateTime> pair in sortedAppointmentsByEarliestReschedule)
			{
				List<string> row = new List<string>();
				row.Add(pair.Key.Beginning.ToString("dd.MM.yyyy. HH:mm"));
				row.Add(pair.Key.Duration.ToString());
				row.Add(pair.Value.ToString("dd.MM.yyyy. HH:mm"));
				row.Add(pair.Key.Doctor.FirstName + " " + pair.Key.Doctor.LastName);
				row.Add(pair.Key.Patient.FirstName + " " + pair.Key.Patient.LastName);
				row.Add(pair.Key.Id.ToString());
				rows.Add(row);
				++i;
				if (i > 5) break;
			}
			return rows;

		}

		public bool BookEmergency(Appointment appointment, string specialisation)
		{
			return appointmentService.BookEmergency(appointment, specialisation);
		}

		public static List<Appointment> LoadAppointments(string connectionString, string queryString)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{

				OleDbCommand command = new OleDbCommand(queryString, connection);

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
