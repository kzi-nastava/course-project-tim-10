using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.doctorController;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
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
        private ReferralLetter referralLetter;
        private doctorController.AppointmentController appointmentController = new doctorController.AppointmentController();
        private ReferralLetterController referralController = new ReferralLetterController();
        public AssignTimeToReferralForm(string referralLetterId)
        {
            referralLetter = referralController.GetById(referralLetterId);
            InitializeComponent();
            InitializePremiseComboBox();
            InitializeTypeComboBox();
            InitializeDoctorTextBox();
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

        private void InitializeDoctorTextBox()
        {
            // Doctor is selected by given specialization
            if (referralLetter.Specialisation == null)
            {
                tbDoctor.Text = referralLetter.Doctor.FirstName + " " + referralLetter.Doctor.LastName;
            }
            // Otherwise doctor is chosen clicks button for saving assignment

        }

        private bool CheckBeginningField()
        {
            try
            {
                int durationCheck = int.Parse(tbDuration.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Beginning or duration in incorrect format.", "Error");
                return false;
            }
        }

        private bool CheckDurationField()
        {
            try
            {
                DateTime beginningCheck = DateTime.ParseExact(tbBeginning.Text, "dd.MM.yyyy. HH:mm", null);
                return true;
            }
            catch
            {
                MessageBox.Show("Beginning or duration in incorrect format.", "Error");
                return false;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string premiseId = cbPremise.SelectedValue.ToString();
            string type = cbType.SelectedItem.ToString();
            Enum.TryParse(type, out Appointment.AppointmentType parsedType);

            if (!CheckDurationField() || !CheckBeginningField()) return;

            if (referralLetter.Doctor != null)
            {
                Appointment appointment = new Appointment(0, new Person(referralLetter.Doctor.Id), new Person(referralLetter.Patient.Id), new Premise(premiseId),
                    DateTime.ParseExact(tbBeginning.Text, "dd.MM.yyyy. HH:mm", null), int.Parse(tbDuration.Text), parsedType, "");
                if (!appointmentController.IsAppointmentAvailable(appointment)) return;
            }

            DialogResult dialogResult = MessageBox.Show("Confirm?", "Check", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Appointment appointment = new Appointment(0, new Person(referralLetter.Doctor.Id), new Person(referralLetter.Patient.Id), new Premise(premiseId),
                                    DateTime.ParseExact(tbBeginning.Text, "dd.MM.yyyy. HH:mm", null), int.Parse(tbDuration.Text), parsedType, "");
                appointmentController.Add(appointment);
                referralController.SetUsedTrue(referralLetter);
                MessageBox.Show("Changes saved.", "Success");
                this.Dispose();
            }
        }

        private void CbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // If type of appointment set to physical duration is fixed to 15 minutes
            if (cbType.SelectedItem.ToString() == Enum.GetName(typeof(Appointment.AppointmentType), Appointment.AppointmentType.physical))
            {
                tbDuration.Text = "15";
                tbDuration.Enabled = false;
            } else
            {
                tbDuration.Enabled = true;
            }

        }
    }
}
