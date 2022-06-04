using HealthCareInfromationSystem.models.entity;
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
    class ReferralLetterController
    {
        private ReferralLetterService referralService = new ReferralLetterService();
        public void SetUsedTrue(ReferralLetter referral)
        {
            referralService.SetUsedTrue(referral);
        }

        public ReferralLetter GetById(string id)
        {
            return referralService.GetById(id);
        }

        public List<List<string>> GetRowsForPatientsReferrals(string patiendId)
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (ReferralLetter referral in referralService.GetUnusedForPatient(patiendId))
            {
                rows.Add(GetTableRow(referral));

            }
            return rows;
        }

        private static List<string> GetTableRow(ReferralLetter referral)
        {
            List<string> row = new List<string>();
            row.Add(referral.Id.ToString());
            row.Add(referral.DateCreated.ToString("dd.MM.yyyy. HH:mm"));
            row.Add(referral.Creator.FirstName + " " + referral.Creator.LastName);
            return row;
        }


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
