using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
    class AppointmentRequestController
    {
        public static void DeleteByPatientId(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from appointment_request where patient_id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

        public static List<AppointmentRequest> LoadAppointmentRequests(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<AppointmentRequest> appointmentRequests = new List<AppointmentRequest>();

                while (reader.Read())
                {
                    AppointmentRequest appointmentRequest = AppointmentRequest.Parse(reader);
                    appointmentRequests.Add(appointmentRequest);
                }
                reader.Close();
                return appointmentRequests;
            }
        }
    }
}
