using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthCareInfromationSystem.Core.Appointment.VacationRequest.VacationRequest;

namespace HealthCareInfromationSystem.Core.Appointment.VacationRequest
{
    class VacationRequestSQL : IVacationRequestRepo
    {
        public void Add(VacationRequest request)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                request.Id = GetFirstFreeId();
                connection.Open();
                string query = $"insert into vacation_request values {GetValues(request)}";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public VacationRequest Get(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"select * from vacation_request where request_id =\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                VacationRequest request = null;

                while (reader.Read())
                {
                    request = Parse(reader);
                }
                reader.Close();
                return request;
            }
        }

        public void Edit(VacationRequest request)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string dateSent = request.DateSent.ToString("dd.MM.yyyy. HH:mm");
                string dateBegin = request.DateBegin.ToString("dd.MM.yyyy. HH:mm");
                string dateEnd = request.DateEnd.ToString("dd.MM.yyyy. HH:mm");
                connection.Open();
                String query = $"update appointments set doctorId=\"{request.Doctor.Id}\", dateSent=\"{dateSent.Substring(0, dateSent.Length - 3)}\", " +
                   $"dateBegin=\"{dateBegin.Substring(0, dateBegin.Length - 3)}\", dateEnd=\"{dateEnd.Substring(0, dateEnd.Length - 3)}\"," +
                   $" reason=\"{request.Reason}\", status=\"{request.Status}\"" +
                   "$\"where id=\"{request.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<VacationRequest> GetAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = "select * from vacation_request where status=\"wait\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<VacationRequest> requests = new List<VacationRequest>();

                while (reader.Read())
                {
                    VacationRequest request = Parse(reader);
                    requests.Add(request);
                }
                reader.Close();
                return requests;
            }
        }

        private VacationRequest Parse(OleDbDataReader reader)
        {
            PersonSQL personRepo = new PersonSQL();
            int id = int.Parse(reader[0].ToString());
            Person doctor = personRepo.LoadOnePerson(reader[1].ToString());
            DateTime dateSent = DateTime.Parse(reader[2].ToString());
            DateTime dateBegin = DateTime.Parse(reader[3].ToString());
            DateTime dateEnd = DateTime.Parse(reader[4].ToString());
            string reason = reader[5].ToString();
            Enum.TryParse(reader[6].ToString(), out RequestStatus status);
            return new VacationRequest(id, doctor, dateSent, dateBegin, dateEnd, reason, status);

        }

        private string GetValues(VacationRequest request)
        {
            string dateSent = request.DateSent.ToString("dd.MM.yyyy. HH:mm");
            string dateBegin = request.DateBegin.ToString("dd.MM.yyyy. HH:mm");
            string dateEnd = request.DateEnd.ToString("dd.MM.yyyy. HH:mm");

            return $"({request.Id}\", \"{request.Doctor.Id}\", \"{dateSent.Substring(0, dateSent.Length - 3)}\", " +
                   $"\"{dateBegin.Substring(0, dateBegin.Length - 3)}\", \"{dateEnd.Substring(0, dateEnd.Length - 3)}\"," +
                   $" \"{request.Reason}\", \"{request.Status}\")";
        }

        private int GetFirstFreeId()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                OleDbCommand command = new OleDbCommand("select * from vacation_request", connection);

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

    }
}
