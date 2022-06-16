using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.AppointmentRequest
{
    public class AppointmentRequest
    {
        private String _id;
        private String _patientId;
        private String _appointmentId;
        private String _type;
        private String _newDoctorId;
        private String _newBeginning;
        private String _reqDateTime;
        private String _state;
        private String _secretaryId;
        private Person _patient;
        private Appointment _appointment;
        private Person _newDoctor;



        public AppointmentRequest()
        {

        }

        public AppointmentRequest(string id, string patientId, string appointmentId, string type, string newDoctorId = "", string newBeginning = "", string state = "wait")
        {
            _id = id;
            _patientId = patientId;
            _appointmentId = appointmentId;
            _type = type;
            _newDoctorId = newDoctorId;
            _newBeginning = newBeginning;
            _reqDateTime = MyConverter.ToString(DateTime.Now);
            _state = state;
            _secretaryId = "";
        }

        public AppointmentRequest(string id, Person patient, Appointment appointment, string type, Person newDoctor, string newBeginning, string reqDateTime)
        {
            _id = id;
            _patientId = patient.Id.ToString();
            _patient = patient;
            _appointmentId = appointment.Id.ToString();
            _appointment = appointment;
            _type = type;
            _newDoctorId = newDoctor.Id.ToString();
            _newDoctor = newDoctor;
            _newBeginning = newBeginning;
            //_reqDateTime = MyConverter.ToString(DateTime.Now);
            _reqDateTime = reqDateTime;
            _state = "wait";
            _secretaryId = "";
        }

        public String SecretaryId
        {
            get { return _secretaryId; }
            set { _secretaryId = value; }
        }

        public String State
        {
            get { return _state; }
            set { _state = value; }
        }

        public String ReqDateTime
        {
            get { return _reqDateTime; }
            set { _reqDateTime = value; }
        }

        public String NewBeginning
        {
            get { return _newBeginning; }
            set { _newBeginning = value; }
        }

        public String NewDoctorId
        {
            get { return _newDoctorId; }
            set { _newDoctorId = value; }
        }

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String AppointmentId
        {
            get { return _appointmentId; }
            set { _appointmentId = value; }
        }

        public String PatientId
        {
            get { return _patientId; }
            set { _patientId = value; }
        }

        public String ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public Person Patient
        {
            get { return _patient; }
        }

        public Person NewDoctor
        {
            get { return _newDoctor; }
        }

        public Appointment Appointment
        {
            get { return _appointment; }
        }

        public static AppointmentRequest Parse(OleDbDataReader reader)
        {

            int id = int.Parse(reader[0].ToString());
            Person patient = PersonController.LoadOnePerson(Constants.connectionString,
                            "select * from users where id=\"" + reader[1].ToString() + "\"");
            Appointment appointment = AppointmentController.LoadOneAppointment(Constants.connectionString, 
                            "select * from appointments where id=\"" + reader[2].ToString() + "\"");
            string type = reader[3].ToString();
            Person newDoctor = PersonController.LoadOnePerson(Constants.connectionString,
                            "select * from users where id=\"" + reader[4].ToString() + "\"");
            string newBeginning = reader[5].ToString();
            string reqDateTime = reader[6].ToString();
            Console.WriteLine(id.ToString(), patient.Id, appointment.Id, type, newDoctor.Id, newBeginning, reqDateTime);
            return new AppointmentRequest(id.ToString(), patient, appointment, type, newDoctor, newBeginning, reqDateTime);
        }

    }
}
