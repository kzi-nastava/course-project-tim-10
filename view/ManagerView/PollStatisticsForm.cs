using HealthCareInfromationSystem.Core.User;
using HealthCareInfromationSystem.Core.User.Poll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class PollStatisticsForm : Form
    {
        private PollService pollService = new PollService();

        public PollStatisticsForm()
        {
            InitializeComponent();
        }

        private void FIllTables()
        {
            dataGridView1.DataSource = pollService.LoadAllPollsHospital();
            dataGridView2.DataSource = pollService.LoadAllPollsDoctor();
        }

        private void PollStatisticsForm_Load(object sender, EventArgs e)
        {
            FIllTables();
            HospitalPollStatistics();
            DoctorPollStatistics();
            ShowBestAndWorstDoctors();
        }

        private void HospitalPollStatistics()
        {
            label1.Text = "Average for quality: " + pollService.GetAverageForHospitalPollItem("quality");
            label2.Text = "Average for cleanliness: " + pollService.GetAverageForHospitalPollItem("cleanliness");
            label3.Text = "Average for impression: " + pollService.GetAverageForHospitalPollItem("impression");
            label4.Text = "Average for recommendation: " + pollService.GetAverageForHospitalPollItem("recommendation");

            label1.Text += ". (mark, number of marks):";
            label2.Text += ". (mark, number of marks):";
            label3.Text += ". (mark, number of marks):";
            label4.Text += ". (mark, number of marks):";

            for (int i = 1; i < 6; i++)
            {
                label1.Text += $" ({i}, {pollService.GetCountOfMarksForHospitalItem(i.ToString(), "quality")})";
                label2.Text += $" ({i}, {pollService.GetCountOfMarksForHospitalItem(i.ToString(), "cleanliness")})";
                label3.Text += $" ({i}, {pollService.GetCountOfMarksForHospitalItem(i.ToString(), "impression")})";
                label4.Text += $" ({i}, {pollService.GetCountOfMarksForHospitalItem(i.ToString(), "recommendation")})";
            }
        }

        private void DoctorPollStatistics()
        {
            label5.Text = pollService.GetDoctorPollStatistics();
        }

        private void ShowBestAndWorstDoctors()
        {
            label6.Text = "Best marked doctors\n";
            label7.Text = "Worst marked doctors\n";

            List<KeyValuePair<Person, float>> doctorsWithAverageMarks = pollService.GetDoctorsWithAverageMarks();

            for (int i = 0; i < 3; i++)
            {
                label6.Text += $"{doctorsWithAverageMarks[i].Key.FirstName} {doctorsWithAverageMarks[i].Key.LastName}: {doctorsWithAverageMarks[i].Value}\n";

                label7.Text += $"{doctorsWithAverageMarks[doctorsWithAverageMarks.Count - i - 1].Key.FirstName} {doctorsWithAverageMarks[doctorsWithAverageMarks.Count - i - 1].Key.LastName}: {doctorsWithAverageMarks[doctorsWithAverageMarks.Count - i - 1].Value}\n";
            }
        }
    }
}
