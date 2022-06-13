using HealthCareInfromationSystem.Core.User.Poll;
 
using HealthCareInfromationSystem.Core.User;
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

namespace HealthCareInfromationSystem.view.PatientView
{
    public partial class PollDoctorForm : Form
    {
        private int quality;
        private int recommendation;
        private string comment;
        private Person patient = LoggedInUser.loggedIn;
        private Person doctor;

        PollService pollService = new PollService();


        public PollDoctorForm(Person doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
        }

        private void GetDoctorPollValues()
        {
            quality = GetCheckedRadioButton(qualityRB1, qualityRB2, qualityRB3, qualityRB4, qualityRB5);
            recommendation = GetCheckedRadioButton(recommendRB1, recommendRB2, recommendRB3, recommendRB4, recommendRB5);
            comment = commentTxt.Text;
        }

        private bool ValidInput()
        {
            return (quality != -1) && (recommendation != -1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GetDoctorPollValues();
            if (ValidInput())
                SaveSurveyDoctor();
            else
                MessageBox.Show("Only comment is not required.");
        }
        
        private void SaveSurveyDoctor()
        {
            int id = int.Parse(BaseFunctions.GenerateId("poll_doctor", "ID"));
            PollDoctor pollDoctor = new PollDoctor(id, quality, recommendation, comment, doctor, patient);
            pollService.AddPollDoctor(pollDoctor);
            MessageBox.Show("Poll successfully saved.");
        }

        public static int GetCheckedRadioButton(params RadioButton[] radioButtons)
        {
            foreach (RadioButton button in radioButtons)
                if (button.Checked)
                    return int.Parse(button.Text);
            return -1;
        }
    }
}
