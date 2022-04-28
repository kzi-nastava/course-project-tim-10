﻿using System;
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
			}
			catch
			{
				MessageBox.Show("Please check beginning or duration field and enter correct values.", "Error");
				return;
			}

			//checking if the doctor is available
			if (!AppointmentController.IsAvailable(Constants.connectionString,
				"select * from appointments where doctorId =\"" + LoggedInUser.loggedIn.Id + "\"",
				beginning, duration))
			{
				MessageBox.Show("Doctor has an appointment.", "Error");
				return;
			}

			//checking if the room is available
			if (!AppointmentController.IsAvailable(Constants.connectionString,
			"select * from appointments where premiseId =\"" + premiseId + "\"",
			beginning, duration))
			{
				MessageBox.Show("Premise occupied.", "Error");
				return;
			}

			//checking if the patient is available
			if (!AppointmentController.IsAvailable(Constants.connectionString,
			"select * from appointments where patientId=\"" + patientId + "\"",
			beginning, duration))
			{
				MessageBox.Show("Patient has an appointment.", "Error");
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				//TO DO CHANGE BASE
			}
			

		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
