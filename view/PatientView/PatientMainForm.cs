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

namespace HealthCareInfromationSystem.view.PatientView
{
    public partial class PatientMainForm : Form
    {

        private Form serviceForm;
        private DateTime notificationTime = MyConverter.ToFullTime("02:00:00");

        private readonly DateTime now = DateTime.Now;
        private List<MedicalPrescription> myPrescriptions;
        private readonly string notificationTitle = "Reminder";

        private void LoadPrescriptions()
        {
            int patientId = LoggedInUser.loggedIn.Id;
            string dateTo = $"DateValue(Replace(Replace(dateTo, \'.\', \'/\', 1, 2), \'.\', \'\'))";
            string todayStr = now.ToString(Constants.DateFmt);
            string today = $"DateValue(Replace(Replace(\"{todayStr}\", \'.\', \'/\', 1, 2), \'.\', \'\'))";

            string executeQuery = $"Select * from medical_prescription where patientId=\"{patientId}\" and {dateTo} >= {today}";
            myPrescriptions = MedicalPrescriptionController.Load(executeQuery);
        }

        public PatientMainForm()
        {
            InitializeComponent();
            LoadPrescriptions();
        }



        private bool ValidInput()
        {
            try
            {
                notificationTime = MyConverter.ToFullTime(notificationTimeTxt.Text);
            }
            catch (System.FormatException)
            {
                return false;
            }
            return true;
        }

        private void SetNotificationTimeButton_Click(object sender, EventArgs e)
        {
            if (ValidInput())
                MessageBox.Show("Notification time successfully updated.");
            else
                MessageBox.Show($"Notification time should be like: {Constants.FullTimeFmt}");
        }

        private bool TimeToUseMedicine(MedicalPrescription prescription)
        {
            DateTime noticeTime = now.AddHours(notificationTime.Hour).AddMinutes(notificationTime.Minute);
            return DateTime.Compare(prescription.TimeTaking, now) > 0 && DateTime.Compare(noticeTime, prescription.TimeTaking) > 0;
        }

        private void CheckNotification()
        {
            foreach (MedicalPrescription prescription in myPrescriptions)
                if (TimeToUseMedicine(prescription))
                {
                    string timeTaking = prescription.TimeTaking.ToString(Constants.TimeFmt);
                    ShowNotification($"You should use {prescription.Medicine.Name} at {timeTaking}");
                }
        }

        private void ShowNotification(string message)
        {
            notify.Visible = true;
            notify.BalloonTipTitle = notificationTitle;
            notify.BalloonTipText = message;
            notify.Icon = SystemIcons.Information;
            notify.ShowBalloonTip(3000);
            timer1.Stop();
        }

        private void PatientMainForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            CheckNotification();
        }

        private void AppointmentReviewToolStripMenuItem_Click(object sender, EventArgs e)
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
