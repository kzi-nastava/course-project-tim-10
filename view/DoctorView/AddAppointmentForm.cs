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

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AddAppointmentForm : Form
	{
		public AddAppointmentForm()
		{
			InitializeComponent();
			//filling in premises
			Dictionary<string, string> premisePair = PremiseController.RetrievePair(Constants.connectionString, "select id, name from premises");
			premiseComboBox.DataSource = new BindingSource(premisePair, null);
			premiseComboBox.DisplayMember = "Value";
			premiseComboBox.ValueMember = "Key";

			//filling in patients
			Dictionary<string, string> patientPair = PersonController.LoadPair(Constants.connectionString, "select id, name, last_name from users");
			patientComboBox.DataSource = new BindingSource(patientPair, null);
			patientComboBox.DisplayMember = "Value";
			patientComboBox.ValueMember = "Key";

			//filling in operation types
			foreach (string type in Enum.GetNames(typeof(Appointment.AppointmentType)))
			{
				typeComboBox.Items.Add(type);
				typeComboBox.SelectedItem = type;
			}

		}



		private void SaveBtn_Click(object sender, EventArgs e)
		{
			

		}

		private void CancelBtn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
