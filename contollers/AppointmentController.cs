using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.contollers
{
	class AppointmentController
	{
        /*
	    * Retrieves data from dataset

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data

            Returns:
                    array<Appointment>
	    * */
        public static List<Appointment> LoadAppointments(string connectionString, string queryString)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                List<Appointment> appointments = new List<Appointment>();

                while (reader.Read())
                {
                    Appointment appointment = Appointment.Parse(reader);
                    appointments.Add(appointment);
                }
                reader.Close();
                return appointments;
            }
        }

        /*
	    * Checks if any apointments exist at this time

            Parameters:
                    connectionString(string): name of the connection
                    queryString(string): query for retrieving data
                    beginning(string): time that we want to start our appointment
                    durration(string): how long it would last

            Returns:
                    bool value, true if we can book an appointment, false if we can not
	    * */
        public static bool IsAvailable(string connectionString, string queryString, string beginning, string duration)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {

                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                DateTime beginningNew = DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null);
                DateTime endingNew = beginningNew.AddMinutes(int.Parse(duration));
                int c = 0;

                while (reader.Read())
                {
                    c++;
                    DateTime beginningOld = DateTime.ParseExact(reader[4].ToString(), "dd.MM.yyyy. HH:mm", null);
                    DateTime endingOld = beginningOld.AddMinutes(int.Parse(reader[5].ToString()));
                    if ((beginningOld <= beginningNew && beginningNew <= endingOld)
                        || (beginningOld <= endingNew && endingNew <= endingOld))
                    {
                        Console.WriteLine(c);
                        return false;
                    }

                }
                Console.WriteLine(c);
                reader.Close();
                return true;
            }
        }

        public static int GetFirstFreeId()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {

                OleDbCommand command = new OleDbCommand("select * from appointments", connection);

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

        public static void AddToBase(string patientId, string premiseId, int doctorId, string beginning, string duration, string type)
        {
            int id = GetFirstFreeId();
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                String query = $"insert into appointments values (\"{id}\", \"{doctorId}\", \"{patientId}\", \"{premiseId}\", \"{beginning}\", \"{duration}\", \"{type}\", \"\")";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }

        }
    }
}
