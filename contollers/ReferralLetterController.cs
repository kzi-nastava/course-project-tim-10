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

        public static List<ReferralLetter> LoadReferalLetters(string connectionString, string queryString)
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
    }
}
