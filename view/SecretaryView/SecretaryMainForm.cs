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
    public partial class SecretaryMainForm : Form
    {
        public SecretaryMainForm()
        {
            InitializeComponent();
        }

        private void ManagePatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManagePatientsForm managePatientsForm = new ManagePatientsForm();
            managePatientsForm.Show();
        }

        private void BlockedPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RequestsForChangeAndCancellationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
