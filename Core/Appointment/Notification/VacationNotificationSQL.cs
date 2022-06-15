using HealthCareInfromationSystem.Core.Appointment.VacationRequest;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    class VacationNotificationSQL : IVacationNotificationRepo
    {
        public void Add(VacationRequest.VacationRequest request, string reason)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    connection.Open();
                    string query = $"insert into vacation_notification values (\"{GetFirstFreeId("emergency_notifications")}\", \"{request.Doctor.Id}\", \"{request.Id}\", \"false\", \"{reason}\")";
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
                    VacationRequestService requestService = new VacationRequestService();
                    string query = $"select * from vacation_notification where receiver=\"{doctorId}\" and received=\"false\"";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string reason = reader[4].ToString();
                        VacationRequest.VacationRequest request = requestService.Get(reader[2].ToString());
                        notifications.Add(GetNotificationText(request, reason));
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
                Console.WriteLine("Error while receiving notifications.");
                return "";
            }
        }

        private string GetNotificationText(VacationRequest.VacationRequest request, string reason)
        {
            if (request.Status == VacationRequest.VacationRequest.RequestStatus.accepted) return "Request for vacation from " + request.DateBegin.ToString("dd.MM.yyyy.") + " to " + request.DateEnd.ToString("dd.MM.yyyy.") + " has been approved.";
            else return "Request for vacation from " + request.DateBegin.ToString("dd.MM.yyyy.") + " to " + request.DateEnd.ToString("dd.MM.yyyy.") + " has been declined" +
                    "\n for the following reason: " + reason + ".";
        }

        public void MarkRecieved(string doctorId)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
                {
                    connection.Open();
                    string query = $"update vacation_notification set received=\"true\" where receiver=\"{doctorId}\"";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (OleDbException)
            {
                Console.WriteLine("Error while receiving notifications.");
            }
        }

        private string GetFirstFreeId(string tableName)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();

                string query = $"select * from vacation_notification";
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
