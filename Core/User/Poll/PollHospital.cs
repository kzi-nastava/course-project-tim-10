using HealthCareInfromationSystem.Core.Appointment;
using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.Servise;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.User.Poll
{
    class PollHospital : PollDoctor
    {
        private int _cleanliness;
        private int _impression;

        public int Impression
        {
            get { return _impression; }
            set { _impression = value; }
        }

        public int Cleanliness
        {
            get { return _cleanliness; }
            set { _cleanliness = value; }
        }


        public PollHospital(int id, int quality, int cleanliness, int impression, int recommendation, string comment, Person patient)
        {
            _id = id;
            _quality = quality;
            _cleanliness = cleanliness;
            _impression = impression;
            _recommendation = recommendation;
            _comment = comment;
            _patient = patient;
        }

        internal static PollHospital Parse(OleDbDataReader reader)
        {
            AppointmentService appointmentService = new AppointmentService();
            int id = int.Parse(reader[0].ToString());
            int quality = int.Parse(reader[1].ToString());
            int cleanliness = int.Parse(reader[2].ToString());
            int impression = int.Parse(reader[3].ToString());
            int recommendation = int.Parse(reader[4].ToString());
            string comment = reader[5].ToString();
            Person patient = appointmentService.GetPersonById(reader[6].ToString());
            return new PollHospital(id, quality, cleanliness, impression, recommendation, comment, patient);
        }


    }
}
