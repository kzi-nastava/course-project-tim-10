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

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class PerformExaminationForm : Form
	{
		Appointment appointment { get; set; }

		public PerformExaminationForm()
		{
			InitializeComponent();
		}

		public PerformExaminationForm(Appointment appointment)
		{
			InitializeComponent();
			this.appointment = appointment;
			Console.WriteLine($"id={appointment.Id}, comment={appointment.Comment}");
			anamnesisTextBox.Text = appointment.Comment;

		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				string anamnesis = anamnesisTextBox.Text;
				appointment.Comment = anamnesis;
				AppointmentController.EditAppointmentComment(appointment.Id.ToString(), anamnesis);
				MessageBox.Show("Changes saved.", "Success");
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private void AddPrescriptionBtnClick(object sender, EventArgs e)
		{
			AddPrescriptionForm addPrescriptionForm = new AddPrescriptionForm(appointment.Patient.Id);
			addPrescriptionForm.Show();
		}

		private void EquipmentStateClick(object sender, EventArgs e)
		{
			EquipmentStateForm equipmentStateForm = new EquipmentStateForm(appointment.Premise);
			equipmentStateForm.Show();
		}
	}
}
