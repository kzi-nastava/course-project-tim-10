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

        public static bool AcceptRequest(string id, string requestType)
        {
            try
            {
                if (requestType == "edit") AcceptRequestChange(id);
                if (requestType == "delete") AcceptRequestCancellation(id);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        private static void AcceptRequestChange(string id)
        {
            ChangeRequestState(id, "accepted");
            string query = $"select * from appointment_request where request_id =\"{id}\"";
            AppointmentRequest request = AppointmentRequestController.LoadOneRequest(Constants.connectionString, query);
            models.entity.Appointment appointment = request.Appointment;
            appointment.Doctor = request.NewDoctor;
            AppointmentController.EditInBase(appointment.Id.ToString(), appointment.Patient.Id.ToString(), appointment.Premise.Id, appointment.Doctor.Id, request.NewBeginning, appointment.Duration.ToString(), appointment.Type.ToString());
        }

        private static void AcceptRequestCancellation(string id)
        {
            ChangeRequestState(id, "accepted");
            string query = $"select * from appointment_request where request_id =\"{id}\"";
            AppointmentRequest request = AppointmentRequestController.LoadOneRequest(Constants.connectionString, query);
            AppointmentController.DeleteFromBase(request.Appointment.Id.ToString());
        }

        public static bool DeclineRequest(string id)
        {
            try
            {
                ChangeRequestState(id, "declined");
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        private static void ChangeRequestState(string requestId, string state)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string secretaryId = utils.LoggedInUser.loggedIn.Id.ToString();
                string query = $"update appointment_request set state=\"{state}\", secretary_id=\"{secretaryId}\" where request_id=\"{requestId}\"";
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

        public static AppointmentRequest LoadOneRequest(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

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

    }
}
