using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.PremiseManagment.Renovation
{
    class RenovationSQL : IRenovationRepo
    {
        public List<SimpleRenovation> LoadAllSimpleRenovations()
        {
			List<SimpleRenovation> renovations = new List<SimpleRenovation>();
			using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
			{
				connection.Open();
				String query = $"select * from simple_renovations";
				OleDbCommand command = new OleDbCommand(query, connection);
				OleDbDataReader reader = command.ExecuteReader();

				while (reader.Read())
					renovations.Add(SimpleRenovation.Parse(reader));

				reader.Close();
				return renovations;
			}
		}

        public void SaveSimpleRenovation(SimpleRenovation renovation)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into simple_renovations values (\"{renovation.Id}\", \"{renovation.PremiseId}\", \"{renovation.StartDate}\", \"{renovation.EndDate}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public bool CheckIfSimpleRenovationExistsById(String id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"select * from simple_renovations where simple_renovation_id = \"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }
    }
}
