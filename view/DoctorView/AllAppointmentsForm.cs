using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.utils;
namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AllAppointmentsForm : Form
	{
		public AllAppointmentsForm()
		{
			InitializeComponent();
			List<Appointment> appointments = AppointmentController.LoadAppointments(Constants.connectionString, "select * from appointments where doctorId=\"" + LoggedInUser.loggedIn.Id + "\"");
			Console.WriteLine(appointments.Count);
			foreach (Appointment appointment in appointments)
			{
				dataGridView1.Rows.Add(appointment.Premise.Name, appointment.Patient.FirstName, appointment.Patient.LastName,
									appointment.Beginning, appointment.Duration, appointment.Type, appointment.Id);

			}
		}

		private void AddButtonClick(object sender, EventArgs e)
		{
			AddAppointmentForm addAppointmentForm = new AddAppointmentForm();
			addAppointmentForm.Show();
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1)
			{

				EdditAppointmentForm edditAppointmentForm = new EdditAppointmentForm(GetSelectedAppointmentId());
				edditAppointmentForm.Show();
			}
			else
			{
				MessageBox.Show("Please select ONLY ONE row for editing.", "Error");
			}
		}

		private void DeleteButtonClick(object sender, EventArgs e)
		{
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1)
			{

				DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Check", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					//Console.WriteLine(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
					MessageBox.Show("Changes saved.", "Success");
					AppointmentController.DeleteFromBase(GetSelectedAppointmentId());
				}

			}
			else
			{
				MessageBox.Show("Please select ONLY ONE row for deliting.", "Error");
			}
		}

		private void CancleButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void TableAppointments_Load(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private string GetSelectedAppointmentId()
		{
			return dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
		}
	}
}
