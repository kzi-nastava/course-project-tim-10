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

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AnamnesisInputForm : Form
	{
		Appointment appointment { get; set; }

		public AnamnesisInputForm()
		{
			InitializeComponent();
		}

		public AnamnesisInputForm(Appointment appointment)
		{
			this.appointment = appointment;
			InitializeComponent();
			anamnesisTextBox.Text = appointment.Comment;

		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
