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
using HealthCareInfromationSystem.Servise;
namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AllAppointmentsForm : Form, IAllApointments
	{
		AppointmentService appointmentService = new AppointmentService();
		public AllAppointmentsForm()
		{
			InitializeComponent();
			//AssociateAndRaiseViewEvents();
			FillView();
		}

		

		public event EventHandler AddNewEvent;
		public event EventHandler EditEvent;
		public event EventHandler DeleteEvent;
		public event EventHandler CancelEvent;

		private void FillView()
		{
			//List<Appointment> appointments = AppointmentController.LoadAppointments(Constants.connectionString, "select * from appointments where doctorId=\"" + LoggedInUser.loggedIn.Id + "\"");
			List<Appointment> appointments = appointmentService.LoadAppointmentsForDoctor(LoggedInUser.GetId());
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
			
			if (OneRowSelected())
			{
				EditAppointmentForm edditAppointmentForm = new EditAppointmentForm(GetSelectedAppointmentId());
				edditAppointmentForm.Show();
			}
			
		}

		private void DeleteButtonClick(object sender, EventArgs e)
		{
			if (OneRowSelected())
			{
				ApproveDelete();
			}

		}

		private void ApproveDelete()
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				appointmentService.DeleteInBase(GetSelectedAppointmentId());
				//AppointmentController.Delete(GetSelectedAppointmentId());
			}
		}

		private bool OneRowSelected() {
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1) return true;
			else
			{
				MessageBox.Show("Please select ONLY ONE row.", "Error");
				return false;
			}
		}

		private void CancleButtonClick(object sender, EventArgs e)
		{
			Close();
		}

		private void TableAppointments_Load(object sender, EventArgs e)
		{

		}


		private string GetSelectedAppointmentId()
		{
			return dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
		}

		public void SetPetListBindingSource(BindingSource petList)
		{
			throw new NotImplementedException();
		}
	}
}
