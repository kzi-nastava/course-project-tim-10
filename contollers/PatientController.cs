using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.Servise;
using HealthCareInfromationSystem.utils;
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
        private PatientService patientService = new PatientService();

        public List<List<string>> GetRowsForBlockedPatients()
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (Person patient in patientService.GetBlockedPatients())
            {
                rows.Add(GetTableRow(patient));

            }
            return rows;
        }
        public List<List<string>> GetRowsForPatients()
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (Person patient in patientService.GetAll())
            {
                rows.Add(GetTableRow(patient));

            }
            return rows;
        }

        private List<string> GetTableRow(Person patient)
        {
            List<string> row = new List<string>();
            row.Add(patient.Id.ToString());
            row.Add(patient.FirstName + " " + patient.LastName);
            row.Add(patient.Username);
            row.Add(patient.Password);
            row.Add(patient.Blocked.ToString());
            row.Add(patient.Blocker.ToString());
            return row;
        }
        public bool Unblock(string patientId)
        {
            try
            {
                patientService.Unblock(patientId);  
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }
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

        public static bool Edit(string id, string name, string lastName, string username, string password, string blocked, int blocker)
        {
            try
            {
                UpdatePatient(id, name, lastName, username, password, blocked, blocker);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        public static bool Delete(string id)
        {
            try
            {
                DeletePatient(id);
                MedicalRecordController.DeleteByPatientId(id);
                AppointmentController.DeleteByPatientId(id);
                ReferralLetterController.DeleteByPatientId(id);
                AppointmentRequestController.DeleteByPatientId(id);
                return true;
            }
            catch (OleDbException)
            {
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

        public static void UpdatePatient(string id, string name, string lastName, string username, string password, string blocked, int blocker)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update users set name=@name, last_name=@lastName, username=@userName, [password]=@password, blocked=@blocked, blocker=@blocker where id=@id";
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@userName", username);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@blocked", blocked);
                command.Parameters.AddWithValue("@blocker", blocker.ToString());
                command.Parameters.AddWithValue("@id", id);
                command.Connection = connection;
                connection.Open();
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

        internal static bool IsPossibleLogin()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                return CorrectUpdates(connection) && CorrectCreation(connection);
            }
        }

        private static bool CorrectCreation(OleDbConnection connection)
        {
            connection.Open();
            string patientId = LoggedInUser.loggedIn.Id.ToString();
            string query = $"select * from appointments where patientId = \"{patientId}\"";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();

            int appointmentCounter = 0;
            while (reader.Read())
            {
                DateTime appDate = MyConverter.ToDateTime(reader[4].ToString());
                DateTime now = DateTime.Now;
                if ((appDate.AddDays(30).CompareTo(now) > 0) && (++appointmentCounter >= 8))
                    return false;
            }
            connection.Close();
            return true;
        }

        private static bool CorrectUpdates(OleDbConnection connection)
        {
            connection.Open();
            string patientId = LoggedInUser.loggedIn.Id.ToString();
            string query = $"select * from appointment_request where patient_id = \"{patientId}\"";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();

            int requestCounter = 0;
            while (reader.Read())
            {
                if (reader[0].ToString().Equals(""))
                    continue;
                DateTime reqDate = MyConverter.ToDateTime(reader[6].ToString());
                DateTime now = DateTime.Now;
                if ((reqDate.AddDays(30).CompareTo(now) > 0) && (++requestCounter >= 5))
                    return false;
            }
            connection.Close();
            return true;
        }

    }
}
