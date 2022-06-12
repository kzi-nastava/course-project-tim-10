using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class BookingEmergency : Form
    {
        private SpecialisationController specialisationController = new SpecialisationController();
        private AppointmentController appointmentController = new AppointmentController();
        private NotificationController notificationController = new NotificationController();
        private string selectedPatientId = "";
        private PatientController patientController = new PatientController();
        public BookingEmergency()
        {
            InitializeComponent();

        }

        private void DisplayPatientsTableData()
        {
            dataGridViewPatients.Rows.Clear();
            foreach (List<string> row in patientController.GetRowsForPatients())
            {
                dataGridViewPatients.Rows.Add(row[0], row[1], row[2]);
            }
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

        private void InitializeSpecialisationComboBox()
        {
            string query = "select distinct name from specialisations";
            foreach (string specialisation in specialisationController.LoadSpecialisations(Constants.connectionString, query))
            {
                cbSpecialisation.Items.Add(specialisation);
                cbSpecialisation.SelectedItem = specialisation;
            }
        }

        private void BookingEmergency_Load(object sender, EventArgs e)
        {
            DisplayPatientsTableData();
            InitializeSpecialisationComboBox();
            InitializeTypeComboBox();
            InitializePremiseComboBox();

        }

        private void DataGridViewPatients_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedPatientId = dataGridViewPatients.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private bool CheckDurationField()
        {
            try
            {
                int durationCheck = int.Parse(tbDuration.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Duration in incorrect format.", "Error");
                return false;
            }
        }

        private bool CheckSelectedPatient()
        {
            if (selectedPatientId != "") return true;
            else
            {
                MessageBox.Show("Patient must be selected.");
                return false;
            }
        }

        private string GetConfirmationDialogText(Appointment appointment)
        {
            return "Found available appointment at " + appointment.Beginning.ToString()
                        + " with doctor " + appointment.Doctor.FirstName + " " + appointment.Doctor.LastName
                        + "\nConfirm booking?";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CheckSelectedPatient() && CheckDurationField())
            {
                Appointment appointment = new Appointment(0, null, new Person(selectedPatientId), new Premise(cbPremise.SelectedValue.ToString()), DateTime.Now, int.Parse(tbDuration.Text), cbType.SelectedItem.ToString() == "physical" ? Appointment.AppointmentType.physical : Appointment.AppointmentType.operation);
                
                if (appointmentController.BookEmergency(appointment, cbSpecialisation.SelectedItem.ToString()))
                {
                    // Found doctor and time
                    DialogResult dialogResult = MessageBox.Show(GetConfirmationDialogText(appointment), "Check", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // TODO
                        // appointmentController.Add(appointment);
                        AppointmentController.AddEmergencyToBase(appointment);
                        MessageBox.Show("Emergency booked.", "Success");
                        notificationController.AddEmergencyNotification(appointment);
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Unable to find available appointment in the next two hours.\nContinue to rescheduling?", "Check", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        RescheduleAppointmentForm rescheduleAppointmentForm = new RescheduleAppointmentForm(appointment, cbSpecialisation.SelectedItem.ToString());
                        rescheduleAppointmentForm.Show();
                    }
                }

            }
        }

        private void CbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // If type of appointment set to physical duration is set to 15 minutes
            if (cbType.SelectedItem.ToString() == Enum.GetName(typeof(Appointment.AppointmentType), Appointment.AppointmentType.physical))
            {
                tbDuration.Text = "15";
                tbDuration.Enabled = false;
            }
            else
            {
                tbDuration.Enabled = true;
            }
        }
    }
}
