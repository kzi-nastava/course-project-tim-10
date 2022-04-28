using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;


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
    }
}
