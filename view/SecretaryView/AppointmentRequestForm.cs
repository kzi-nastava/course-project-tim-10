using HealthCareInfromationSystem.contollers;
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
                    request.Type, request.ReqDateTime);
            }
        }

        private void dataGridViewRequests_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnDecline_Click(object sender, EventArgs e)
        {

        }
    }
}
