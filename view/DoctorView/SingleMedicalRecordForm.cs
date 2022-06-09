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
using HealthCareInfromationSystem.doctorController;
using HealthCareInfromationSystem.Core.MedicalRecord;
using HealthCareInfromationSystem.Core.MedicalPrescription;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class SingleMedicalRecordForm : Form
	{
		MedicalRecordController medicalRecordController = new MedicalRecordController();
		MedicalRecord MedicalRecord { get; set; }


		public SingleMedicalRecordForm()
		{
			InitializeComponent();
		}

		public SingleMedicalRecordForm(MedicalRecord medical)
		{
			InitializeComponent();
			this.MedicalRecord = medical;
			FillFields();

		}

		private void FillFields()
		{
			heightTextBox.Text = MedicalRecord.Height.ToString();
			weightTextBox.Text = MedicalRecord.Weight.ToString();
			diseaseTextBox.Text = MedicalRecord.Disease;
			alergiesTextBox.Text = MedicalRecord.Alergies;
			bloodTypeComboBox.DataSource = Enum.GetNames(typeof(BloodType)).ToArray();
			bloodTypeComboBox.SelectedItem = MedicalRecord.BloodType.ToString();
		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			string height = heightTextBox.Text;
			string weight = weightTextBox.Text;
			string bloodType = bloodTypeComboBox.SelectedItem.ToString();
			string disease = diseaseTextBox.Text;
			string alergie = alergiesTextBox.Text;
			Enum.TryParse(bloodType, out BloodType bloodTyp);

			if (!IsInputValid(height, weight)) return;

			MedicalRecord medicalRecord = new MedicalRecord(MedicalRecord.Id, double.Parse(height), double.Parse(weight), bloodTyp, disease, alergie);
			SaveChanges(medicalRecord);

		}

		private bool IsInputValid(string height, string weight) {
			try
			{
				double heightCheck = double.Parse(height);
				double weightCheck = double.Parse(weight);
				return true;
			}
			catch
			{
				MessageBox.Show("Please check height and weight fieled.", "Error");
				return false;
			}
		}

		private void SaveChanges(MedicalRecord medicalRecord)
		{
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				medicalRecordController.Edit(medicalRecord);
			}
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			Close();
		}
	}
}
