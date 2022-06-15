using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    interface IVacationNotificationRepo : INotificationRepo
    {
        void Add(VacationRequest.VacationRequest request, string reason);
    }
}
