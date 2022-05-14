using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
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
    public partial class RescheduleAppointmentForm : Form
    {
        Appointment emergency;
        string selectedAppointmentId;
        Dictionary<int, string> appointmentRescheduleTime = new Dictionary<int, string>();
        List<String> doctorIds;
        public RescheduleAppointmentForm(Appointment emergency, List<String> doctorIds)
        {
            this.emergency = emergency;
            this.doctorIds = doctorIds;
            InitializeComponent();
            DisplayAppointmentsTable();
        }

        // Adds rows for first five appointments that have the least delay for rescheduling
        // with columns ORIGINAL BEGINNING, DOCTOR, PATIENT, RESCHEDULED BEGINNING
        private void DisplayAppointmentsTable()
        {
            List<KeyValuePair<Appointment,DateTime>> appointments = AppointmentController.SortEarliestToReschedule(doctorIds);
            int i = 0;
            foreach (KeyValuePair<Appointment, DateTime> pair in appointments)
            {
                appointmentRescheduleTime[pair.Key.Id] = pair.Value.ToString("dd.MM.yyyy. HH:mm");
                dataGridViewAppointments.Rows.Add(pair.Key.Beginning.ToString(), pair.Key.Duration.ToString(), pair.Value.ToString(), pair.Key.Doctor.FirstName + " " + pair.Key.Doctor.LastName, pair.Key.Patient.FirstName + " " + pair.Key.Patient.LastName, pair.Key.Id.ToString());
                ++i;
                if (i>5)
                {
                    break;
                }
            }
        }

        private void BtnReschedule_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId != "")
            {
                Appointment forRescheduling = AppointmentController.LoadOneAppointment(Constants.connectionString, $"select * from appointments where id=\"{selectedAppointmentId}\"");
                AppointmentController.EditInBase(forRescheduling.Id.ToString(), forRescheduling.Patient.Id.ToString(), forRescheduling.Premise.Id, forRescheduling.Doctor.Id, appointmentRescheduleTime[forRescheduling.Id], forRescheduling.Duration.ToString(), forRescheduling.Type.ToString());
                AppointmentController.AddToBase(emergency.Patient.Id.ToString(), emergency.Premise.Id, forRescheduling.Doctor.Id, forRescheduling.Beginning.ToString("dd.MM.yyyy. HH:mm"), forRescheduling.Duration.ToString(), emergency.Type.ToString());
                MessageBox.Show("Appointment at " + forRescheduling.Beginning.ToString("dd.MM.yyyy. HH:mm") + " rescheduled to " + appointmentRescheduleTime[forRescheduling.Id] + ".\nEmergency sucessfully booked instead.", "Success");
                // TODO Send notifications
            }
        }

        private void DataGridViewAppointments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAppointments.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedAppointmentId = dataGridViewAppointments.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}
