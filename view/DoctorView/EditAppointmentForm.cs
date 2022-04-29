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
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class EditAppointmentForm : Form
	{
		public string appointmentId { get; }

		public EditAppointmentForm()
		{
			InitializeComponent();
		}


		public EditAppointmentForm(string appointmentId)
		{
			InitializeComponent();
			this.appointmentId = appointmentId;
			Appointment appointment = AppointmentController.LoadOneAppointment(Constants.connectionString, "select * from appointments where id=\"" + appointmentId + "\"");
			//filling in premises
			Dictionary<string, string> premisePair = PremiseController.LoadPair(Constants.connectionString, "select premises_id, name from premises");
			premiseComboBox.DataSource = new BindingSource(premisePair, null);
			premiseComboBox.DisplayMember = "Value";
			premiseComboBox.ValueMember = "Key";
			Console.WriteLine(appointment.Premise.Name);
			premiseComboBox.SelectedIndex = premiseComboBox.FindString(appointment.Premise.Name);

			//filling in patients
			Dictionary<string, string> patientPair = PersonController.LoadPair(Constants.connectionString, "select id, name, last_name from users");
			patientComboBox.DataSource = new BindingSource(patientPair, null);
			patientComboBox.DisplayMember = "Value";
			patientComboBox.ValueMember = "Key";
			patientComboBox.SelectedIndex = patientComboBox.FindString(appointment.Patient.FirstName + " " + appointment.Patient.LastName);

			//filling in operation types
			typeComboBox.DataSource = Enum.GetNames(typeof(Appointment.AppointmentType)).ToArray();
			typeComboBox.SelectedItem = appointment.Type.ToString();

			//filling beginning
			beginningTextBox.Text = appointment.Beginning.ToString();

			//filling duration
			durationTextBox.Text = appointment.Duration.ToString();
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
				if (type == "physical" && durationCheck != 15)
				{
					MessageBox.Show("Physical can only last 15 minutes.", "Error");
					return;
				}
			}
			catch
			{
				MessageBox.Show("Please check beginning or duration fild and enter correct values.", "Error");
				return;
			}

			//checking if the doctor is available
			if (!AppointmentController.IsAvailable(Constants.connectionString,
				"select * from appointments where doctorId=\"" + LoggedInUser.loggedIn.Id + "\" and not id=\"" + appointmentId + "\"",
				beginning, duration))
			{
				MessageBox.Show("Doctor has an appointment.", "Error");
				return;
			}

			//checking if the room is available
			if (!AppointmentController.IsAvailable(Constants.connectionString,
			"select * from appointments where premiseId=\"" + premiseId + "\" and not id=\"" + appointmentId + "\"",
			beginning, duration))
			{
				MessageBox.Show("Premise occupied.", "Error");
				return;
			}

			//checking if the patient is available
			if (!AppointmentController.IsAvailable(Constants.connectionString,
			"select * from appointments where patientId=\"" + patientId + "\" and not id=\"" + appointmentId + "\"",
			beginning, duration))
			{
				MessageBox.Show("Patient has an appointment.", "Error");
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				AppointmentController.EditInBase(appointmentId, patientId, premiseId, LoggedInUser.loggedIn.Id, beginning, duration, type);
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
