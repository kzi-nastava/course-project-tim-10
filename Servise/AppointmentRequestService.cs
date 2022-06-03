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
        AppointmentRequestSQL requestRepo = new AppointmentRequestSQL();
        AppointmentService appointmentService = new AppointmentService();

        public List<AppointmentRequest> GetRequestsOnWait()
        {
            List<AppointmentRequest> requests = new List<AppointmentRequest>();
            foreach (AppointmentRequest request in requestRepo.GetRequests())
            {
                if (request.State == "wait") requests.Add(request);
            }
            return requests;
        }


        public void AcceptChange(string requestId)
        {
            AppointmentRequest request = requestRepo.Get(requestId);
            requestRepo.SetState(request, "accepted");
            Appointment appointment = request.Appointment;
            appointment.Doctor = request.NewDoctor;
            appointment.Beginning = DateTime.ParseExact(request.NewBeginning, "dd.MM.yyyy. HH:mm", null); ;
            appointmentService.EditInBase(appointment);
        }

        public void AcceptCancellation(string requestId)
        {
            AppointmentRequest request = requestRepo.Get(requestId);
            requestRepo.SetState(request, "accepted");
            appointmentService.DeleteInBase(request.Appointment.Id.ToString());
        }

        public void Decline(string requestId)
        {
            AppointmentRequest request = requestRepo.Get(requestId);
            requestRepo.SetState(request, "declined");
        }

    }
}
