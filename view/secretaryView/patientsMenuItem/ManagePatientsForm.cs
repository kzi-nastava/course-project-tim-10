using HealthCareInfromationSystem.contollers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.secretaryView.patientsMenuItem
{
    public partial class ManagePatientsForm : Form
    {
        private string selectedId = "";
        private string selectedUserName = "";

        public ManagePatientsForm()
        {
            InitializeComponent();
        }

        private void ManagePatientsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patientsDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.patientsDataSet.users);
            DisplayData();

        }

        private void DisplayData()
        {
            // Collecting patients data in adapter
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter("select * from users where role=\"patient\"", Constants.connectionString);
            DataSet ds = new DataSet();
            // Filling dataset with values from adapter
            dataAdapter.Fill(ds);
            // Displaying data in gridview
            dataGridViewPatients.DataSource = ds.Tables[0].DefaultView;
        }






        // Field manipulation

        private bool CheckIfFilledFields()
        {
            return this.tbId.Text != ""
            && this.tbName.Text != ""
            && this.tbLastName.Text != ""
            && this.tbUserName.Text != ""
            && this.tbPassword.Text != "";
        }

        private void ClearFields()
        {
            this.tbId.Text = "";
            tbId.Enabled = true;
            this.tbName.Text = "";
            this.tbLastName.Text = "";
            this.tbUserName.Text = "";
            this.tbPassword.Text = "";
            this.cbBlocked.Checked = false;
            labelStatus.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridViewPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            labelStatus.Text = "";

            selectedId = dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
            tbId.Text = selectedId;
            tbId.Enabled = false;

            tbName.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[1].Value.ToString();
            tbLastName.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[2].Value.ToString();
            selectedUserName = dataGridViewPatients.Rows[e.RowIndex].Cells[3].Value.ToString();
            tbUserName.Text = selectedUserName;
            tbPassword.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (bool.TryParse(dataGridViewPatients.Rows[e.RowIndex].Cells[5].Value.ToString(), out bool blocked))
            {
                cbBlocked.Checked = blocked;
                if (blocked == true)
                {
                    cbBlocked.Enabled = false;
                }
                else
                {
                    cbBlocked.Enabled = true;
                }
            }   
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
        }

    }
}
