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
	public partial class EdditAppointmentForm : Form
	{
		public string appointmentId { get; }

		public EdditAppointmentForm()
		{
			InitializeComponent();
		}


		public EdditAppointmentForm(string appointmentId)
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
			
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
