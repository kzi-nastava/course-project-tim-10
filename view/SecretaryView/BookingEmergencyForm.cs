using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
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
        private string selectedPatientId = "";
        public BookingEmergency()
        {
            InitializeComponent();

        }

        private void FillTable(String query, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            adapter.Fill(table);
            dataGridViewPatients.DataSource = table;
        }

        private void DisplayPatientsTableData()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                FillTable("select id, name, last_name as 'last name', username from users where role=\"patient\"", connection);
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
            foreach (string specialisation in SpecialisationController.LoadSpecialisations(Constants.connectionString, query))
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (selectedPatientId != "" && tbDuration.Text != "")
            {
                try
                {
                    int durationCheck = int.Parse(tbDuration.Text);
                }
                catch
                {
                    MessageBox.Show("Duration in incorrect format.", "Error");
                    return;
                }

                Appointment appointment = new Appointment();
                appointment.Patient = PersonController.LoadOnePerson(Constants.connectionString, $"select * from users where id=\"{selectedPatientId}\"");
                appointment.Premise = PremiseController.LoadOnePremise(Constants.connectionString, $"select * from premises where premises_id=\"{cbPremise.SelectedValue}\"");
                if (cbType.SelectedItem.ToString() == "physical") appointment.Type = Appointment.AppointmentType.physical;
                else appointment.Type = Appointment.AppointmentType.operation;
                appointment.Duration = int.Parse(tbDuration.Text);

                List<string> doctorIds = SpecialisationController.GetDoctorIds(Constants.connectionString, cbSpecialisation.SelectedItem.ToString());
                if (appointment.AssignEmergencySlot(doctorIds))
                {
                    // found doctor and time
                    DialogResult dialogResult = MessageBox.Show("Found available appointment at " + appointment.Beginning.ToString() 
                        + " with doctor " + appointment.Doctor.FirstName + " " + appointment.Doctor.LastName 
                        + "\nConfirm booking?", "Check", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) Console.WriteLine("found doctor and time" + appointment.Doctor.Id + appointment.Beginning.ToString());
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Unable to find available appointment in the next two hours.\nContinue to rescheduling?", "Check", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        RescheduleAppointmentForm rescheduleAppointmentForm = new RescheduleAppointmentForm(appointment);
                        rescheduleAppointmentForm.Show();
                    }
                }

            } else
            {
                MessageBox.Show("Incomplete selection.", "Error");
            }

        }

        private void CbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // If type of appointment set to physical duration is fixed to 15 minutes
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
