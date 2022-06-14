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
    public partial class PollHospitalStatisticsForm : Form
    {
        private PollService pollService = new PollService();

        public PollHospitalStatisticsForm()
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

        }
    }
}
