 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    interface INotification
    {
        void Add(Appointment appointment);
        string GetUnreceived(string userId);
        void MarkRecieved(string userId);

    }
}
