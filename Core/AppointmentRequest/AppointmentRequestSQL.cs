using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.AppointmentRequest
{
    class AppointmentRequestSQL : IAppointmentRequestRepo
    {
        public List<AppointmentRequest> GetRequests()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = "select * from appointment_request where state=\"wait\"";
                OleDbCommand command = new OleDbCommand(query, connection);

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

        public AppointmentRequest Get(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"select * from appointment_request where request_id =\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                AppointmentRequest request = null;

                while (reader.Read())
                {
                    request = AppointmentRequest.Parse(reader);
                }
                reader.Close();
                return request;
            }
        }

        public void SetState(AppointmentRequest request, string state)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string secretaryId = utils.LoggedInUser.loggedIn.Id.ToString();
                string query = $"update appointment_request set state=\"{state}\", secretary_id=\"{secretaryId}\" where request_id=\"{request.ID}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteByPatientId(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from appointment_request where patient_id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

        public void Add(AppointmentRequest request)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into appointment_request values {AppointmentRequestController.GetValues(request)}";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}
