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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    switch (servicesBox.SelectedIndex)
        //    {
        //        case 0:
        //            serviceForm = new AllAppointmentsForm();
        //            serviceForm.Show();
        //            break;
        //        case 1:
        //            serviceForm = new AppointmentForm();
        //            serviceForm.Show();
        //            break;
        //        default:
        //            MessageBox.Show("Niste odabrali uslugu!");
        //            break;
        //    }
        //}

        //private void servicesBox_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void appointmentRewiewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new AllAppointmentsForm();
            serviceForm.Show();
        }

        private void createAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new AppointmentForm();
            serviceForm.Show();
        }

        private void createPriorityAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceForm = new PriorityAppointmentForm();
            serviceForm.Show();
        }
    }
}
