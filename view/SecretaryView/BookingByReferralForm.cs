using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class BookingByReferralForm : Form
    {
        private string selectedPatientId = "";
        private string selectedReferralLetterId = "";
        private PatientController patientController = new PatientController();
        private ReferralLetterController referralController = new ReferralLetterController();
        public BookingByReferralForm()
        {
            InitializeComponent();
            DisplayPatientsTableData();
        }

        // Adds rows of patients to dataGridViewPatients 
        // with columns ID, NAME, LAST NAME
        private void DisplayPatientsTableData()
        {
            dataGridViewPatients.Rows.Clear();
            foreach (List<string> row in patientController.GetRowsForPatients())
            {
                dataGridViewPatients.Rows.Add(row[0], row[1], row[2]);
            }
        }
        
        // Adds rows of unused referral letters to dataGridViewReferrals for selected patient
        // with columns ID, DATE CREATED, CREATED BY
        private void DisplayReferralsTableData(string patientId)
        {
            dataGridViewReferrals.Rows.Clear();
            foreach (List<string> row in referralController.GetRowsForPatientsReferrals(patientId))
            {
                dataGridViewReferrals.Rows.Add(row[0], row[1], row[2]);
            }
        }

        // When patient is selected their referral letters are displayed in dataGridViewReferral
        private void DataGridViewPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewReferrals.Rows.Clear();
            selectedReferralLetterId = "";
            if (dataGridViewPatients.Rows[e.RowIndex] != null)
            {
                selectedPatientId = dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
                DisplayReferralsTableData(selectedPatientId);
            }
        }

        private void DataGridViewReferrals_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewReferrals.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedReferralLetterId = dataGridViewReferrals.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }


        private void BtnAssignTime_Click(object sender, EventArgs e)
        {
            if (selectedPatientId != "" && selectedReferralLetterId != "")
            {
                AssignTimeToReferralForm assignTimeToReferralForm = new AssignTimeToReferralForm(selectedReferralLetterId);
                assignTimeToReferralForm.Show();
            }
            
        }
    }
}
