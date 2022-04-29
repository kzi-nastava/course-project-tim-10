﻿using System;
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
    public partial class ManagePatientsForm : Form
    {
        private string selectedId = "";
        private string selectedUsername = "";
        public ManagePatientsForm()
        {
            InitializeComponent();
        }

        private void ManagePatientsForm_Load(object sender, EventArgs e)
        {
            DisplayTableData();
        }

        // GridView Table
        private void FillTable(String query, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            adapter.Fill(table);
            dataGridViewPatients.DataSource = table;
        }

        private void DisplayTableData()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                FillTable("select id, name, last_name, username, password, blocked from users where role=\"patient\"", connection);
            }
        }


        // Displays data from selected patient in fields
        private void dataGridViewPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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


        // Field manipulation

        private bool CheckIfFilledFields()
        {
            return this.tbId.Text != ""
            && this.tbName.Text != ""
            && this.tbLastName.Text != ""
            && this.tbUsername.Text != ""
            && this.label4.Text != "";
        }

        private void ClearFields()
        {
            this.tbId.Text = "";
            tbId.Enabled = true;
            this.tbName.Text = "";
            this.tbLastName.Text = "";
            this.tbUsername.Text = "";
            this.label4.Text = "";
            this.cbBlocked.Checked = false;
            labelStatus.Text = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
