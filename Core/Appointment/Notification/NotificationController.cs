 
using HealthCareInfromationSystem.repository;
using HealthCareInfromationSystem.utils;
using System.Collections.Generic;
using System.Data.OleDb;

namespace HealthCareInfromationSystem.Core.Appointment.Notification
{
    class NotificationController
    {
        private IAppointmentNotificationRepo emergencyNotifRepo = new EmergencyNotificationSQL();
        private IAppointmentNotificationRepo rescheduleNotifRepo = new RescheduleNotificationSQL();
        private IVacationNotificationRepo vacationNotifiRepo = new VacationNotificationSQL();

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

        public void AddVacationNotification(VacationRequest.VacationRequest request, string reason="")
        {
            vacationNotifiRepo.Add(request, reason);
        }

        public string GetVacationNotifications(string userId)
        {
            return vacationNotifiRepo.GetUnreceived(userId);
        }

        public void MarkVacationNotificationsAsReceived(string userId)
        {
            vacationNotifiRepo.MarkRecieved(userId);
        }

    }
}
