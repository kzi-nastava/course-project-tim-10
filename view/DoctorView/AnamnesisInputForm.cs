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
	public partial class AnamnesisInputForm : Form
	{
		Appointment Appointment { get; set; }

		public AnamnesisInputForm()
		{
			InitializeComponent();
		}

		public AnamnesisInputForm(Appointment appointment)
		{
			InitializeComponent();
			this.Appointment = appointment;
			Console.WriteLine($"id={appointment.Id}, comment={appointment.Comment}");
			anamnesisTextBox.Text = appointment.Comment;

		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				string anamnesis = anamnesisTextBox.Text;
				Appointment.Comment = anamnesis;
				AppointmentController.EditAppointmentComment(Appointment.Id.ToString(), anamnesis);
				MessageBox.Show("Changes saved.", "Success");
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
