using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Servise
{
    class AppointmentRequestService
    {
        IAppointmentRequestRepo requestRepo = new AppointmentRequestSQL();
        AppointmentService appointmentService = new AppointmentService();

        public void SaveToBase(AppointmentRequest request)
        {
            requestRepo.Add(request);
        }

        public List<AppointmentRequest> GetRequestsOnWait()
        {
            return requestRepo.GetRequests();
        }


        public void AcceptChange(string requestId)
        {
            AppointmentRequest request = requestRepo.Get(requestId);
            requestRepo.SetState(request, "accepted");
            Appointment appointment = request.Appointment;
            appointment.Doctor = request.NewDoctor;
            appointment.Beginning = DateTime.ParseExact(request.NewBeginning, "dd.MM.yyyy. HH:mm", null); ;
            appointmentService.Edit(appointment);
        }

        public void AcceptCancellation(string requestId)
        {
            AppointmentRequest request = requestRepo.Get(requestId);
            requestRepo.SetState(request, "accepted");
            appointmentService.Delete(request.Appointment.Id.ToString());
        }

        public void Decline(string requestId)
        {
            AppointmentRequest request = requestRepo.Get(requestId);
            requestRepo.SetState(request, "declined");
        }

    }
}
