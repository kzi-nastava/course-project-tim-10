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
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AddReferralLetterForm : Form
	{
		MedicalRecordController medicalRecordController = new MedicalRecordController();
		private string patientId;

		public AddReferralLetterForm()
		{
			InitializeComponent();
		}

		public AddReferralLetterForm(string patientId)
		{
			InitializeComponent();
			LoadPatient(patientId);
			FillDoctorComboBox();
			FillSpecialisationComboBox();
		}

		private void FillSpecialisationComboBox()
		{
			List<string> specialisations = medicalRecordController.LoadSpecialisations();
			specialisations.Add("");
			specialisationComboBox.DataSource = specialisations;
			specialisationComboBox.SelectedItem = "";
		}

		private void FillDoctorComboBox()
		{
			Dictionary<string, string> doctorPair = medicalRecordController.LoadFullNameAndId("doctor");
			doctorPair.Add("", "");
			doctorComboBox.DataSource = new BindingSource(doctorPair, null);
			doctorComboBox.DisplayMember = "Value";
			doctorComboBox.ValueMember = "Key";
			doctorComboBox.SelectedIndex = doctorComboBox.FindString("");
		}

		private void LoadPatient(string patientId)
		{
			this.patientId = patientId;
			Person patient = medicalRecordController.GetPersonById(patientId);
			patientFullNameLabel.Text = patient.FirstName + " " + patient.LastName;
		}

		private void SaveClick(object sender, EventArgs e)
		{
			string doctorId = doctorComboBox.SelectedValue.ToString();
			string specialisation = specialisationComboBox.SelectedValue.ToString();

			if (!ValidUserInput(doctorId, specialisation)) return;
			SaveChanges(doctorId, specialisation);

		}

		private void SaveChanges(string doctorId, string specialisation)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				medicalRecordController.Add(patientId, specialisation, doctorId);
			}
		}

		private bool ValidUserInput(string doctorId, string specialisation) {
			if (doctorId == "" && specialisation == "")
			{
				MessageBox.Show("Both fields for doctor and specialisation can not be ampty", "Error");
				return false;
			}
			return true;
		}

		private void CancelClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
