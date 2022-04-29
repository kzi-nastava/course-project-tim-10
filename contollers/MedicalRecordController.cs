using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.contollers
{
	class MedicalRecordController
	{
        internal static MedicalRecord LoadMedical(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    return MedicalRecord.Parse(reader);
                }
                reader.Close();
                return null;
            }
        }

		internal static void EdditInBase(int id, string height, string weight, string bloodType, string disease, string alergie)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update medical_record set height=\"{height}\", weight=\"{weight}\", " +
                    $"bloodType=\"{bloodType}\", disease=\"{disease}\", alergies=\"{alergie}\" where id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
	}
}
