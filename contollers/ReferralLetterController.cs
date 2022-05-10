using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.contollers
{
    class ReferralLetterController
    {
        public static void DeleteByPatientId(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"delete from referral_letter where patientId=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();

            }
        }

        public static List<ReferralLetter> LoadAll(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<ReferralLetter> referralLetters = new List<ReferralLetter>();

                while (reader.Read())
                {
                    ReferralLetter referralLetter = ReferralLetter.Parse(reader);
                    referralLetters.Add(referralLetter);
                }
                reader.Close();
                return referralLetters;
            }
        }

        public static int GetFirstFreeId()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select * from referral_letter", connection);

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

        public static void AddToBase(string patientId, string specialisation, string doctorId)
		{
            int id = GetFirstFreeId();
            if (doctorId == "") doctorId = "null";
            if (specialisation == "") specialisation = "null";
            DateTime now = DateTime.Now;
            string date = now.ToString("dd.MM.yyyy. HH:mm");
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into referral_letter values (\"{id}\", \"{patientId}\", \"{specialisation}\", \"{doctorId}\", \"{date}\", \"{LoggedInUser.GetId()}\", \"{false}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
	}
}
