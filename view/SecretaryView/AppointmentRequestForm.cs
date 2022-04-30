using HealthCareInfromationSystem.contollers;
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
        public AppointmentRequestForm()
        {
            InitializeComponent();
            string query = "select * from appointment_request where state=\"wait\"";
            List<AppointmentRequest> requests = AppointmentRequestController.LoadAppointmentRequests(Constants.connectionString, query);
            foreach (AppointmentRequest request in requests)
            {
                dataGridViewRequests.Rows.Add(request.ID, request.PatientId, request.Patient.FirstName + " " + request.Patient.LastName,
                    request.Appointment.Beginning.ToString(), request.Type, request.NewBeginning,
                    request.NewDoctor.FirstName + " " + request.NewDoctor.LastName,
                    request.ReqDateTime);
            }
        }

        private void dataGridViewRequests_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            selectedId = dataGridViewRequests.Rows[e.RowIndex].Cells[0].Value.ToString();
            requestType = dataGridViewRequests.Rows[e.RowIndex].Cells[4].Value.ToString();
            Console.WriteLine(
                dataGridViewRequests.Rows[e.RowIndex].Cells[0].Value.ToString(),
                dataGridViewRequests.Rows[e.RowIndex].Cells[1].Value.ToString(),
                dataGridViewRequests.Rows[e.RowIndex].Cells[2].Value.ToString(),
                dataGridViewRequests.Rows[e.RowIndex].Cells[3].Value.ToString(),
                dataGridViewRequests.Rows[e.RowIndex].Cells[4].Value.ToString(),
                dataGridViewRequests.Rows[e.RowIndex].Cells[5].Value.ToString(),
                dataGridViewRequests.Rows[e.RowIndex].Cells[6].Value.ToString()
                );
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (AppointmentRequestController.AcceptRequest(selectedId, requestType))
                {
                    labelStatus.Text = "Status: Operation succeeded.";
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
                if (AppointmentRequestController.DeclineRequest(selectedId))
                {
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
