using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem
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

    }
}
