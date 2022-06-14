 
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    class EmergencyNotificationSQL : IAppointmentNotificationRepo
    {
        private IAppointmentRepo appointmentRepo = new AppointmentSQL();
        public void Add(Appointment appointment)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    connection.Open();
                    string query = $"insert into emergency_notifications values (\"{GetFirstFreeId("emergency_notifications")}\", \"{appointment.Doctor.Id.ToString()}\", \"{appointment.Id.ToString()}\", \"false\")";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (OleDbException)
            {
                Console.WriteLine("Error while recieving notifications.");
            }
        }

        public string GetUnreceived(string doctorId)
        {
            try
            {
                List<string> notifications = new List<string>();
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    string query = $"select * from emergency_notifications where reciever=\"{doctorId}\" and recieved=\"false\"";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Appointment appointment = appointmentRepo.LoadOneAppointment(reader[2].ToString());
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
            } catch (OleDbException)
            {
                Console.WriteLine("Error while recieving notifications.");
                return "";
            }
        }

        public void MarkRecieved(string doctorId)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    connection.Open();
                    string query = $"update emergency_notifications set recieved=\"true\" where reciever=\"{doctorId}\"";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            } 
            catch (OleDbException) {
                Console.WriteLine("Error while recieving notifications.");
            }
        }

        private string GetFirstFreeId(string tableName)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();

                string query = $"select * from emergency_notifications";
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
