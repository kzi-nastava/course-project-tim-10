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
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class AppointmentsByDateForm : Form
	{
		AppointmentService appointmentService = new AppointmentService();
		SheduleAppointmentService sheduleAppointmentService = new SheduleAppointmentService();
		public AppointmentsByDateForm()
		{
			InitializeComponent();
		}

		private void SearchBtnClick(object sender, EventArgs e)
		{
			string inputDate = dateTextBox.Text;
			try
			{
				DateTime date = DateTime.ParseExact(inputDate, "dd.MM.yyyy.", null);
				dataGridView1.Rows.Clear();
				dataGridView1.Refresh();
				FillTable(inputDate);
			}
			catch
			{
				MessageBox.Show("Please check date entry.", "Error");
			}

		}

		private void FillTable(string inputDate)
		{
			List<Appointment> appointments = sheduleAppointmentService.LoadAppointmentsForDoctorAtDate(inputDate);
			foreach (Appointment appointment in appointments)
			{
				dataGridView1.Rows.Add(appointment.Premise.Name, appointment.Patient.FirstName, appointment.Patient.LastName,
									appointment.Beginning, appointment.Duration, appointment.Type, appointment.Id, appointment.Patient.Id);

			}
		}

		private void MoreInfoBtnClick(object sender, EventArgs e)
		{
			if (OneRowSelected())
			{
				string patientId = GetSelectedAppointmentPatientId();
				MedicalRecord medical = sheduleAppointmentService.GetMedicalRecordByPatient(patientId);
				SingleMedicalRecordForm medicalRecordForm = new SingleMedicalRecordForm(medical);
				medicalRecordForm.Show();
			}
		}

		private void PerformeExaminationBtnClick(object sender, EventArgs e)
		{
			if (OneRowSelected())
			{
				Appointment appointment = appointmentService.GetAppointmentById(GetSelectedAppointmentId());
				PerformExaminationForm anamnesisInputForm = new PerformExaminationForm(appointment);
				anamnesisInputForm.Show();
			}
		}

		private void CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}

		private string GetSelectedAppointmentId()
		{
			return dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
		}

		private string GetSelectedAppointmentPatientId()
		{
			return dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
		}

		private void ReferralLetterClick(object sender, EventArgs e)
		{
			if (OneRowSelected())
			{
				string patientId = GetSelectedAppointmentPatientId();
				AddReferralLetterForm addReferralLetter = new AddReferralLetterForm(patientId);
				addReferralLetter.Show();
			}
			
		}

		private bool OneRowSelected()
		{
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1) return true;
			else
			{
				MessageBox.Show("Please select ONLY ONE row.", "Error");
				return false;
			}
		}
	}
}
