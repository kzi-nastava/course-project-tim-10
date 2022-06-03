using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.Servise;
using HealthCareInfromationSystem.utils;
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
    public partial class AppointmentRequestForm : Form
    {
        private string selectedId = "";
        private string requestType = "";
        private AppointmentRequestController requestController = new AppointmentRequestController();
        public AppointmentRequestForm()
        {
            InitializeComponent();
            DisplayRequestsTable();
        }

        private void DisplayRequestsTable()
        {
            dataGridViewRequests.Rows.Clear();
            foreach (AppointmentRequest request in requestController.GetRequestsForDisplay())
            {
                if (request.NewDoctor != null) dataGridViewRequests.Rows.Add(request.ID, request.PatientId, request.Patient.FirstName + " " + request.Patient.LastName,
                   request.Appointment.Beginning.ToString(), request.Type, request.NewBeginning,
                   request.NewDoctor.FirstName + " " + request.NewDoctor.LastName,
                   request.ReqDateTime);
                else
                {
                    dataGridViewRequests.Rows.Add(request.ID, request.PatientId, request.Patient.FirstName + " " + request.Patient.LastName,
                   request.Appointment.Beginning.ToString(), request.Type, request.NewBeginning,
                   "",
                   request.ReqDateTime);
                }
            }
        }

        private void DataGridViewRequests_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedId = dataGridViewRequests.Rows[e.RowIndex].Cells[0].Value.ToString();
            requestType = dataGridViewRequests.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (requestController.AcceptRequest(selectedId, requestType))
                {
                    labelStatus.Text = "Status: Operation succeeded.";
                    DisplayRequestsTable();     // refresh view
                }
                else
                {
                    labelStatus.Text = "Status: Operation fail.";
                }
            }
        }

        private void BtnDecline_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (requestController.DeclineRequest(selectedId))
                {
                    labelStatus.Text = "Status: Operation succeeded.";
                    DisplayRequestsTable();
                }
                else
                {
                    labelStatus.Text = "Status: Operation fail.";
                }
            }
        }
    }
}
