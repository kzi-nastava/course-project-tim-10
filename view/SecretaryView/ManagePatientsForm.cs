using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.users;
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
using static HealthCareInfromationSystem.models.users.Person;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class ManagePatientsForm : Form
    {
        private string selectedId = "";
        private string selectedUsername = "";
        private PatientController patientController = new PatientController();
        public ManagePatientsForm()
        {
            InitializeComponent();
        }

        private void ManagePatientsForm_Load(object sender, EventArgs e)
        {
            DisplayTableData();
        }

        private void DisplayTableData()
        {
            dataGridViewPatients.Rows.Clear();
            foreach (List<string> row in patientController.GetRowsForPatients())
            {
                dataGridViewPatients.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
            }
        }

        // Field manipulation
        // 

        // Displays data from selected patient in fields
        private void DataGridViewPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedId = dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbId.Text = selectedId;
                tbId.Enabled = false;

                tbName.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbLastName.Text = dataGridViewPatients.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedUsername = dataGridViewPatients.Rows[e.RowIndex].Cells[3].Value.ToString();
                tbUsername.Text = selectedUsername;
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
        }

        private bool CheckIfFilledFields()
        {
            return this.tbId.Text != ""
            && this.tbName.Text != ""
            && this.tbLastName.Text != ""
            && this.tbUsername.Text != ""
            && this.tbPassword.Text != "";
        }

        private void ClearFields()
        {
            this.tbId.Text = "";
            tbId.Enabled = true;
            this.tbName.Text = "";
            this.tbLastName.Text = "";
            this.tbUsername.Text = "";
            this.tbPassword.Text = "";
            this.cbBlocked.Checked = false;
            labelStatus.Text = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private bool FieldCheck()
        {
            if (!CheckIfFilledFields())
            {
                labelStatus.Text = "Status: Incomplete fields.";
                return false;
            }
            if (patientController.CheckIfExistsById(this.tbId.Text) && selectedId != this.tbId.Text)
            {
                labelStatus.Text = "Status: User exists under assigned Id.";
                return false;
            }
            if (patientController.CheckIfExistsByUsername(this.tbUsername.Text) && selectedUsername != this.tbUsername.Text)
            {
                labelStatus.Text = "Status: User exists under assigned Username.";
                return false;
            }
            return true;
        }

        private void BtnAddNew_Click(object sender, EventArgs e)
        {
            if (!FieldCheck()) return;

            int blocker = 0;
            if (this.cbBlocked.Checked)
            {
                blocker = 1;
            }
            Person patient = new Person(int.Parse(this.tbId.Text), this.tbName.Text, this.tbLastName.Text, Roles.patient, tbPassword.Text, this.cbBlocked.Checked, blocker, tbUsername.Text);
            if (patientController.Create(patient))
            {
                ClearFields();
                labelStatus.Text = "Status: Operation succeeded.";
                DisplayTableData();
            }
            else labelStatus.Text = "Status: Operation fail.";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!FieldCheck()) return;

            int blocker = 0;
            if (this.cbBlocked.Checked)
            {
                blocker = 1;
            }
            Person patient = new Person(int.Parse(this.tbId.Text), this.tbName.Text, this.tbLastName.Text, Roles.patient, tbPassword.Text, this.cbBlocked.Checked, blocker, tbUsername.Text);
            if (patientController.Update(patient)) 
            {
                labelStatus.Text = "Status: Operation succeeded.";
                DisplayTableData();
            }
            else
            {
                labelStatus.Text = "Status: Operation fail.";
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (patientController.Delete(selectedId))
                {
                    ClearFields();
                    labelStatus.Text = "Status: Operation succeeded.";
                    DisplayTableData();
                }

            }
        }
    }
}
