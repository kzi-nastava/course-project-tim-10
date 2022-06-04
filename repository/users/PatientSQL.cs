using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.repository.users
{
    class PatientSQL : IPatientRepo
    {
        public void Add(Person patient)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into users values (\"{patient.Id.ToString()}\", \"{patient.FirstName}\", \"{patient.LastName}\", \"patient\", \"{patient.Username}\", \"{patient.Password}\", \"{patient.Blocked.ToString().ToLower()}\", \"{patient.Blocker.ToString()}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(Person patient)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                OleDbCommand command = new OleDbCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update users set name=@name, last_name=@lastName, username=@userName, [password]=@password, blocked=@blocked, blocker=@blocker where id=@id";
                command.Parameters.AddWithValue("@name", patient.FirstName);
                command.Parameters.AddWithValue("@lastName", patient.LastName);
                command.Parameters.AddWithValue("@userName", patient.Username);
                command.Parameters.AddWithValue("@password", patient.Password);
                command.Parameters.AddWithValue("@blocked", patient.Blocked.ToString().ToLower());
                command.Parameters.AddWithValue("@blocker", patient.Blocker.ToString());
                command.Parameters.AddWithValue("@id", patient.Id);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Delete(Person patient)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from users where id=\"{patient.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public bool IfExistsById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"select * from users where id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public bool IfExistsByUsername(string username)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"select * from users where username=\"{username}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public List<Person> GetAll()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                List<Person> patients = new List<Person>();
                string query = "select * from users where role=\"patient\"";
                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    patients.Add(Patient.Parse(reader));

                }
                reader.Close();
                return patients;
            }
        }

        public List<Person> GetBlockedPatients()
        {
            List<Person> patients = new List<Person>();
            foreach(Person patient in GetAll()) {
                if (patient.Blocked == true) patients.Add(patient);
            }
            return patients;
        }
    }
}
