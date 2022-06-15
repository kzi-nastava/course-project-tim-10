using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.VacationRequest
{
    interface IVacationRequestRepo
    {
        void Add(VacationRequest request);
        void Edit(VacationRequest request);

        VacationRequest Get(string id);
        List<VacationRequest> GetAll();

        List<VacationRequest> GetAllRequestsForDoctor(string id);

    }
}
