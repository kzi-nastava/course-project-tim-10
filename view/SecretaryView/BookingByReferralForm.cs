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

        private void FillPatientsTable(String query, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            adapter.Fill(table);
            dataGridViewPatients.DataSource = table;
        }


        private void DisplayPatientsTableData()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                FillPatientsTable("select id, name, last_name as \'last name\', username from users where role=\"patient\" and blocked=\"false\"", connection);
            }
        }
        
        private void DisplayReferralsTableData(string patientId)
        {
            string query = $"select * from referral_letter where patientId=\"{patientId}\" and used=\"false\"";
            List<ReferralLetter> referralLetters = ReferralLetterController.LoadReferalLetters(Constants.connectionString, query);
            foreach (ReferralLetter referralLetter in referralLetters)
            {
                if (referralLetter.Doctor == null) dataGridViewReferrals.Rows.Add(referralLetter.Id, referralLetter.DateCreated.ToString(), referralLetter.Specialisation);
                else
                {
                    dataGridViewReferrals.Rows.Clear();
                    dataGridViewReferrals.Rows.Add(referralLetter.Id, referralLetter.DateCreated.ToString(), referralLetter.Doctor.FirstName + " " + referralLetter.Doctor.LastName);
                }
            }
        }

        private void DataGridViewReferrals_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewReferrals.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedReferralLetterId = dataGridViewReferrals.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

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

        private void BtnAssignTime_Click(object sender, EventArgs e)
        {
            if (selectedPatientId != "" && selectedReferralLetterId != "")
            {
                AssignTimeToReferralForm assignTimeToReferralForm = new AssignTimeToReferralForm(selectedPatientId, selectedReferralLetterId);
                assignTimeToReferralForm.Show();
            }
            
        }
    }
}
