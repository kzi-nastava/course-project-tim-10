using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System.Collections.Generic;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.contollers
{
    class NotificationController
    {

        public static void AddEmergencyNotification(Appointment appointment)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into emergency_notifications values (\"{GetFirstFreeId("emergency_notifications")}\", \"{appointment.Doctor.Id.ToString()}\", \"{appointment.Id.ToString()}\", \"false\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        // Loads all unrecieved notifications' text 
        public static string GetEmergencyNotifications(string connectionString, string doctorId)
        {
            List<string> notifications = new List<string>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = $"select * from emergency_notifications where doctorId=\"{doctorId}\" and recieved=\"false\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Appointment appointment = AppointmentController.LoadOneAppointment(Constants.connectionString, $"select * from appointments where id=\"{reader[2].ToString()}\"");
                    notifications.Add("Emergency appointment with patient " + appointment.Patient.FirstName + " " + appointment.Patient.LastName + " booked at " + appointment.Beginning.ToString("") + ".");
                }

                reader.Close();

                string notificationText = "";
                foreach (string notification in notifications)
                {
                    notificationText += notification + "\n";
                }

                return notificationText;
            }
        }

        public static void MarkEmergencyNotificationsAsRecieved(string connectionString, string doctorId)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"update emergency_notifications set recieved=\"true\" where doctorId=\"{doctorId}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static string GetFirstFreeId(string tableName)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();

                string query = $"select * from " + tableName;
                OleDbCommand command = new OleDbCommand(query, connection);
                

                OleDbDataReader reader = command.ExecuteReader();
                int maxId = 0;

                while (reader.Read())
                {
                    int id = int.Parse(reader[0].ToString());
                    if (id > maxId) { maxId = id; }
                }
                reader.Close();
                return (maxId + 1).ToString();
            }
        }

        public static void AddRescheduleNotification(Appointment appointment)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into reschedule_notifications values (\"{GetFirstFreeId("reschedule_notifications")}\", \"{appointment.Patient.Id.ToString()}\", \"{appointment.Doctor.Id.ToString()}\", \"{appointment.Id.ToString()}\", \"false\", \"false\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        // Loads all unrecieved notifications' text 
        public static string GetRescheduleNotifications(string connectionString, string patientId, string doctorId)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query;
                if (patientId != "") query = $"select * from reschedule_notifications where patientId=\"{patientId}\" and patientRecieved=\"false\"";
                else query = $"select * from reschedule_notifications where doctorId=\"{doctorId}\" and doctorRecieved=\"false\"";

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<string> notifications = new List<string>();

                while (reader.Read())
                {
                    Appointment appointment = AppointmentController.LoadOneAppointment(Constants.connectionString, $"select * from appointments where id=\"{reader[3].ToString()}\"");
                    if (patientId != "") notifications.Add("Rescheduled appointment with doctor " + appointment.Doctor.FirstName + " " + appointment.Doctor.LastName + " to " + appointment.Beginning.ToString() + ".");
                    else notifications.Add("Rescheduled appointment with patient " + appointment.Patient.FirstName + " " + appointment.Patient.LastName + " to " + appointment.Beginning.ToString() + ".");
                }
                reader.Close();

                string notificationText = "";
                foreach (string notification in notifications)
                {
                    notificationText += notification + "\n";
                }
                return notificationText;
            }
        }

        public static void MarkRescheduleNotificationsAsRecieved(string connectionString, string patientId, string doctorId)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = "";
                // Patient recieved notification
                if (patientId != "") query = $"update reschedule_notifications set patientRecieved=\"true\" where patientId=\"{patientId}\"";
                else query = $"update reschedule_notifications set doctorRecieved=\"true\" where doctorId=\"{doctorId}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}
