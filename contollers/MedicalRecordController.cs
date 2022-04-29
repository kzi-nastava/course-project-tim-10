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
    }
}
