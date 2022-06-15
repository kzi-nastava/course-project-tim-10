using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.VacationRequest
{
    class VacationRequestService
    {
        private IVacationRequestRepo requestRepo = new VacationRequestSQL();

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

    }

}
