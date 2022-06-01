using HealthCareInfromationSystem.contollers;
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
    public partial class SearchDoctorForm : Form
    {
        // Theese 3 attributes represent search criteria
        private string firstName;
        private string lastName;
        private string specialisation;

        private string sortCriteria;
        private Person doctor;

        private void InitializeSpecialisations()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                connection.Open();
                string query = $"select distinct name from specialisations";
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    specialisationsBox.Items.Add(reader[0].ToString());
            }
        }

        public SearchDoctorForm()
        {
            InitializeComponent();
            InitializeSpecialisations();
        }

        private void GetSearchData()
        {
            firstName = firstNameTxt.Text.ToString();
            lastName = lastNameTxt.Text.ToString();
            specialisation = (string) specialisationsBox.SelectedItem;
        }

        private bool ValidSearchData()
        {
            return firstName.Equals("") && lastName.Equals("") && specialisation is null;
        }

        private string CreateDoctorsQuery()
        {
            string fNameQuery = firstName.Equals("") ? "" : $" and name=\"{firstName}\"";
            string lNameQuery = lastName.Equals("") ? "" : $" and last_name=\"{lastName}\"";
            string specQuery = (specialisation is null) ? "" :
                $" and id in (Select doctors from specialisations where name=\"{specialisation}\")";

            string query = $"Select * from users where role=\"doctor\"" + fNameQuery + lNameQuery + specQuery;
            return query;
        }

        private void ShowDoctors()
        {
            string query = CreateDoctorsQuery();
            BaseFunctions.FillDataGridView(query, doctorsGrid);
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("You must enter at least one search criteria.");
        }

        private void ShowDoctorsBtn_Click(object sender, EventArgs e)
        {
            GetSearchData();
            if (!ValidSearchData())
                ShowDoctors();
            else
                ShowErrorMessage();
        }

        private string GetColumnName()
        {
            switch (sortCriteria)
            {
                case "First name":
                    return "name";
                case "Last name":
                    return "last_name";
                case "Specialisation":
                    return "id";
                default: 
                    return "id";
            }
        }

        private void SortDoctors()
        {
            string columnName = GetColumnName();
            DataGridViewColumn criteria = doctorsGrid.Columns[columnName];
            ListSortDirection sortType = ListSortDirection.Ascending;
            doctorsGrid.Sort(criteria, sortType);
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            sortCriteria = (string) criteriaBox.SelectedItem;
            if (!(sortCriteria is null))
                SortDoctors();
            else
                MessageBox.Show("You must choose sort criteria.");
        }

        private void CreateAppointmentBtn_Click(object sender, EventArgs e)
        {
            if (doctor != null)
            {
                PriorityAppointmentForm priorityForm = new PriorityAppointmentForm(doctor);
                priorityForm.Show();
            }
            else
                MessageBox.Show("You must choose doctor.");
        }

        private void DoctorsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = doctorsGrid.Rows[e.RowIndex];
                string doctorId = row.Cells["id"].Value.ToString();
                doctor = PersonController.SearchPerson(doctorId);
                MessageBox.Show("Doctor selected.");
            }
        }


    }
}
