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

namespace HealthCareInfromationSystem.contollers
{
	class AppointmentController
	{
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

       //Lepo napisano u appointment service
        public static bool IsAvailable(string connectionString, string queryString, string beginning, string duration)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                DateTime beginningNew = DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null);
                DateTime endingNew = beginningNew.AddMinutes(int.Parse(duration));
                int c = 0;

                while (reader.Read())
                {
                    c++;
                    DateTime beginningOld = DateTime.ParseExact(reader[4].ToString(), "dd.MM.yyyy. HH:mm", null);
                    DateTime endingOld = beginningOld.AddMinutes(int.Parse(reader[5].ToString()));
                    if ((beginningOld <= beginningNew && beginningNew <= endingOld)
                        || (beginningOld <= endingNew && endingNew <= endingOld)
                        || (beginningNew <= beginningOld && endingNew >= endingOld))
                    {
                        //Console.WriteLine(c);
                        return false;
                    }

                }
                //Console.WriteLine(c);
                reader.Close();
                return true;
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
                String query = $"insert into appointments values (\"{emergency.Id.ToString()}\", \"{emergency.Doctor.Id.ToString()}\", \"{emergency.Patient.Id.ToString()}\", \"{emergency.Premise.Id.ToString()}\", \"{emergency.Beginning.ToString("dd.MM.yyyy. HH:mm")}\", \"{emergency.Duration.ToString()}\", \"{emergency.Type.ToString()}\", \"\")";
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
                string date = appointment.Beginning.ToString();
                String query = $"update appointments set doctorId=\"{appointment.Doctor.Id}\", patientId=\"{appointment.Patient.Id}\", " +
                    $"premiseId=\"{appointment.Premise.Id}\", beginning=\"{date.Substring(0, date.Length - 3)}\", duration=\"{appointment.Duration}\", type=\"{appointment.Type}\" where id=\"{appointment.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        //dodato
        public static void Delete(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from appointments where id = \"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteByPatientId(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from appointments where patientId=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

        


        public static bool CheckAvailability(int doctorId, DateTime beginning, int duration, string premiseId, int patientId)
        {
            // doctor
            if (!AppointmentController.IsAvailable(Constants.connectionString,
                    "select * from appointments where doctorId =\"" + doctorId + "\"",
                    beginning.ToString("dd.MM.yyyy. HH:mm"), duration.ToString())) return false;

            // patient
            if (!AppointmentController.IsAvailable(Constants.connectionString,
            "select * from appointments where patientId=\"" + patientId + "\"",
            beginning.ToString("dd.MM.yyyy. HH:mm"), duration.ToString())) return false;

            // premise
            if (!AppointmentController.IsAvailable(Constants.connectionString,
            "select * from appointments where premiseId =\"" + premiseId + "\"",
            beginning.ToString("dd.MM.yyyy. HH:mm"), duration.ToString())) return false;

            return true;
        }

        private static Dictionary<Appointment, DateTime> GetPotentialRescheduleTimes(List<string> doctorIds)
        {
            Dictionary<Appointment, DateTime> earliestRescheduleTimes = new Dictionary<Appointment, DateTime>();

            // Get all doctor's future appointments in the next two hours in ascending order
            DateTime timestampNow = DateTime.Now;
            DateTime timestampTwoHoursFromNow = DateTime.Now.AddMinutes(120);
            string query = $"select * from appointments";
            List<Appointment> appointments = AppointmentController.LoadAppointments(Constants.connectionString, query);


            // Finding the earliest reschedule time for every appointment in the next two hours for doctors with specialisation
            foreach (Appointment appointment in appointments)
            {
                if (appointment.Beginning > timestampNow && appointment.Beginning < timestampTwoHoursFromNow && doctorIds.Contains(appointment.Doctor.Id.ToString()))
                {
                    earliestRescheduleTimes[appointment] = appointment.GetEarliestRescheduleTime();
                }
            }

            return earliestRescheduleTimes;
        }

        public static List<KeyValuePair<Appointment, DateTime>> SortEarliestToReschedule(List<String> doctorIds)
        {
            // Get all appointments in the next two hours with the times possible to reschedule to
            Dictionary<Appointment, DateTime> appointmentsByPotentialRescheduleTimes = GetPotentialRescheduleTimes(doctorIds);

            // Calculating time difference between original appointment beginning and reschedule beginning
            Dictionary<Appointment, TimeSpan> appointmentsByRescheduleDifference = new Dictionary<Appointment, TimeSpan>();
            foreach (KeyValuePair<Appointment, DateTime> pair in appointmentsByPotentialRescheduleTimes)
            {
                appointmentsByRescheduleDifference[pair.Key] = pair.Key.Beginning - pair.Value;
            }

            // Sorting appointments by difference in beginnings in ascending order
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
                sortedAppointmentsByEarliestReschedule.Add(new KeyValuePair<Appointment, DateTime>(pair.Key, appointmentsByPotentialRescheduleTimes[pair.Key]));
            }

            return sortedAppointmentsByEarliestReschedule;

        }
    }
}
