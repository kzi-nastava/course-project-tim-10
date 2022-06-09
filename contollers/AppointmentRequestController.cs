using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.Core.AppointmentRequest
{
    class AppointmentRequestController
    {
        AppointmentRequestService requestService = new AppointmentRequestService();
        public bool AcceptRequest(string id, string requestType)
        {
            try
            {
                if (requestType == "edit") requestService.AcceptChange(id);
                if (requestType == "delete") requestService.AcceptCancellation(id);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        public bool DeclineRequest(string id)
        {
            try
            {
                requestService.Decline(id);
                return true;
            }
            catch (OleDbException)
            {
                return false;
            }
        }

        public List<AppointmentRequest> GetRequestsForDisplay()
        {
            return requestService.GetRequestsOnWait();
        }

        public static string GetValues(AppointmentRequest request)
        {
            return $"({request.ID}\", \"{request.PatientId}\", \"{request.AppointmentId}\", " +
                   $"\"{request.Type}\", \"{request.NewDoctorId}\", \"{request.NewBeginning}\"," +
                   $" \"{request.ReqDateTime}\", \"{request.State}\", \"{request.SecretaryId}\")";
        }

    }
}
