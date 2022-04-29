using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
    class PatientController
    {
        public static bool CheckIfExistsById(string id)
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

        public static bool CheckIfExistsByUsername(string username)
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

        public static bool AddNew(string id, string name, string lastName, string username, string password, string blocked, int blocker)
        {
            try
            {
                InsertPatient(id, name, lastName, username, password, blocked, blocker);
                MedicalRecordController.AddNewByPatientId(id);
                return true;
            }
            catch (OleDbException)
            {
                DeletePatient(id);
                return false;
            }
        }


        // Working with database

        private static void InsertPatient(string id, string name, string lastName, string username, string password, string blocked, int blocker)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"insert into users values (\"{id}\", \"{name}\", \"{lastName}\", \"patient\", \"{username}\", \"{password}\", \"{blocked}\", {blocker})";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        private static void DeletePatient(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from users where id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}
