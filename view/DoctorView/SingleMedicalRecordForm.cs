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
using HealthCareInfromationSystem.contollers;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class SingleMedicalRecordForm : Form
	{
		MedicalRecord MedicalRecord { get; set; }

		public SingleMedicalRecordForm()
		{
			InitializeComponent();
		}

		public SingleMedicalRecordForm(MedicalRecord medical)
		{
			InitializeComponent();
			this.MedicalRecord = medical;
			heightTextBox.Text = MedicalRecord.Height.ToString();
			weightTextBox.Text = MedicalRecord.Weight.ToString();
			diseaseTextBox.Text = MedicalRecord.Disease;
			alergiesTextBox.Text = MedicalRecord.Alergies;
			bloodTypeComboBox.DataSource = Enum.GetNames(typeof(BloodType)).ToArray();
			bloodTypeComboBox.SelectedItem = MedicalRecord.BloodType.ToString();

		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			int id = MedicalRecord.Id;
			string height = heightTextBox.Text;
			string weight = weightTextBox.Text;
			string bloodType = bloodTypeComboBox.SelectedItem.ToString();
			string disease = diseaseTextBox.Text;
			string alergie = alergiesTextBox.Text;
			try
			{
				double heightCheck = double.Parse(height);
				double weightCheck = double.Parse(weight);
			}
			catch
			{
				MessageBox.Show("Please check height and weight fieled.", "Error");
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				MedicalRecordController.EditInBase(MedicalRecord.Id, height, weight, bloodType, disease, alergie);
			}
			
		}

		private void CancelBtnClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
