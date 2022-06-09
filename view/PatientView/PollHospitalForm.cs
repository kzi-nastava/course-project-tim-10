using HealthCareInfromationSystem.Core.Poll;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
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
    public partial class PollHospitalForm : Form
    {
        private int quality;
        private int cleanliness;
        private int impression;
        private int recommendation;
        private string comment;
        private Person patient = LoggedInUser.loggedIn;

        PollService pollService = new PollService();


        public PollHospitalForm()
        {
            InitializeComponent();
        }

        private void GetHospitalPollValues()
        {
            quality = GetCheckedRadioButton(qualityRB1, qualityRB2, qualityRB3, qualityRB4, qualityRB5);
            cleanliness = GetCheckedRadioButton(cleanRB1, cleanRB2, cleanRB3, cleanRB4, cleanRB5);
            impression = GetCheckedRadioButton(impressionRB1, impressionRB2, impressionRB3, impressionRB4, impressionRB5);
            recommendation = GetCheckedRadioButton(recommendRB1, recommendRB2, recommendRB3, recommendRB4, recommendRB5);
            comment = commentTxt.Text;
        }

        private bool ValidInput()
        {
            return (quality != -1) && (cleanliness != -1) && (impression != -1) && (recommendation != -1);
        }

        private void SavePollHospital()
        {
            
            int id = int.Parse(BaseFunctions.GenerateId("poll_hospital", "ID"));
            PollHospital pollHospital = new PollHospital(id, quality, cleanliness, impression, recommendation, comment, patient);
            pollService.AddPollHospital(pollHospital);
            MessageBox.Show("Poll successfully saved.");
        }

        private void SaveButton_Click_1(object sender, EventArgs e)
        {
            GetHospitalPollValues();
            if (ValidInput())
                SavePollHospital();
            else
                MessageBox.Show("Only comment is not required.");
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
