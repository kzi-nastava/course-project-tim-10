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
    class PollDoctor
    {
        protected int _id;
        protected int _quality;
        protected int _recommendation;
        protected string  _comment;
        protected Person _patient;
        protected Person _doctor;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Person Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }

        public Person Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }

        public string  Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        public int Recommendation
        {
            get { return _recommendation; }
            set { _recommendation = value; }
        }

        public int Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }


        public PollDoctor()
        {

        }

        public PollDoctor(int id, int quality, int recommendation, string comment, Person doctor, Person patient)
        {
            _id = id;
            _quality = quality;
            _recommendation = recommendation;
            _comment = comment;
            _patient = patient;
            _doctor = doctor;
        }

        internal static PollDoctor Parse(OleDbDataReader reader)
        {
            AppointmentService appointmentService = new AppointmentService();
            int id = int.Parse(reader[0].ToString());
            int quality = int.Parse(reader[1].ToString());
            int recommendation = int.Parse(reader[2].ToString());
            string comment = reader[3].ToString();
            Person doctor = appointmentService.GetPersonById(reader[4].ToString());
            Person patient = appointmentService.GetPersonById(reader[5].ToString());
            return new PollDoctor(id, quality, recommendation, comment, doctor, patient);
        }
    }
}
