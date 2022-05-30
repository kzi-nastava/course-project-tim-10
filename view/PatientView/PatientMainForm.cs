using HealthCareInfromationSystem.view.PatientView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem
{
    public partial class PatientMainForm : Form
    {
        private Form serviceForm;
        public PatientMainForm()
        {
            InitializeComponent();
        }


        private void AppointmentRewiewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new AllAppointmentsForm();
            serviceForm.Show();
        }

        private void CreateAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new AppointmentForm();
            serviceForm.Show();
        }

        private void CreatePriorityAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new PriorityAppointmentForm();
            serviceForm.Show();
        }

        private void AnamnesisReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new AnamnesisReviewForm();
            serviceForm.Show();
        }

        private void SearchDoctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new SearchDoctorForm();
            serviceForm.Show();
        }

    }
}
