using HealthCareInfromationSystem.Core.Appointment.VacationRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class VacationRequestForm : Form
    {
        private VacationRequestController requestController = new VacationRequestController();
        private string selectedRequestId;
        public VacationRequestForm()
        {
            InitializeComponent();
            InitializeActionComboBox();
            DisplayRequestsTable();
        }

        private void InitializeActionComboBox()
        {
            lblReason.Hide();
            cbAction.Items.Add("Accept");
            cbAction.Items.Add("Decline");
            cbAction.SelectedItem = "Accept";
        }

        private void DisplayRequestsTable()
        {
            dataGridViewRequests.Rows.Clear();
            foreach (List<string> row in requestController.GetRowsForRequests())
            {
                dataGridViewRequests.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
            }
        }

        private void DataGridViewRequests_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewRequests.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedRequestId = dataGridViewRequests.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else
            {
                selectedRequestId = "";
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (CheckIfRequestSelected() && CheckReasonInput())
            {
                if (cbAction.SelectedItem.ToString() == "Accept") requestController.Accept(selectedRequestId);
                else requestController.Decline(selectedRequestId, tbDeclineReason.ToString());
                MessageBox.Show("Action successful.");
                DisplayRequestsTable();
            }
        }

        private bool CheckIfRequestSelected()
        {
            if (selectedRequestId != "") return true;
            else MessageBox.Show("No vacation request selected. Please select one.");
            return false;
        }

        private bool CheckReasonInput()
        {
            if (tbDeclineReason.Text != "" || cbAction.SelectedItem.ToString() == "Accept") return true;
            else MessageBox.Show("Input for decline reason is unfilled. Please provide a reason.");
            return false;
        }

        private void CbAction_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbAction.SelectedItem.ToString() == "Decline")
            {
                lblReason.Show();
                tbDeclineReason.Enabled = true;
            }
            else
            {
                lblReason.Hide();
                tbDeclineReason.Enabled = false;
            }
        }
    }
}
