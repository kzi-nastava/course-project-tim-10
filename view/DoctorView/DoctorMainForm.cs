using HealthCareInfromationSystem.Core.Appointment.Notification;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class DoctorMainForm : Form
	{
		private NotificationController notificationController = new NotificationController();
		public DoctorMainForm()
		{
			InitializeComponent();
			ShowNotifications();
		}

		private void ShowNotifications()
        {
			string notificationText = notificationController.GetEmergencyNotifications(utils.LoggedInUser.GetId());
			notificationText += notificationController.GetRescheduleNotifications(utils.LoggedInUser.GetId());
			notificationText += notificationController.GetVacationNotifications(utils.LoggedInUser.GetId());
			if (notificationText != "")
			{
				MessageBox.Show(notificationText);
				notificationController.MarkEmergencyNotificationsAsRecieved(utils.LoggedInUser.GetId());
				notificationController.MarkRescheduleNotificationsAsRecieved(utils.LoggedInUser.GetId());
				notificationController.MarkVacationNotificationsAsReceived(utils.LoggedInUser.GetId());
			}

		}

		private void AllAppointmentsButtonClick(object sender, EventArgs e)
		{
			AllAppointmentsForm allAppointmentsForm = new AllAppointmentsForm();
			allAppointmentsForm.Show();
		}

		private void DateAppoinmentsBtnClick(object sender, EventArgs e)
		{
			AppointmentsByDateForm appointmentsByDateForm = new AppointmentsByDateForm();
			appointmentsByDateForm.Show();
		}

		private void UnverifiedMedicineBtnClick(object sender, EventArgs e)
		{
			UnverifiedMedicine unverifiedMedicine = new UnverifiedMedicine();
			unverifiedMedicine.Show();
		}
	}
}
