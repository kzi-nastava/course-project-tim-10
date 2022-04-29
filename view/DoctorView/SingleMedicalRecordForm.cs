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

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class SingleMedicalRecordForm : Form
	{
		MedicalRecord medicalRecord { get; set; }

		public SingleMedicalRecordForm()
		{
			InitializeComponent();
		}

		public SingleMedicalRecordForm(MedicalRecord medical)
		{
			InitializeComponent();
			this.medicalRecord = medical;
			heightTextBox.Text = medicalRecord.GetHeight().ToString();
			weightTextBox.Text = medicalRecord.GetWeight().ToString();
			diseaseTextBox.Text = medicalRecord.GetDisease();
			alergiesTextBox.Text = medicalRecord.GetAlergies();
			bloodTypeComboBox.DataSource = Enum.GetNames(typeof(BloodType)).ToArray();
			bloodTypeComboBox.SelectedItem = medicalRecord.GetBloodType().ToString();

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
