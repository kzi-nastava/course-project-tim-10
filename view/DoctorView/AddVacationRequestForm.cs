using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.Core.Appointment.VacationRequest;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AddVacationRequestForm : Form
	{
		VacationRequestController vacationRequestController = new VacationRequestController();
		public AddVacationRequestForm()
		{
			InitializeComponent();
		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			if (!IsValidDateFormat()) return;
			if (!IsValidReason()) return;

			DateTime beginning = DateTime.ParseExact(beginningTextBox.Text, "dd.MM.yyyy.", null);
			DateTime ending = DateTime.ParseExact(endingTextBox.Text, "dd.MM.yyyy.", null);

			if (!IsDoctorAvailable(beginning, ending)) return;
			if (!IsValidSendingTime(beginning)) return;
			if (isUrgentCheckBox.Checked && !IsUrgentValid(beginning, ending)) return;

			VacationRequest.RequestStatus requestStatus = VacationRequest.RequestStatus.wait;
			if (isUrgentCheckBox.Checked) requestStatus = VacationRequest.RequestStatus.accepted;

			VacationRequest vacationRequest = new VacationRequest(LoggedInUser.loggedIn, beginning, ending, reasonTextBox.Text, requestStatus);
			SaveChanges(vacationRequest);
		}

		private void SaveChanges(VacationRequest vacationRequest)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				vacationRequestController.Add(vacationRequest);
			}
		}

		private bool IsDoctorAvailable(DateTime beginning, DateTime ending) {
			if (!vacationRequestController.IsDoctorAvailableForTime(beginning, ending))
			{
				MessageBox.Show("You can't make a request, you have booked appointments", "Error");
				return false;
			}
			return true;
		}

		private bool IsUrgentValid(DateTime beginning, DateTime ending)
		{
			if ((ending - beginning).TotalDays > 5)
			{
				MessageBox.Show("Urgent requests can't be longer than 10 days.", "Error");
				return false;
			}
			return true;
		}

		private bool IsValidSendingTime(DateTime beginning)
		{
			if ((beginning - DateTime.Now).TotalDays < 2) {
				MessageBox.Show("Please enter a date at least 2 days in advance.", "Error");
				return false;
			}
			return true;
		}

		private bool IsValidReason()
		{
			if (reasonTextBox.Text == "") {
				MessageBox.Show("Please input a reason.", "Error");
				return false;
			}
			return true;
		}

		private bool IsValidDateFormat()
		{
			try
			{
				DateTime beginningCheck = DateTime.ParseExact(beginningTextBox.Text, "dd.MM.yyyy.", null);
				DateTime endingCheck = DateTime.ParseExact(endingTextBox.Text, "dd.MM.yyyy.", null);
				return true;
			}
			catch
			{
				MessageBox.Show("Please check beginning and ending field and enter correct values.", "Error");
				return false;
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
