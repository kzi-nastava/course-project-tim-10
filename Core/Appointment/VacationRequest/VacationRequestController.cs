using HealthCareInfromationSystem.Core.Appointment.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.VacationRequest
{
    class VacationRequestController
    {
        private VacationRequestService requestService = new VacationRequestService();
        private NotificationController notificationController = new NotificationController();

        public void Accept(string requestId)
        {
            VacationRequest request = requestService.Get(requestId);
            requestService.Accept(request);
            notificationController.AddVacationNotification(request);
        }

		public List<VacationRequest> GetAllRequestsForDoctor(string id)
		{
			return requestService.GetAllRequestsForDoctor(id);
		}

		public void Decline(string requestId, string declineReason)
        {
            VacationRequest request = requestService.Get(requestId);
            requestService.Decline(request, declineReason);
            notificationController.AddVacationNotification(request, declineReason);
        }

        public List<List<string>> GetRowsForRequests()
        {
            List<List<string>> rows = new List<List<string>>();
            foreach (VacationRequest request in requestService.GetAllOnWait())
            {
                rows.Add(GetTableRow(request));

            }
            return rows;
        }

        private static List<string> GetTableRow(VacationRequest request)
        {
            List<string> row = new List<string>();
            row.Add(request.Id.ToString());
            row.Add(request.DateSent.ToString("dd.MM.yyyy. HH:mm"));
            row.Add(request.Doctor.FirstName + " " + request.Doctor.LastName);
            row.Add(request.DateBegin.ToString("dd.MM.yyyy. HH:mm"));
            row.Add(request.DateEnd.ToString("dd.MM.yyyy. HH:mm"));
            row.Add(request.Reason);
            return row;
        }

        public bool IsDoctorAvailableForTime(DateTime start, DateTime end)
        {
            return requestService.IsDoctorAvailableForTime(start, end);
        }

        public void Add(VacationRequest request)
        {
            requestService.Add(request);
        }


    }
}
