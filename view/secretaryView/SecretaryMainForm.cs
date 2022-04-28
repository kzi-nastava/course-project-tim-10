using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.secretaryView
{
    public partial class SecretaryMainForm : Form
    {
        public SecretaryMainForm()
        {
            InitializeComponent();
        }

        private void managePatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            patientsMenuItem.ManagePatientsForm managePatientsForm = new patientsMenuItem.ManagePatientsForm();
            managePatientsForm.Show(); 
        }
    }
}
