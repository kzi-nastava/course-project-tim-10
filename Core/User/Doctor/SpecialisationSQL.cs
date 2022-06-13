using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.User.Doctor
{
	class SpecialisationSQL : ISpecialisationRepo
	{
        private IPersonRepo personRepo = new PersonSQL();
		public List<string> GetDoctorIds(string specName)
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"select doctors from specialisations where name=\"{specName}\"";

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<string> doctorIds = new List<string>();

                while (reader.Read())
                {
                    doctorIds.Add(reader[0].ToString());
                }
                reader.Close();
                return doctorIds;

            }
        }

        public List<Person> GetDoctors(string specialisationName)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"select doctors from specialisations where name=\"{specialisationName}\"";

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Person> doctors = new List<Person>();

                while (reader.Read())
                {
                    doctors.Add(personRepo.LoadOnePerson(reader[0].ToString()));
                }
                reader.Close();
                return doctors;

            }
        }


        public List<string> LoadSpecialisations()
		{
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select distinct name from specialisations", connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<string> specialisations = new List<string>();

                while (reader.Read())
                {
                    specialisations.Add(reader[0].ToString());
                }
                reader.Close();
                return specialisations;
            }
        }
	}
}
