using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.Servise;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User.Patient
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
            row.Add(patient.FirstName);
            row.Add(patient.LastName);
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

        public bool Create(Person patient)
        {
            try
            {
                patientService.Add(patient);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }
        public bool Update(Person patient)
        {
            try
            {
                patientService.Edit(patient);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }
        public bool Delete(string patientId)
        {
            try
            {
                patientService.Delete(patientId);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        public bool CheckIfExistsById(string id)
        {
            return patientService.IfExistsById(id);
        }
        public bool CheckIfExistsByUsername(string username)
        {
            return patientService.IfExistsByUsername(username);
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
