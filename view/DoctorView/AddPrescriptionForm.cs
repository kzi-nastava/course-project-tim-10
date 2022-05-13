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
		private Person patient;

		public AddPrescriptionForm()
		{
			InitializeComponent();
		}

		public AddPrescriptionForm(int id)
		{
			InitializeComponent();
			patientId = id;
			Person patient = PersonController.LoadOnePerson(Constants.connectionString,
							"select * from users where id=\"" + patientId + "\"");
			this.patient = patient;
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
			MedicalRecord medical = MedicalRecordController.LoadMedical(Constants.connectionString,
							"select * from medical_record where patientId=\"" + patientId + "\""); 
			string medicineId = medicineComboBox.SelectedValue.ToString();
			Medicine medicine = MedicineController.LoadOneById(medicineId);
			//string tymeOfConsumption = periodComboBox.SelectedItem.ToString();
			Enum.TryParse(periodComboBox.SelectedItem.ToString(), out Medicine.DrinkingPeriod timeOfConsumption);
			string quantity = quantityTextBox.Text;
			string date = dateTextBox.Text;
			DateTime dateCheck;
			try
			{
				dateCheck = DateTime.ParseExact(date, "dd.MM.yyyy.", null);
			}
			catch
			{
				MessageBox.Show("Please check date field and enter correct values.", "Error");
				return;
			}

			if (medical.IsAlergic(medicine.Ingredients))
			{
				MessageBox.Show("Patient is alergic to an ingredient", "Error");
				return;
			}
			DialogResult dialogResult = MessageBox.Show("Are you sure you want to save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MessageBox.Show("Changes saved.", "Success");
				MedicalPrescription medicalPrescription = new MedicalPrescription(0, medicine, quantity, timeOfConsumption, patient, DateTime.Now, dateCheck);
				MedicalPrescriptionController.SaveToBase(medicalPrescription);
			}

		}

		private void CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
