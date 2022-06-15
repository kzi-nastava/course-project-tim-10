using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HealthCareInfromationSystem.Core.Appointment.VacationRequest;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class VacationRequestForm : Form
	{
		VacationRequestController vacationRequestController = new VacationRequestController();
		public VacationRequestForm()
		{
			InitializeComponent();
			FillTable();
		}

		private void FillTable()
		{
			List<VacationRequest> vacationRequests = vacationRequestController.GetAllRequestsForDoctor(LoggedInUser.GetId());
			foreach (VacationRequest vacationRequest in vacationRequests)
			{
				dataGridView1.Rows.Add(vacationRequest.DateSent.ToString("dd.MM.yyyy"), vacationRequest.DateBegin.ToString("dd.MM.yyyy"), vacationRequest.DateEnd.ToString("dd.MM.yyyy"), vacationRequest.Status, vacationRequest.Reason);
			}
		}

		private void AddButtonClick(object sender, EventArgs e)
		{
			AddVacationRequestForm addVacationRequest = new AddVacationRequestForm();
			addVacationRequest.Show();

		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
