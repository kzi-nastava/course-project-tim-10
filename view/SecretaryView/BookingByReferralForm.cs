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
        public BookingByReferralForm()
        {
            InitializeComponent();
            DisplayPatientsTableData();
        }

        // Adds rows of non-blocked patients to dataGridViewPatients 
        // with columns ID, NAME, LAST NAME
        private void DisplayPatientsTableData()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = "select id, name, last_name as \'last name\', username from users where role=\"patient\" and blocked=\"false\"";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                dataGridViewPatients.DataSource = table;
            }
        }
        
        // Adds rows of unused referral letters to dataGridViewReferrals for selected patient
        // with columns ID, DATE CREATED, CREATED BY
        private void DisplayReferralsTableData(string patientId)
        {
            string query = $"select * from referral_letter where patientId=\"{patientId}\" and used=\"false\"";
            List<ReferralLetter> referralLetters = ReferralLetterController.LoadAll(Constants.connectionString, query);

            dataGridViewReferrals.Rows.Clear();
            foreach (ReferralLetter referralLetter in referralLetters)
            {
                dataGridViewReferrals.Rows.Add(referralLetter.Id, referralLetter.DateCreated.ToString(), referralLetter.Creator.FirstName + " " + referralLetter.Creator.LastName);
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
