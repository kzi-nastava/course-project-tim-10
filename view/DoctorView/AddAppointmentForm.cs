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
	public partial class AddAppointmentForm : Form
	{
		public AddAppointmentForm()
		{
			InitializeComponent();
			//filling in premises
			Dictionary<string, string> premisePair = PremiseController.LoadPair(Constants.connectionString, "select premises_id, name from premises");
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



		private void SaveBtnClick(object sender, EventArgs e)
		{
			string premiseId = premiseComboBox.SelectedValue.ToString();
			//Console.WriteLine(premiseComboBox.SelectedValue.ToString());
			string patientId = patientComboBox.SelectedValue.ToString();
			string beginning = beginningTextBox.Text;
			string duration = durationTextBox.Text;
			string type = typeComboBox.SelectedItem.ToString();
			//Console.WriteLine(typeComboBox.SelectedItem.ToString());

			//checking if data is correct
			try
			{
				int durationCheck = int.Parse(duration);
				DateTime beginningCheck = DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null);
				if (type == "physical" && durationCheck != 15) {
					MessageBox.Show("Physical can only last 15 minutes.", "Error");
					return;
				}
			}
			catch
			{
				MessageBox.Show("Please check beginning or duration field and enter correct values.", "Error");
				return;
			}

			if (!AppointmentController.IsAvailableAllChecks(beginning, duration, premiseId, patientId)) return;

			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				AppointmentController.AddToBase(patientId, premiseId, LoggedInUser.loggedIn.Id, beginning, duration, type);
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
