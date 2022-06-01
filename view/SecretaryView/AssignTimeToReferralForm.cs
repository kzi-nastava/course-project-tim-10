using HealthCareInfromationSystem.contollers;
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
        public AssignTimeToReferralForm(string referralLetterId)
        {
            referralLetter = ReferralLetterController.LoadOne(Constants.connectionString, $"select * from referral_letter where ID={referralLetterId}");
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string premiseId = cbPremise.SelectedValue.ToString();
            string beginning = tbBeginning.Text;
            string duration = tbDuration.Text;
            string type = cbType.SelectedItem.ToString();

            // Checking if input is correct
            try
            {
                int durationCheck = int.Parse(duration);
                DateTime beginningCheck = DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null);
            }
            catch
            {
                MessageBox.Show("Beginning or duration in incorrect format.", "Error");
                return;
            }

            // Checking if the room is available
            if (!AppointmentController.IsAvailable(Constants.connectionString,
            "select * from appointments where premiseId =\"" + premiseId + "\"",
            beginning, duration))
            {
                MessageBox.Show("Premise occupied.", "Error");
                return;
            }

            // If doctor is already assigned 
            if (referralLetter.Specialisation == "null")
            {
                // Checking if the doctor is available
                if (!AppointmentController.IsAvailable(Constants.connectionString,
                    "select * from appointments where doctorId =\"" + referralLetter.Doctor.Id + "\"",
                    beginning, duration))
                {
                    MessageBox.Show("Doctor is unavailable.", "Error");
                    return;
                }
            } else
            {
                // Assign any doctor with given specialisation that is available at given time
                referralLetter.AssignDoctor(beginning, duration);

                // No doctors available
                if (referralLetter.Doctor == null )
                {
                    tbDoctor.Text = "";
                    if (SpecialisationController.GetDoctorIds(Constants.connectionString, referralLetter.Specialisation).Count == 0)
                    {
                        MessageBox.Show("No doctor exists with given specialisation.", "Error");
                        return;
                    }
                    MessageBox.Show("No doctors available at given time.", "Error");
                    return;
                } else
                {
                    tbDoctor.Text = referralLetter.Doctor.FirstName + " " + referralLetter.Doctor.LastName;
                }
            }

            // Checking if the patient is available
            if (!AppointmentController.IsAvailable(Constants.connectionString,
            "select * from appointments where patientId=\"" + referralLetter.Patient.Id + "\"",
            beginning, duration))
            {
                MessageBox.Show("Patient already has an appointment.", "Error");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Confirm?", "Check", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Changes saved.", "Success");
                Enum.TryParse(type, out Appointment.AppointmentType typeP);
                Appointment appointment = new Appointment(0, new Person(referralLetter.Doctor.Id), new Person(referralLetter.Patient.Id), 
                    new Premise(premiseId), DateTime.ParseExact(beginning, "dd.MM.yyyy. HH:mm", null), int.Parse(duration), typeP, "");
                AppointmentController.Add(appointment);
                ReferralLetterController.MarkUsed(referralLetter);
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
