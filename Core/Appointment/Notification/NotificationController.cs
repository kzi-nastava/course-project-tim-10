 
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.utils;
using System.Collections.Generic;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    class NotificationController
    {
        private INotification emergencyNotifRepo = new EmergencyNotificationSQL();
        private INotification rescheduleNotifRepo = new RescheduleNotificationSQL();

        public void AddEmergencyNotification(Appointment appointment)
        {
            emergencyNotifRepo.Add(appointment);
        }

        // Loads all unrecieved notifications' text 
        public string GetEmergencyNotifications(string doctorId)
        {
            return emergencyNotifRepo.GetUnreceived(doctorId);
        }

        public void MarkEmergencyNotificationsAsRecieved(string doctorId)
        {
            emergencyNotifRepo.MarkRecieved(doctorId);
        }


        public void AddRescheduleNotification(Appointment appointment)
        {
            rescheduleNotifRepo.Add(appointment);
        }

        public string GetRescheduleNotifications(string userId)
        {
            return rescheduleNotifRepo.GetUnreceived(userId);
        }

        public void MarkRescheduleNotificationsAsRecieved(string userId)
        {
            rescheduleNotifRepo.MarkRecieved(userId);
        }

    }
}
