using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.doctorController;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.Servise;

using HealthCareInfromationSystem.utils;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AddAppointmentForm : Form
	{
		AppointmentController appointmentController = new AppointmentController();
		public AddAppointmentForm()
		{
			InitializeComponent();

			FillPremisseComboBox();

			FillPatientComboBox();

			FillOperationTypeComboBox();
		}

		private void FillPremisseComboBox()
		{
			Dictionary<string, string> premisePair = appointmentController.LoadPremiseNameAndId();
			premiseComboBox.DataSource = new BindingSource(premisePair, null);
			premiseComboBox.DisplayMember = "Value";
			premiseComboBox.ValueMember = "Key";
		}

		private void FillPatientComboBox()
		{
			Dictionary<string, string> patientPair = appointmentController.LoadFullNameAndId("patient");
			patientComboBox.DataSource = new BindingSource(patientPair, null);
			patientComboBox.DisplayMember = "Value";
			patientComboBox.ValueMember = "Key";
		}

		private void FillOperationTypeComboBox()
		{
			foreach (string type in Enum.GetNames(typeof(Appointment.AppointmentType)))
			{
				typeComboBox.Items.Add(type);
				typeComboBox.SelectedItem = type;
			}
		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			string premiseId = premiseComboBox.SelectedValue.ToString();
			string patientId = patientComboBox.SelectedValue.ToString();
			string beginning = beginningTextBox.Text;
			string duration = durationTextBox.Text;
			string type = typeComboBox.SelectedItem.ToString();
			Enum.TryParse(type, out Appointment.AppointmentType typeP);

			if (!IsDurationValid(duration, type)) return;

			if (!IsBeginningValid(beginning)) return;

			Appointment appointment = new Appointment(0, new Person(int.Parse(LoggedInUser.GetId())), new Person(int.Parse(patientId)), new Premise(premiseId),
			DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null), int.Parse(duration), typeP, "");

			if (!appointmentController.IsAppointmentAvailable(appointment)) return;
			SaveChanges(appointment);
		}

		private void SaveChanges(Appointment appointment)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				appointmentController.Add(appointment);
			}
		}

		private bool IsDurationValid(string duration, string type) {
			try
			{
				int durationCheck = int.Parse(duration);
				if (type == "physical" && durationCheck != 15)
				{
					MessageBox.Show("Physical can only last 15 minutes.", "Error");
					return false;
				}
				return true;
			}
			catch
			{
				MessageBox.Show("Please check duration field and enter correct values.", "Error");
				return false;
			}
		}

		private bool IsBeginningValid(string beginning)
		{
			try
			{
				DateTime beginningCheck = DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null);
				return true;
			}
			catch
			{
				MessageBox.Show("Please check beginning field and enter correct values.", "Error");
				return false;
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
