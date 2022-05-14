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
        /*
	    * Retrieves data from dataset

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    array<Appointment>
	    * */
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

        public static List<Appointment> LoadAppointmentsForDate(string connectionString, string queryString, string inputDate)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Appointment> appointments = new List<Appointment>();
                DateTime beginningDate = DateTime.ParseExact(inputDate, "dd.MM.yyyy.", null);
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

        internal static string GetPatientId(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    return reader[0].ToString();
                }
                reader.Close();
                return null;
            }
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

        /*
	    * Checks if any apointments exist at this time

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data
                    beginning(string): time that we want to start our appointment
                    durration(string): how long it would last

            Returns:
                    bool value, true if we can book an appointment, false if we can not
	    * */
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

        public static void AddToBase(string patientId, string premiseId, int doctorId, string beginning, string duration, string type)
        {
            int id = GetFirstFreeId();
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into appointments values (\"{id}\", \"{doctorId}\", \"{patientId}\", \"{premiseId}\", \"{beginning}\", \"{duration}\", \"{type}\", \"\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }

        }

        public static void EditInBase(string appointmentId, string patientId, string premiseId, int doctorId, string beginning, string duration, string type)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update appointments set doctorId=\"{doctorId}\", patientId=\"{patientId}\", " +
                    $"premiseId=\"{premiseId}\", beginning=\"{beginning}\", duration=\"{duration}\", type=\"{type}\" where id=\"{appointmentId}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void EditAppointmentComment(string appointmentId, string comment)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update appointments set comment=\"{comment}\" where id=\"{appointmentId}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteFromBase(string id)
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

        public static bool IsAvailableAllChecks(string beginning, string duration, string premiseId, string patientId, string appointmentId) {
            //checking if the doctor is available
            if (!IsAvailable(Constants.connectionString,
                "select * from appointments where doctorId =\"" + LoggedInUser.loggedIn.Id + "\" and not id=\"" + appointmentId + "\"",
                beginning, duration))
            {
                MessageBox.Show("Doctor has an appointment.", "Error");
                return false;
            }

            //checking if the room is available
            if (!IsAvailable(Constants.connectionString,
            "select * from appointments where premiseId =\"" + premiseId + "\" and not id=\"" + appointmentId + "\"",
            beginning, duration))
            {
                MessageBox.Show("Premise occupied.", "Error");
                return false;
            }

            //checking if the patient is available
            if (!IsAvailable(Constants.connectionString,
            "select * from appointments where patientId=\"" + patientId + "\" and not id=\"" + appointmentId + "\"",
            beginning, duration))
            {
                MessageBox.Show("Patient has an appointment.", "Error");
                return false;
            }

            return true;
        }


        public static void InsertNew(Appointment app)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"insert into appointments values (\"{app.Id}\", \"{app.Doctor.Id}\", \"{app.Patient.Id}\", " +
                    $"\"{app.Premise.Id}\", \"{MyConverter.ToString(app.Beginning)}\", \"{app.Duration}\", \"{app.Type}\", \"{app.Comment}\")";

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
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
