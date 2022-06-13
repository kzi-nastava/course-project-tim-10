using HealthCareInfromationSystem.Core.User;
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
using HealthCareInfromationSystem.Core.PremiseManagment;
using HealthCareInfromationSystem.Core.Appointment.Notification;
using HealthCareInfromationSystem.Core.Appointment;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class RescheduleAppointmentForm : Form
    {
        private AppointmentController appointmentController = new AppointmentController();
        private NotificationController notificationController = new NotificationController();
        private Appointment emergency;
        private string specialisation;
        private string selectedAppointmentId;
        private DateTime selectedRescheduleTime;
        public RescheduleAppointmentForm(Appointment emergency, string specialisation)
        {
            this.emergency = emergency;
            this.specialisation = specialisation;
            InitializeComponent();
            DisplayAppointmentsTable();
        }

        // Adds rows for first five appointments that have the least delay for rescheduling
        // with columns ORIGINAL BEGINNING, DOCTOR, PATIENT, RESCHEDULED BEGINNING, APPOINTMENT ID
        private void DisplayAppointmentsTable()
        {
            dataGridViewAppointments.Rows.Clear();
            foreach(List<string> row in appointmentController.GetRowsForEarliestAppointments(specialisation))
            {
                dataGridViewAppointments.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5]);
            }
        }

        private void BtnReschedule_Click(object sender, EventArgs e)
        {
            if (selectedAppointmentId != "")
            {
                Appointment forRescheduling = appointmentController.GetAppointmentById(selectedAppointmentId);

                Appointment appointment = new Appointment(0, new Person(forRescheduling.Doctor.Id), new Person(emergency.Patient.Id),
                    new Premise(emergency.Premise.Id), forRescheduling.Beginning, forRescheduling.Duration, emergency.Type);
                forRescheduling.Beginning = selectedRescheduleTime;

                appointmentController.Edit(forRescheduling);
                appointmentController.Add(appointment);
                MessageBox.Show("Selected appointment rescheduled to " + selectedRescheduleTime.ToString("dd.MM.yyyy. HH:mm") + ".\nEmergency sucessfully booked instead.", "Success");
                
                notificationController.AddRescheduleNotification(forRescheduling);
                this.Dispose();
            }
        }

        private void DataGridViewAppointments_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewAppointments.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedAppointmentId = dataGridViewAppointments.Rows[e.RowIndex].Cells[5].Value.ToString();
                selectedRescheduleTime = DateTime.Parse(dataGridViewAppointments.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }
    }
}
