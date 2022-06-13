using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using HealthCareInfromationSystem.Core.User;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.MedicalRecord.ReferralLetter
{
    internal class ReferralLetter
    {
        private string id;
        private Person patient;
        private string specialisation;
        private Person doctor;
        private DateTime dateCreated;
        private Person creator;
        private bool used;

        public ReferralLetter(string id, Person patient, string specialisation, Person doctor, DateTime dateCreated, Person creator, bool used)
        {
            this.id = id;
            this.patient = patient;
            this.specialisation = specialisation;
            this.doctor = doctor;
            this.dateCreated = dateCreated;
            this.creator = creator;
            this.used = used;
        }

        public ReferralLetter(Person patient, string specialisation, Person doctor) {
            this.patient = patient;
            this.specialisation = specialisation;
            this.doctor = doctor;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public Person Patient
        {
            get { return patient; }
            set { patient = value; }
        }

        public string Specialisation
        {
            get { return specialisation; }
            set { specialisation = value; }
        }

        public Person Doctor
        {
            get { return doctor; }
            set { doctor = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public bool Used
        {
            get { return used; }
            set { used = value; }
        }

        public Person Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        
        public static ReferralLetter Parse(OleDbDataReader reader)
        {
            string id = reader[0].ToString();
            Person patient = PersonController.LoadOnePerson(Constants.connectionString,
                "select * from users where id=\"" + reader[1].ToString() + "\"");
            string specialisation = reader[2].ToString();
            Person doctor = null;
            if (specialisation == "null")
            {
                doctor = PersonController.LoadOnePerson(Constants.connectionString,
                "select * from users where id=\"" + reader[3].ToString() + "\"");
            }
            DateTime dateCreated = DateTime.Parse(reader[4].ToString());
            Person creator = PersonController.LoadOnePerson(Constants.connectionString,
                "select * from users where id=\"" + reader[5].ToString() + "\"");
            bool used = Boolean.Parse(reader[6].ToString());
            return new ReferralLetter(id, patient, specialisation, doctor, dateCreated, creator, used);
        }

    }
}
