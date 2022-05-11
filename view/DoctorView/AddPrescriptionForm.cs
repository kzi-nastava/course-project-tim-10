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
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.models.entity;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AddPrescriptionForm : Form
	{
		private int patientId;

		public AddPrescriptionForm()
		{
			InitializeComponent();
		}

		public AddPrescriptionForm(int id)
		{
			InitializeComponent();
			this.patientId = id;
			Person patient = PersonController.LoadOnePerson(Constants.connectionString,
							"select * from users where id=\"" + patientId + "\"");
			patientFullNameLabel.Text = patient.FirstName + " " + patient.LastName;

			Dictionary<string, string> medicinePair = MedicineController.LoadPair("select id, name from medicine where isVerified = \"true\" ");
			medicineComboBox.DataSource = new BindingSource(medicinePair, null);
			medicineComboBox.DisplayMember = "Value";
			medicineComboBox.ValueMember = "Key";

			foreach (string type in Enum.GetNames(typeof(Medicine.DrinkingPeriod)))
			{
				periodComboBox.Items.Add(type);
				periodComboBox.SelectedItem = type;
			}
		}

		private void SaveClick(object sender, EventArgs e)
		{
			string doctorId = periodComboBox.SelectedValue.ToString();
			//Console.WriteLine(premiseComboBox.SelectedValue.ToString());
			string specialisation = medicineComboBox.SelectedValue.ToString();
			if (doctorId == "" && specialisation == "")
			{
				MessageBox.Show("Both fields for doctor and specialisation can not be ampty", "Error");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				//ReferralLetterController.AddToBase(patientId, specialisation, doctorId);
			}

		}

		private void CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
