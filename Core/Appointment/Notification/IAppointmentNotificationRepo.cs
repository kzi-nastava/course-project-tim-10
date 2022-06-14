 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    interface IAppointmentNotificationRepo : INotificationRepo
    {
        void Add(Appointment appointment);


    }
}
