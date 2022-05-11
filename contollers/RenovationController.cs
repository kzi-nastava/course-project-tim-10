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
    class RenovationController
    {
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

        public void SaveComplexRenovation(ComplexRenovation renovation)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into complex_renovations values (\"{renovation.Premise.Id}\", \"{renovation.Premise.Name}\", \"{renovation.Premise.Type}\", \"{renovation.Flag}\", \"{renovation.Move_date}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
