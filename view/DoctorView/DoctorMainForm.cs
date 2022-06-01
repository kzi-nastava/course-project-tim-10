using HealthCareInfromationSystem.contollers;
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
		public DoctorMainForm()
		{
			InitializeComponent();
			ShowNotifications();
		}

		private void ShowNotifications()
        {
			try
            {

				string notificationText = NotificationController.GetEmergencyNotifications(Constants.connectionString, utils.LoggedInUser.GetId());
				notificationText += NotificationController.GetRescheduleNotifications(Constants.connectionString, "", utils.LoggedInUser.GetId());
				if (notificationText != "")
				{
					MessageBox.Show(notificationText);
					NotificationController.MarkEmergencyNotificationsAsRecieved(Constants.connectionString, utils.LoggedInUser.GetId());
					NotificationController.MarkRescheduleNotificationsAsRecieved(Constants.connectionString, "", utils.LoggedInUser.GetId());
				}
            } catch (OleDbException)
			{
				Console.WriteLine("Error while recieving notifications.");
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
