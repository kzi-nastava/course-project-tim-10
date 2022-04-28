using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

		}

		private void AllAppointmentsButtonClick(object sender, EventArgs e)
		{
			AllAppointmentsForm allAppointmentsForm = new AllAppointmentsForm();
			allAppointmentsForm.Show();
		}

		private void dateAppoinmentsBtn_Click(object sender, EventArgs e)
		{
			//FutureAppointmentsForm tableFutureAppointments = new FutureAppointmentsForm();
			//tableFutureAppointments.Show();
		}
	}
}
