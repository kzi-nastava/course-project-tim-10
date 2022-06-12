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
using HealthCareInfromationSystem.Servise;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.contollers
{
	class AppointmentController
	{
        private AppointmentService appointmentService = new AppointmentService();
        //dodato
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
        
        //dodato
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


        //dodato
        public static int GetFirstFreeId()
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

        //dodato
        public static void Add(Appointment appointment)
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

        //AAAAAAAAAAAAAAAAAA
        public static void AddEmergencyToBase(Appointment emergency)
        {
            emergency.Id =  GetFirstFreeId();
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string date = emergency.Beginning.ToString("dd.MM.yyyy. HH:mm");
                String query = $"insert into appointments values (\"{emergency.Id.ToString()}\", \"{emergency.Doctor.Id.ToString()}\", \"{emergency.Patient.Id.ToString()}\", \"{emergency.Premise.Id.ToString()}\", \"{date}\", \"{emergency.Duration.ToString()}\", \"{emergency.Type.ToString()}\", \"\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        //dodato
        public static void Edit(Appointment appointment)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string date = appointment.Beginning.ToString("dd.MM.yyyy. HH:mm");
                String query = $"update appointments set doctorId=\"{appointment.Doctor.Id}\", patientId=\"{appointment.Patient.Id}\", " +
                    $"premiseId=\"{appointment.Premise.Id}\", beginning=\"{date}\", duration=\"{appointment.Duration}\", type=\"{appointment.Type}\" where id=\"{appointment.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }


        // Functions to move to different controller

        // Calculating time difference between original appointment beginning and reschedule beginning
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

    }
}
