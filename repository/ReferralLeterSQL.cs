using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.repository
{
	class ReferralLeterSQL : IReferealLeterRepo
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
