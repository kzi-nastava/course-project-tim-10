﻿using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.Core.AppointmentRequest;
using HealthCareInfromationSystem.Servise;
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
    public partial class AllAppointmentsForm2 : Form
    {
        AppointmentForm appointmentForm;
        Appointment selectedAppointment;
        AppointmentService appointmentService = new AppointmentService();

        private void ShowAppointments()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string queryString = "select * from appointments where patientId=\"" + LoggedInUser.loggedIn.Id + "\"";
                OleDbCommand command = new OleDbCommand(queryString, connection);

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                appointmentsGrid.DataSource = dt;
                connection.Close();
            }
        }
        public AllAppointmentsForm2()
        {
            InitializeComponent();
            ShowAppointments();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            appointmentForm = new AppointmentForm();
            appointmentForm.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
                MessageBox.Show("You have not selected appointment.");
            else
            {
                appointmentForm = new AppointmentForm(selectedAppointment);
                appointmentForm.Show();
            }
        }

        private bool ChangeableAppointment()
        {
            DateTime now = DateTime.Now;
            DateTime appDate = selectedAppointment.Beginning;
            return now.AddDays(2).CompareTo(appDate) <= 0;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string state;
            if (ChangeableAppointment())
            {
                DeleteAppointment(selectedAppointment);
                state = "accepted";
                MessageBox.Show("You have successfully deleted appointment.");
            }
            else
            {
                state = "wait";
                MessageBox.Show("Delete request has been sent.");
            }
            AppointmentRequest request = DeleteAppointmentRequest(state);
            InsertNewRequest(request);
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

        private void InsertNewRequest(AppointmentRequest req)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"insert into appointment_request values (\"{req.ID}\", \"{req.PatientId}\", \"{req.AppointmentId}\", " +
                    $"\"{req.Type}\", \"{req.NewDoctorId}\", \"{req.NewBeginning}\", \"{req.ReqDateTime}\", \"{req.State}\", \"{req.SecretaryId}\")";

                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void DeleteAppointment(Appointment app)
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                string query = $"delete from appointments where ID = \"{app.Id}\"";
                OleDbCommand command = new OleDbCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private AppointmentRequest DeleteAppointmentRequest(string appState)
        {
            string id = BaseFunctions.GenerateId("appointment_request", "request_id");
            string patientId = LoggedInUser.loggedIn.Id.ToString();
            string appointmentId = selectedAppointment.Id.ToString();
            string type = "delete";
            return new AppointmentRequest(id, patientId, appointmentId, type, state: appState);
        }

        private void PollButton_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
                MessageBox.Show("You have not selected appointment.");
            else
            {
                PollDoctorForm pollDoctorForm = new PollDoctorForm(selectedAppointment.Doctor);
                pollDoctorForm.Show();
            }
        }
    }
}
