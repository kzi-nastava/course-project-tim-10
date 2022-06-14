 
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.Core.PremiseManagment;
using HealthCareInfromationSystem.Core.PremiseManagment.Renovation;

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class ComplexRenovationsForm : Form
    {
        private RenovationService renovationService = new RenovationService();
        private PremiseService premiseService = new PremiseService();

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
            Dictionary<string, string> names = renovationService.LoadPremiseNameAndId();

            foreach (KeyValuePair<string, string> name in names)
            {
                comboBox1.Items.Add(name.Key + " - " + name.Value);
                comboBox2.Items.Add(name.Key + " - " + name.Value);
                comboBox4.Items.Add(name.Key + " - " + name.Value);
            }

            List<String> types = new List<string> { "operational room", "examination room", "rest room", "other" };
            foreach (String type in types)
            {
                comboBox3.Items.Add(type);
                comboBox5.Items.Add(type);
                comboBox6.Items.Add(type);
            }
        }

        private bool CheckIfCombineTextBoxesAreEmpty()
        {
            return String.IsNullOrWhiteSpace(textBox1.Text) ||
                    String.IsNullOrWhiteSpace(textBox2.Text) ||
                    String.IsNullOrWhiteSpace(textBox3.Text) ||
                    String.IsNullOrWhiteSpace(textBox4.Text) ||
                    comboBox1.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()) ||
                    comboBox2.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox2.SelectedItem.ToString()) ||
                    comboBox3.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox3.SelectedItem.ToString());
        }

        private bool CheckIfNewPremiseOneTextBoxesAreEmpty()
        {
            return String.IsNullOrWhiteSpace(textBox5.Text) ||
                    String.IsNullOrWhiteSpace(textBox6.Text) ||
                    comboBox5.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox5.SelectedItem.ToString());
        }

        private bool CheckIfNewPremiseTwoTextBoxesAreEmpty()
        {
            return String.IsNullOrWhiteSpace(textBox7.Text) ||
                    String.IsNullOrWhiteSpace(textBox8.Text) ||
                    comboBox5.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox6.SelectedItem.ToString());
        }

        private bool CheckIfDivideTextBoxesAreEmpty()
        {
            return CheckIfNewPremiseOneTextBoxesAreEmpty() ||
                    CheckIfNewPremiseTwoTextBoxesAreEmpty() ||
                    String.IsNullOrWhiteSpace(textBox9.Text) ||
                    String.IsNullOrWhiteSpace(textBox10.Text);
        }

        private void ComplexRenovationsForm_Load(object sender, EventArgs e)
        {
            SetLabelsAndButtons();
            FillComboBox();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (CheckIfCombineTextBoxesAreEmpty()) return;

            String firstPremiseId = comboBox1.SelectedItem.ToString().Split('-')[0].Trim();
            String secondPremiseId = comboBox2.SelectedItem.ToString().Split('-')[0].Trim();
            String newPremiseId = textBox1.Text;
            String newPremiseName = textBox2.Text;
            String newPremiseType = comboBox3.SelectedItem.ToString();
            String startDate = textBox3.Text;
            String endDate = textBox4.Text;

            if (premiseService.CheckIfPremiseExistsById(newPremiseId) ||
                premiseService.CheckIfPremiseIsOccupied(firstPremiseId, startDate, endDate) ||
                premiseService.CheckIfPremiseIsOccupied(secondPremiseId, startDate, endDate))
                return;

            if (!Regex.IsMatch(startDate, Constants.dateRegex) || !Regex.IsMatch(endDate, Constants.dateRegex)) return;

            Premise firstPremise = new Premise(firstPremiseId, "", "");
            Premise secondPremise = new Premise(secondPremiseId, "", "");
            Premise newPremise = new Premise(newPremiseId, newPremiseName, newPremiseType);

            ComplexRenovation firstPremiseRenovation = new ComplexRenovation(firstPremise, "delete", endDate);
            ComplexRenovation secondPremiseRenovation = new ComplexRenovation(secondPremise, "delete", endDate);
            ComplexRenovation newPremiseRenovation = new ComplexRenovation(newPremise, "add", endDate);

            renovationService.SaveComplexRenovation(firstPremiseRenovation);
            renovationService.SaveComplexRenovation(secondPremiseRenovation);
            renovationService.SaveComplexRenovation(newPremiseRenovation);

            ComplexMoving complexMoving = new ComplexMoving(firstPremise.Id, secondPremise.Id, newPremiseId, "combine", endDate);

            renovationService.SaveCombiningComplexMoving(complexMoving);

            MessageBox.Show("Scheduled complex renovation.");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfDivideTextBoxesAreEmpty()) return;

            String oldPremiseId = comboBox4.SelectedItem.ToString().Split('-')[0].Trim();
            String firstNewPremiseId = textBox5.Text;
            String firstNewPremiseName = textBox6.Text;
            String firstNewPremiseType = comboBox5.SelectedItem.ToString();
            String secondNewPremiseId = textBox7.Text;
            String secondNewPremiseName = textBox8.Text;
            String secondNewPremiseType = comboBox6.SelectedItem.ToString();
            String startDate = textBox9.Text;
            String endDate = textBox10.Text;

            if (premiseService.CheckIfPremiseExistsById(firstNewPremiseId) ||
                premiseService.CheckIfPremiseExistsById(secondNewPremiseId) ||
                premiseService.CheckIfPremiseIsOccupied(oldPremiseId, startDate, endDate))
                return;

            if (!Regex.IsMatch(startDate, Constants.dateRegex) || !Regex.IsMatch(endDate, Constants.dateRegex)) return;

            Premise oldPremise = new Premise(oldPremiseId, "", "");
            Premise firstNewPremise = new Premise(firstNewPremiseId, firstNewPremiseName, firstNewPremiseType);
            Premise secondNewPremise = new Premise(secondNewPremiseId, secondNewPremiseName, secondNewPremiseType);

            ComplexRenovation oldPremiseRenovation = new ComplexRenovation(oldPremise, "delete", endDate);
            ComplexRenovation firstNewPremiseRenovation = new ComplexRenovation(firstNewPremise, "add", endDate);
            ComplexRenovation secondNewPremiseRenovation = new ComplexRenovation(secondNewPremise, "add", endDate);

            renovationService.SaveComplexRenovation(oldPremiseRenovation);
            renovationService.SaveComplexRenovation(firstNewPremiseRenovation);
            renovationService.SaveComplexRenovation(secondNewPremiseRenovation);

            MessageBox.Show("Scheduled complex renovation.");
        }

        private void ComboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            String id = comboBox4.SelectedItem.ToString().Split('-')[0].Trim();
            dataGridView1.DataSource = renovationService.LoadEquipmentByPremise(id);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            if (currentRow == null) return;

            String equipmentId = currentRow.Cells[0].Value.ToString();
            String oldPremiseId = comboBox4.SelectedItem.ToString().Split('-')[0].Trim();
            String firstNewPremiseId = textBox5.Text;
            String secondNewPremiseId = textBox7.Text;
            String endDate = textBox10.Text;

            ComplexMoving complexMoving = new ComplexMoving(oldPremiseId, firstNewPremiseId, secondNewPremiseId, "divide-1", endDate);

            renovationService.SaveDividingComplexMoving(complexMoving, equipmentId);

            MessageBox.Show("Scheduled to move to first new premise.");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            if (currentRow == null) return;

            String equipmentId = currentRow.Cells[0].Value.ToString();
            String oldPremiseId = comboBox4.SelectedItem.ToString().Split('-')[0].Trim();
            String firstNewPremiseId = textBox5.Text;
            String secondNewPremiseId = textBox7.Text;
            String endDate = textBox10.Text;

            ComplexMoving complexMoving = new ComplexMoving(oldPremiseId, firstNewPremiseId, secondNewPremiseId, "divide-2", endDate);

            renovationService.SaveDividingComplexMoving(complexMoving, equipmentId);

            MessageBox.Show("Scheduled to move to second new premise.");
        }
    }
}
