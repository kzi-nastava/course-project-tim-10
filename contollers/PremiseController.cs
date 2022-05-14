using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.contollers
{
    class PremiseController
    {
        public bool CheckIfPremiseExistsById(String id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"select * from premises where premises_id = \"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public bool CheckIfPremiseIsOccupied(String id, String startDate, String endDate)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"" +
                    $"select premiseId, Mid(beginning, 1, 11) " +
                    $"from appointments " +
                    $"where premiseId=\"{id}\" and " +
                    $"DateValue(Replace(Replace(\"{startDate}\", \'.\', \'/\', 1, 2), \'.\', \'\')) < DateValue(Replace(Replace(Mid(beginning, 1, 11), \'.\', \'/\', 1, 2), \'.\', \'\')) and " +
                    $"DateValue(Replace(Replace(\"{endDate}\", \'.\', \'/\', 1, 2), \'.\', \'\')) > DateValue(Replace(Replace(Mid(beginning, 1, 11), \'.\', \'/\', 1, 2), \'.\', \'\'))";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                return reader.HasRows;
            }
        }

        public void SavePremise(Premise premise)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into premises values (\"{premise.Id}\", \"{premise.Name}\", \"{premise.Type}\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void EditPremise(Premise premise)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"update premises set name=\"{premise.Name}\", type=\"{premise.Type}\" where premises_id=\"{premise.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeletePremise(String id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"select old_premises_id, new_premises_id, move_date from equipment where old_premises_id = \"{id}\" or new_premises_id = \"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    String oldPremisesId = reader[0].ToString();
                    String newPremisesId = reader[1].ToString();
                    String date = reader[2].ToString();
                    String today = $"{DateTime.Today.Day.ToString()}.{DateTime.Today.Month.ToString()}.{DateTime.Today.Year.ToString()}.";
                    DateTime dateFromRepository = DateTime.Parse(date);
                    DateTime dateToday = DateTime.Parse(today);

                    int result = DateTime.Compare(dateFromRepository, dateToday);

                    if (
                        ((result == -1 || result == 0) && newPremisesId == id) ||
                        (result == 1 && oldPremisesId == id)
                        )
                    {
                        MessageBox.Show("There is equipment in premise so you can't delete it.");
                        return;
                    }

                    else if (result == 1 && newPremisesId == id)
                    {
                        MessageBox.Show("You can't delete premise because equipment is scheduled to be moved in it.");
                        return;
                    }
                }

                reader.Close();

                query = $"delete from premises where premises_id = \"{id}\"";
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void SimpleDeletePremise(String id)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"delete from premises where premises_id=\"{id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        /*
	    * Retrieves a specific premise from dataset

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    Premise or null if the premise is not found.
	    * */
        public static Premise LoadOnePremise(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Premise premise = null;

                while (reader.Read())
                {
                    premise = Premise.Parse(reader);

                }
                reader.Close();
                return premise;
            }
        }

        /*
	    * Creates dictionary used for filling in a combobox

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    Dictionary where key = premise id(firs value in query) and value = premise name(second value in query).
	    * */
        public static Dictionary<string, string> LoadPair(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Dictionary<string, string> premise = new Dictionary<string, string>();

                while (reader.Read())
                {
                    premise.Add(reader[0].ToString(), reader[1].ToString());

                }
                reader.Close();
                return premise;
            }
        }

        public static Premise SearchPremise(string id)
        {
            return LoadOnePremise(Constants.connectionString, $"select * from premises where premises_id = \"{id}\"");
        }
    }
}
