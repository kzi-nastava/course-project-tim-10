using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.repository.users;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Poll
{
    class PollDoctorSQL : IPollDoctorRepo
    {
        public void Add(PollDoctor pollDoctor)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into poll_doctor values (\"{pollDoctor.Id}\", \"{pollDoctor.Quality}\", \"{pollDoctor.Recommendation}\"," +
                    $" \"{pollDoctor.Comment}\", \"{pollDoctor.Doctor.Id}\", \"{pollDoctor.Patient.Id}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(PollDoctor pollDoctor)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"update poll_doctor set quality=\"{pollDoctor.Quality}\", recommendation=\"{pollDoctor.Recommendation}\", " +
                    $"comment=\"{pollDoctor.Comment}\", doctorId=\"{pollDoctor.Doctor.Id}\", patientId=\"{pollDoctor.Patient.Id}\" " +
                    $"where ID=\"{pollDoctor.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<PollDoctor> LoadAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                OleDbCommand command = new OleDbCommand("select * from poll_doctor", connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<PollDoctor> polls = new List<PollDoctor>();

                while (reader.Read())
                {
                    PollDoctor poll = PollDoctor.Parse(reader);
                    polls.Add(poll);
                }
                reader.Close();
                return polls;
            }
        }



    }
}
