using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace HealthCareInfromationSystem
{
    public class Appointment
    {
        public enum ATypes
        {
            physical,
            operation
        }

        private String _id;
        private String _patient;
        private String _doctor;
        private String _premise;
        private String _beginning;
        private String _type;
        private String _duration;
        private String _comment;




        public Appointment()
        {
            
        }

        public Appointment(String id, String patient, String doctor, String premise, String beginning, String type, String duration)
        {
            _id = id;
            _patient = patient;
            _doctor = doctor;
            _premise = premise;
            _beginning = beginning;
            _type = type;
            _duration = duration;
            _comment = "";
        }


        public String Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public String Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public String Beginning
        {
            get { return _beginning; }
            set { _beginning = value; }
        }

        public String Doctor
        {
            get { return _doctor; }
            set { _doctor = value; }
        }


        public String Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }

        public String Premise
        {
            get { return _premise; }
            set { _premise = value; }
        }


        public String Id
        {
            get { return _id; }
            set { _id = value; }
        }


        public String Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        internal static Appointment Parse(DataGridViewRow row)
        {
            String id = row.Cells["ID"].Value.ToString();
            String doctor = row.Cells["doctorId"].Value.ToString();
            String patient = row.Cells["patientId"].Value.ToString();
            String premise = row.Cells["premiseId"].Value.ToString();
            String beginning = row.Cells["beginning"].Value.ToString();
            String duration = row.Cells["duration"].Value.ToString();
            String type = row.Cells["type"].Value.ToString();
            String comment = row.Cells["comment"].Value.ToString();
            return new Appointment(id, patient, doctor, premise, beginning, type, duration);

        }



    }
}
