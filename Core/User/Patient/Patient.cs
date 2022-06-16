using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using HealthCareInfromationSystem.Core.Appointment;

namespace HealthCareInfromationSystem.Core.User.Patient
{
	public class Patient : Person
	{
        private MedicalRecord.MedicalRecord _medicalRecord;
        private List<Appointment.Appointment> _myAppointments;
        //private List<MedicalPrescription> _medicalPrescriptions;

        //public List<MedicalPrescription> MedicalPrescriptions
        //{
        //    get { return _medicalPrescriptions; }
        //    set { _medicalPrescriptions = value; }
        //}


        public List<Appointment.Appointment> MyAppointments
        {
            get { return _myAppointments; }
            set { _myAppointments = value; }
        }


        public MedicalRecord.MedicalRecord MedicalRecord
        {
            get { return _medicalRecord; }
            set { _medicalRecord = value; }
        }



        public Patient() : base() { }
		public Patient(int id, string name, string lastName, Roles role,
					  string password, bool blocked, int blocker, string username) : base(id, name, lastName, role,
						  password, blocked, blocker, username){ }
	}
}
