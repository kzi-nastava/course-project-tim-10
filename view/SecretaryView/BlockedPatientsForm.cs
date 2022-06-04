using HealthCareInfromationSystem.contollers;
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
    public partial class BlockedPatientsForm : Form
    {
        private string selectedId = "";
        private PatientController patientController = new PatientController();
        public BlockedPatientsForm()
        {
            InitializeComponent();
            DisplayTableData();
        }

        private void DisplayTableData()
        {
            dataGridViewBlockedPatients.Rows.Clear();
            foreach (List<string> row in patientController.GetRowsForBlockedPatients())
            {
                dataGridViewBlockedPatients.Rows.Add(row[0], row[1], row[2], row[5]);
            }
        }

        // Previews selected patient in fields
        private void DataGridViewBlockedPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedId = dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbId.Text = selectedId;

                if (dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[3].Value.ToString() == "1")
                {
                    tbBlocker.Text = "Secretary";
                }
                else if (dataGridViewBlockedPatients.Rows[e.RowIndex].Cells[3].Value.ToString() == "2")
                {
                    tbBlocker.Text = "System";
                }
            }
        }

        private void BtnUnblock_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (patientController.Unblock(selectedId)) {
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
