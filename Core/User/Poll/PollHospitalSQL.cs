 
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User.Poll
{
    class PollHospitalSQL : IPollHospitalRepo
    {
        public void Add(PollHospital pollHospital)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into poll_hospital values (\"{pollHospital.Id}\", \"{pollHospital.Quality}\", " +
                    $"\"{pollHospital.Cleanliness}\", \"{pollHospital.Impression}\", \"{pollHospital.Recommendation}\"," +
                    $" \"{pollHospital.Comment}\", \"{pollHospital.Patient.Id}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(PollHospital pollHospital)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"update poll_hospital set quality=\"{pollHospital.Quality}\", cleanliness=\"{pollHospital.Cleanliness}\", " +
                    $"impression=\"{pollHospital.Impression}\", recommendation=\"{pollHospital.Recommendation}\", " +
                    $"comment=\"{pollHospital.Comment}\", patientId=\"{pollHospital.Patient.Id}\" " +
                    $"where ID=\"{pollHospital.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<PollHospital> LoadAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                OleDbCommand command = new OleDbCommand("select * from poll_hospital", connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<PollHospital> polls = new List<PollHospital>();

                while (reader.Read())
                {
                    PollHospital poll = PollHospital.Parse(reader);
                    polls.Add(poll);
                }
                reader.Close();
                return polls;
            }
        }



    }
}
