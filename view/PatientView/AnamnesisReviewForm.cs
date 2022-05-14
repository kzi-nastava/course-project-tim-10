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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.PatientView
{
    public partial class AnamnesisReviewForm : Form
    {
        OleDbConnection connection;

        List<Appointment> appointments;
        Appointment selectedAppointment;
        MedicalRecord medicalRecord;
        Person patient;
        string keyWord;


        private void FillMedicalRecord()
        {
            firstNameLabel.Text += patient.FirstName;
            lastNameLabel.Text += patient.LastName;
            heightLabel.Text += medicalRecord.Height;
            weightLabel.Text += medicalRecord.Weight;
            bloodTypeLabel.Text += medicalRecord.BloodType;
            diseaseLabel.Text += medicalRecord.Disease;
            alergiesLabel.Text += medicalRecord.Alergies;
        }


        private void FillAppointments()
        {
            string queryString = "select * from appointments where patientId=\"" + patient.Id + "\"";
            OleDbCommand command = new OleDbCommand(queryString, connection);
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            appointmentsGrid.DataSource = dt;
            connection.Close();
        }


        private void FillFormData()
        {
            FillMedicalRecord();
            FillAppointments();
        }


        private void InitializeAttributes()
        {
            connection = new OleDbConnection(Constants.connectionString);
            patient = LoggedInUser.loggedIn;
            string medicalQuery = $"Select * from medical_record where patientId = \"{patient.Id}\"";
            medicalRecord = MedicalRecordController.LoadMedical(Constants.connectionString, medicalQuery);
            string appointmentQuery = $"Select * from appointments where patientId = \"{patient.Id}\"";
            appointments = AppointmentController.LoadAppointments(Constants.connectionString, appointmentQuery);
        }


        public AnamnesisReviewForm()
        {
            InitializeComponent();
            InitializeAttributes();
            FillFormData();
        }


        private void ShowAnamnesisButton_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
                MessageBox.Show("You have not selected appointment.");
            else
                MessageBox.Show(selectedAppointment.Comment);
        }

        private void AppointmentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.appointmentsGrid.Rows[e.RowIndex];
                selectedAppointment = Appointment.Parse(row);
                MessageBox.Show("Appointment selected.");
            }
        }


        private bool ValidInput()
        {
            keyWord = keyWordTxt.Text;
            int numWords = keyWord.Split(' ').Length;
            if (numWords != 1)
                return false;       // can only be one word

            return keyWord != "";   // keyWord can not be empty string
        }


        private void SearchByKeyWord()
        {
            for (int i = 0; i < appointments.Count; i++)
                if (appointments[i].Comment.Contains(keyWord))      // anamnesis is the same as comment
                    appointmentsGrid.Rows[i].Selected = true;
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (ValidInput())
                SearchByKeyWord();
            else
                MessageBox.Show("Invalid keyword input.");
        }


        private string GetColumnName(string criteria)
        {
            switch (criteria)
            {
                case "Date":
                    return "beginning";
                case "Doctor":
                    return "doctorId";
                default:
                    return "doctorId";
            }
        }


        private void SortBy(string criteria)
        {
            string columnName = GetColumnName(criteria);
            appointmentsGrid.Sort(appointmentsGrid.Columns[columnName], ListSortDirection.Ascending);
        }



        private void SortButton_Click(object sender, EventArgs e)
        {
            string criteria = (string) sortByBox.SelectedItem;
            if (criteria.Equals(""))
                MessageBox.Show("You must choose sorting criteria.");
            else
                SortBy(criteria);
        }


    }
}
