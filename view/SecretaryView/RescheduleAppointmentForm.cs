using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
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
    public partial class RescheduleAppointmentForm : Form
    {
        Appointment emergency;
        public RescheduleAppointmentForm(Appointment emergency)
        {
            this.emergency = emergency;
            InitializeComponent();
            DisplayAppointmentsTable();
        }

        // Adds rows for first five appointments that have the least delay for rescheduling
        // with columns ORIGINAL BEGINNING, DOCTOR, PATIENT, RESCHEDULED BEGINNING
        private void DisplayAppointmentsTable()
        {
            List<KeyValuePair<Appointment,DateTime>> appointments = AppointmentController.SortEarliestToReschedule();
            int i = 0;
            foreach (KeyValuePair<Appointment, DateTime> pair in appointments)
            {
                dataGridViewAppointments.Rows.Add(pair.Key.Beginning.ToString(), pair.Value.ToString(), pair.Key.Duration.ToString() ,pair.Key.Doctor.FirstName + " " + pair.Key.Doctor.LastName, pair.Key.Patient.FirstName + " " + pair.Key.Patient.LastName);
                ++i;
                if (i>5)
                {
                    break;
                }
            }
        }

        private void BtnReschedule_Click(object sender, EventArgs e)
        {

        }
    }
}
