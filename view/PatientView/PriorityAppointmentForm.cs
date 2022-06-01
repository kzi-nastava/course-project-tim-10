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

        private void PriorityAppointment()
        {
            InitializeComponent();
            InitializeAppointment();
            FillDoctorsComboBox();
        }

        public PriorityAppointmentForm()
        {
            PriorityAppointment();
        }

        private void SetDoctorPriority(Person doctor)
        {
            priorityBox.SelectedItem = priorityBox.Items[1];   // priority is doctor automatically
            priorityBox.Enabled = false;
            doctorsBox.Items.Add(doctor);
            doctorsBox.SelectedItem = doctor;
            doctorsBox.Enabled = false;
            this.doctor = doctor;
        }

        public PriorityAppointmentForm(Person doctor)
        {
            PriorityAppointment();
            SetDoctorPriority(doctor);
        }

        private void InitializeAppointment()
        {
            appointment = new Appointment();
            appointment.Id = int.Parse(BaseFunctions.GenerateId("appointments", "id"));
            appointment.Patient = LoggedInUser.loggedIn;
            appointment.Premise = PremiseController.SearchPremise("2");
            appointment.Type = AppointmentType.physical;
            appointment.Duration = 15;
            appointment.Comment = "";
        }


        private List<Appointment> CreatePossibleAppointments(DateTime datetime)
        {
            List<Appointment> appointments = new List<Appointment>();
            List<Person> doctors = GetAllDoctors();
            foreach (Person doctor in doctors)
            {
                Appointment newApp = new Appointment
                {
                    Id = appointment.Id,
                    Patient = appointment.Patient,
                    Premise = appointment.Premise,
                    Type = appointment.Type,
                    Duration = appointment.Duration,
                    Comment = appointment.Comment,
                    Beginning = datetime,
                    Doctor = doctor
                };

                appointments.Add(newApp);
            }
            return appointments;
        }


        List<Person> GetAllDoctors()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                List<Person> doctors = new List<Person>();
                string queryString = $"Select * from users where role = \"doctor\"";
                OleDbCommand command = new OleDbCommand(queryString, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                Person person = null;

                while (reader.Read())
                {
                    person = Person.Parse(reader);
                    doctors.Add(person);
                }
                reader.Close();
                return doctors;
            }
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
            if (availableAppointments.Count == 0)
            {
                MessageBox.Show("Nismo nasli da sve odgovara.");
                availableAppointments = GetAvailableAppointments(reservedAppointments, priority);
            }        
            ShowAvailableAppointments(availableAppointments);
        }


        private List<Appointment> GetAvailableAppointments(List<Appointment> reservedAppointments, string priority="")
        {
            List<Appointment> appointments = new List<Appointment>();
            DateTime currDay = priorityDay;
            DateTime upperLimit = (priority != "Doctor") ? this.upperLimit : MyConverter.ToTime("16:00");
            while (currDay.CompareTo(endDay) < 0)
            {
                DateTime currTime = (priority != "Doctor") ? lowerLimit : MyConverter.ToTime("10:00");

                while (currTime.CompareTo(upperLimit) < 0)
                {
                    DateTime datetime = MyConverter.CalculateDateTime(currDay, currTime);
                    List<Appointment> appointments2 = CreatePossibleAppointments(datetime);
                    foreach (Appointment appointment in appointments2)    
                        if (Available(appointment, reservedAppointments, priority))
                            appointments.Add(appointment);

                    currTime = currTime.AddMinutes(15);
                }
                currDay = currDay.AddDays(1);
            }
            return appointments;
        }


        private bool Available(Appointment appointment, List<Appointment> reservedAppointments, string priority="")
        {
            foreach (Appointment reserved in reservedAppointments)
            {
                DateTime appBeginning = appointment.Beginning;
                DateTime begin = reserved.Beginning;
                DateTime end = reserved.Beginning.AddMinutes(reserved.Duration);

                if (priority != "Doctor" && !AvailableDate(appBeginning, begin, end))
                    return false;
                if (priority != "Date" && appointment.Doctor.Id != doctor.Id)
                    return false;

            }
            return true;
        }

        private bool AvailableDate(DateTime appBeginning, DateTime begin, DateTime end)
        {
            return !(Methods.Between(appBeginning, begin, end) || Methods.Between(appBeginning.AddMinutes(15), begin, end));
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


        private void ShowAvailableAppointments(List<Appointment> availableAppointments)
        {
            appointmentsBox.Text = "Choose";
            appointmentsBox.Items.Clear();
            foreach (Appointment app in availableAppointments)
                appointmentsBox.Items.Add(app);
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
