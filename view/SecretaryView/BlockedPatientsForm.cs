using HealthCareInfromationSystem.contollers;
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
    public partial class BlockedPatientsForm : Form
    {
        private string selectedId = "";
        public BlockedPatientsForm()
        {
            InitializeComponent();
            DisplayTableData();
        }

        private void FillTable(String query, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            adapter.Fill(table);
            dataGridViewBlockedPatients.DataSource = table;
        }

        private void DisplayTableData()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                FillTable("select id, name, last_name as \'last name\', username, blocker from users where role=\"patient\" and blocked=\"true\"", connection);
            }
        }

        // Previews selected patient in fields
        private void DataGridViewBlockedPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedId = dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbId.Text = selectedId;

            if (dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[4].Value.ToString() == "1")
            {
                tbBlocker.Text = "Secretary";
            }
            else if (dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[4].Value.ToString() == "2")
            {
                tbBlocker.Text = "System";
            }
        }

        private void BtnUnblock_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (PatientController.Unblock(selectedId)) {
                    DisplayTableData();
                    labelStatus.Text = "Status: Operation succeeded.";
                } 
                else
                {
                    labelStatus.Text = "Status: Operation fail.";
                }
            }
        }
    }
}
