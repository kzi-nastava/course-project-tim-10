using HealthCareInfromationSystem.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.VacationRequest
{
    class VacationRequest
    {
        private int _id;
        private Person _doctor;
        private DateTime _dateSent;
        private DateTime _dateBegin;
        private DateTime _dateEnd;
        private string _reason;
        private RequestStatus _status;

        // For creating new request
        public VacationRequest(Person doctor, DateTime dateBegin, DateTime dateEnd, string reason)
        {
            this.Doctor = doctor;
            this.DateSent = DateTime.Now;
            this.DateBegin = dateBegin;
            this.DateEnd = dateEnd;
            this.Status = RequestStatus.wait;
            this.Reason = reason;
        }

        // For loading from base
        public VacationRequest(int id, Person doctor, DateTime dateSent, DateTime dateBegin, DateTime dateEnd, string reason, RequestStatus status)
        {
            this.Id = id;
            this.Doctor = doctor;
            this.DateSent = dateSent;
            this.DateBegin = dateBegin;
            this.DateEnd = dateEnd;
            this.Status = RequestStatus.wait;
            this.Reason = reason;
            this.Status = status;
        }

        public enum RequestStatus
        {
            accepted, declined, wait
        }

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

        public DateTime DateSent
        {
            get { return _dateSent; }
            set { _dateSent = value; }
        }

        public DateTime DateBegin
        {
            get { return _dateBegin; }
            set { _dateBegin = value; }
        }

        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }

        public RequestStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
