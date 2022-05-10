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

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class ComplexRenovationsForm : Form
    {
        public ComplexRenovationsForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Premise One";
            label2.Text = "Premise Two";
            label3.Text = "New premise ID";
            label4.Text = "New premise name";
            label5.Text = "New premise type";
            label6.Text = "Start date";
            label7.Text = "End date";
            label8.Text = "Old premise";
            label9.Text = "First premise ID";
            label10.Text = "First premise name";
            label11.Text = "First premise type";
            label12.Text = "Second premise ID";
            label13.Text = "Second premise name";
            label14.Text = "Second premise type";
            label15.Text = "Start date";
            label16.Text = "End date";
            button1.Text = "Combine";
            button2.Text = "Move to first premise";
            button3.Text = "Move to second premise";
            button4.Text = "Divide";
        }

        private void FillComboBox()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                String query = "select premises_id, name from premises";

                OleDbCommand command = new OleDbCommand(query, connection);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0] + " - " + reader[1]);
                    comboBox2.Items.Add(reader[0] + " - " + reader[1]);
                    comboBox4.Items.Add(reader[0] + " - " + reader[1]);
                }
                reader.Close();
            }

            List<String> types = new List<string> { "operational room", "examination room", "rest room", "other" };
            foreach (String type in types)
            {
                comboBox3.Items.Add(type);
                comboBox5.Items.Add(type);
                comboBox6.Items.Add(type);
            }
        }

        private void ComplexRenovationsForm_Load(object sender, EventArgs e)
        {
            SetLabelsAndButtons();
            FillComboBox();
        }
    }
}
