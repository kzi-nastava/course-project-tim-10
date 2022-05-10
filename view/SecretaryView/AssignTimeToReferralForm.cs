using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.view.DoctorView;
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
    public partial class AssignTimeToReferralForm : Form
    {
        private string selectedPatientId;
        private string selectedReferralLetterId;
        public AssignTimeToReferralForm(string patientId, string referralLetterId)
        {
            selectedPatientId = patientId;
            selectedReferralLetterId = referralLetterId;
            InitializeComponent();
            InitializePremiseComboBox();
            InitializeTypeComboBox();
            // TODO InitializeDoctorComboBox();
        }

        private void InitializePremiseComboBox()
        {
            Dictionary<string, string> premisePair = PremiseController.LoadPair(Constants.connectionString, "select premises_id, name from premises");
            cbPremise.DataSource = new BindingSource(premisePair, null);
            cbPremise.DisplayMember = "Value";
            cbPremise.ValueMember = "Key";
        }

        private void InitializeTypeComboBox()
        {
            foreach (string type in Enum.GetNames(typeof(Appointment.AppointmentType)))
            {
                cbType.Items.Add(type);
                cbType.SelectedItem = type;
            }

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
		}

    }
}
