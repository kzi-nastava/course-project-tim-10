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
        //dodato
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
        //dodato
        public static void Add(string patientId, string specialisation, string doctorId)
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

        public static ReferralLetter LoadOne(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                ReferralLetter referralLetter = null;

                while (reader.Read())
                {
                    referralLetter = ReferralLetter.Parse(reader);
                }
                reader.Close();
                return referralLetter;

            }
        }

        public static void MarkUsed(ReferralLetter referralLetter)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                referralLetter.Used = true;
                OleDbCommand command = new OleDbCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update referral_letter set used=@used where id=@id";
                command.Parameters.AddWithValue("@used", "True");
                command.Parameters.AddWithValue("@id", referralLetter.Id);
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();

            }
        }
    }
	
}
