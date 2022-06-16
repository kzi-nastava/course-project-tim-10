using System;
using System.Collections.Generic;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.Core.Appointment.VacationRequest
{
    class VacationRequestService
    {
        private IVacationRequestRepo requestRepo = new VacationRequestSQL();
        private IAppointmentRepo appointmentRepo = new AppointmentSQL();

        public void Add(VacationRequest request)
        {
            requestRepo.Add(request);
        }

        public void Accept(VacationRequest request)
        {
            request.Status = VacationRequest.RequestStatus.accepted;
            requestRepo.Edit(request);
        }

        public void Decline(VacationRequest request, string declineReason)
        {
            request.Status = VacationRequest.RequestStatus.declined;
            requestRepo.Edit(request);
        }

        public VacationRequest Get(string id)
        {
            return requestRepo.Get(id);
        }

		public List<VacationRequest> GetAllRequestsForDoctor(string id)
		{
            return requestRepo.GetAllRequestsForDoctor(id);
		}


		public List<VacationRequest> GetAllOnWait()
        {
            return requestRepo.GetAll();
        }

        public bool IsDoctorAvailableForTime(DateTime start, DateTime end) {
            List<Appointment> allAppointments = appointmentRepo.LoadAppointmentsForDoctor(LoggedInUser.GetId());
            foreach (Appointment appointment in allAppointments)
            {
                if (IsAppointmentBetween(start, end, appointment)) return false;
            }
            return true;
        }

        private bool IsAppointmentBetween(DateTime start, DateTime end, Appointment appointment) {
            return start < appointment.Beginning && appointment.Beginning < end;
        }



    }

}
