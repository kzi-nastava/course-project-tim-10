using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.repository
{
	class ReferralLetterSQL : IReferralLetterRepo
	{
		public void Add(string patientId, string specialisation, string doctorId)
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

        public ReferralLetter GetById(string id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"select * from referral_letter where ID={id}";
                OleDbCommand command = new OleDbCommand(query, connection);

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

        private int GetFirstFreeId()
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
	}
}
