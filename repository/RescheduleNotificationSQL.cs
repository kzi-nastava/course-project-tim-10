using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository
{
    class RescheduleNotificationSQL : INotification
    {
        private IAppointmentRepo appointmentRepo = new AppointmentSQL();
        public void Add(Appointment appointment)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    connection.Open();
                    string query = $"insert into reschedule_notifications values (\"{GetFirstFreeId()}\", \"{appointment.Patient.Id.ToString()}\", \"{appointment.Id.ToString()}\", \"false\")";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();

                    query = $"insert into reschedule_notifications values (\"{GetFirstFreeId()}\", \"{appointment.Doctor.Id.ToString()}\", \"{appointment.Id.ToString()}, \"false\")";
                    command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (OleDbException)
            {
                Console.WriteLine("Error while recieving notifications.");
            }
        }

        public string GetUnreceived(string userId)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    string query = $"select * from reschedule_notifications where receiver=\"{userId}\" and received=\"false\"";

                    OleDbCommand command = new OleDbCommand(query, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    List<string> notifications = new List<string>();

                    while (reader.Read())
                    {
                        Appointment appointment = appointmentRepo.LoadOneAppointment(reader[2].ToString());
                        if (appointment.Patient.Id.ToString() == userId) notifications.Add("Rescheduled appointment with doctor " + appointment.Doctor.FirstName + " " + appointment.Doctor.LastName + " to " + appointment.Beginning.ToString() + ".");
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
            catch (OleDbException)
            {
                Console.WriteLine("Error while recieving notifications.");
                return "";
            }
        }

        public void MarkRecieved(string userId)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    connection.Open();
                    string query = $"update reschedule_notifications set received=\"true\" where receiver=\"{userId}\"";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (OleDbException)
            {
                Console.WriteLine("Error while recieving notifications.");
            }
        }

        public static string GetFirstFreeId()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();

                string query = $"select * from reschedule_notifications";
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

    }
}
