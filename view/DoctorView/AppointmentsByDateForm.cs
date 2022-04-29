using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AppointmentsByDateForm : Form
	{
		public AppointmentsByDateForm()
		{
			InitializeComponent();
		}

		private void SearchBtnClick(object sender, EventArgs e)
		{
			string inputDate = dateTextBox.Text;
			try
			{
				DateTime date = DateTime.ParseExact(inputDate, "dd.MM.yyyy.", null);
				dataGridView1.Rows.Clear();
				dataGridView1.Refresh();
				List<Appointment> appointments = AppointmentController.LoadAppointmentsForDate(Constants.connectionString,
				"select * from appointments where doctorId=\"" + LoggedInUser.loggedIn.Id + "\"", inputDate);
				Console.WriteLine(appointments.Count);
				foreach (Appointment appointment in appointments)
				{
					dataGridView1.Rows.Add(appointment.Premise.Name, appointment.Patient.FirstName, appointment.Patient.LastName,
										appointment.Beginning, appointment.Duration, appointment.Type, appointment.Id);

				}
			}
			catch
			{
				MessageBox.Show("Please check date entry.", "Error");
			}

		}

		private void MoreInfoBtnClick(object sender, EventArgs e)
		{
			
		}

		private void AmnesisBtnClick(object sender, EventArgs e)
		{
			
		}

		private void CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private string GetSelectedAppointmentId()
		{
			return dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
		}
	}
}
