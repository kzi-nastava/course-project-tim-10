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
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.models.users;
using HealthCareInfromationSystem.utils;
using HealthCareInfromationSystem.contollers;
using static HealthCareInfromationSystem.models.entity.Appointment;


namespace HealthCareInfromationSystem.view.PatientView
{
    public partial class PriorityAppointmentForm : Form
    {
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataReader reader;

        Person doctor;
        DateTime priorityDay;
        DateTime lowerLimit;
        DateTime upperLimit;
        DateTime endDay;
        string priority;

        Appointment appointment;


        public PriorityAppointmentForm()
        {
            InitializeComponent();
            InitializeAppointment();
            FillDoctorsComboBox();
        }


        private void InitializeAppointment()
        {
            appointment = new Appointment();
            appointment.Id = int.Parse(BaseFunctions.GenerateId("appointments", "id"));
            appointment.Patient = LoggedInUser.loggedIn;
            appointment.Premise = PremiseController.SearchPremise("2");
            appointment.Type = Appointment.AppointmentType.physical;
            appointment.Duration = 15;
            appointment.Comment = "";
        }


        private Appointment CreatePossibleAppointment(DateTime datetime, Person doctor)
        {
            Appointment newApp = new Appointment();
            newApp.Id = appointment.Id;
            newApp.Patient = appointment.Patient;
            newApp.Premise = appointment.Premise;
            newApp.Type = appointment.Type;
            newApp.Duration = appointment.Duration;
            newApp.Comment = appointment.Comment;
            newApp.Beginning = datetime;
            newApp.Doctor = doctor;

            return newApp;
        }


        private void FillDoctorsComboBox()
        {
            connection = new OleDbConnection(Constants.connectionString);
            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM users where role=\"doctor\"";
            reader = command.ExecuteReader();

            while (reader.Read())
                doctorsBox.Items.Add(Person.Parse(reader));
            
            connection.Close();
        }


        private void ShowAvailableAppointmentsButton_Click(object sender, EventArgs e)
        {
            if (ValidInput())
                FindPriorityAppointments();
            else
                ShowErrorMessage();
        }


        private void FindPriorityAppointments()
        {
            List<Appointment> reservedAppointments = GetReservedAppointments(doctor);
            List<Appointment> availableAppointments = GetAvailableAppointments(reservedAppointments);
            ShowAvailableAppointments(availableAppointments);
        }


        private void ShowAvailableAppointments(List<Appointment> availableAppointments)
        {
            appointmentsBox.Text = "Choose";
            foreach (Appointment app in availableAppointments)
            {
                appointmentsBox.Items.Add(app);
            }
        }


        private List<Appointment> GetAvailableAppointments(List<Appointment> reservedAppointments)
        {
            List<Appointment> appointments = new List<Appointment>();
            DateTime currDay = priorityDay;

            while (currDay.CompareTo(endDay) < 0)
            {
                DateTime currTime = lowerLimit;
                while (currTime.CompareTo(upperLimit) < 0)
                {
                    DateTime datetime = MyConverter.CalculateDateTime(currDay, currTime);
                    Appointment appointment = CreatePossibleAppointment(datetime, doctor);
                    if (Available(appointment, reservedAppointments))
                    {
                        appointments.Add(appointment);
                    }

                    currTime = currTime.AddMinutes(15);
                }
                currDay = currDay.AddDays(1);
            }
            return appointments;
        }


        private bool Available(Appointment datetime, List<Appointment> reservedAppointments)
        {
            foreach (Appointment reserved in reservedAppointments)
            {
                DateTime appBeginning = datetime.Beginning;
                DateTime begin = reserved.Beginning;
                DateTime end = reserved.Beginning.AddMinutes(reserved.Duration);
                if (Methods.Between(appBeginning, begin, end) || Methods.Between(appBeginning.AddMinutes(15), begin, end))
                    return false;
            }
            return true;
        }

        private List<Appointment> GetReservedAppointments(Person doctor=null)
        {
            string query = (doctor == null) ? $"Select * from appointments"
                : $"Select * from appointments where doctorId=\"{doctor.Id}\"";
            List<Appointment> appointments = AppointmentController.LoadAppointments(Constants.connectionString, query);
            return appointments;
        }

        private void ShowErrorMessage()
        {
            MessageBox.Show("Invalid input! Check if you follow the instructions below:\n\n" +
                "DateTime format should be like: " + Constants.DateTimeFmt +
                "\nDate format should be like: " + Constants.DateFmt +
                "\nTime format should be like: " + Constants.TimeFmt +
                "\nYou must choose doctor.");
        }

        private bool ValidInput()
        {
            try
            {
                doctor = (Person) doctorsBox.SelectedItem;
                priorityDay = MyConverter.ToDate(dayTxt.Text);
                lowerLimit = MyConverter.ToTime(lowerLimitTxt.Text);
                upperLimit = MyConverter.ToTime(upperLimitTxt.Text);
                endDay = MyConverter.ToDate(endDayTxt.Text);
                priority = Convert.ToString(priorityBox.SelectedItem);
            }
            catch (System.FormatException)
            {
                return false;
            }
            return (doctor != null) && (priority != "");
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            Appointment selectedApp = (Appointment) appointmentsBox.SelectedItem;
            AppointmentController.InsertNew(selectedApp);
            MessageBox.Show("You have successfully created appointment.");
        }


    }
}
