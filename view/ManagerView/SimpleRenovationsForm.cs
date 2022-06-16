 
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
    public partial class SimpleRenovationsForm : Form
    {
        private RenovationService renovationService = new RenovationService();
        private PremiseService premiseService = new PremiseService();

        public SimpleRenovationsForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Renovation ID";
            label2.Text = "Premise";
            label3.Text = "Start date";
            label4.Text = "End date";
            button1.Text = "Add renovation";
        }

        private bool ValidateForm()
        {
            return String.IsNullOrWhiteSpace(textBox1.Text) ||
                    String.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void FillRenovationTable()
        {
            dataGridView1.DataSource = renovationService.LoadAllSimpleRenovations();
        }

        private void FillPremiseTable()
        {
            dataGridView2.DataSource = premiseService.LoadAll();
        }

        private void SimpleRenovationsForm_Load(object sender, EventArgs e)
        {
            SetLabelsAndButtons();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            FillRenovationTable();
            dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            FillPremiseTable();
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView2.CurrentRow;
            if (currentRow == null) return;

            String premiseId = currentRow.Cells[0].Value.ToString();
            String premiseName = currentRow.Cells[1].Value.ToString();

            textBox2.Text = $"{premiseId} - {premiseName}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) return;

            String renovationId = textBox1.Text;
            String premiseId = textBox2.Text.Split('-')[0].Trim();
            String startDate = textBox3.Text;
            String endDate = textBox4.Text;

            if (renovationService.CheckIfSimpleRenovationExistsById(renovationId)) return;

            if (!Regex.IsMatch(startDate, Constants.dateRegex) || !Regex.IsMatch(endDate, Constants.dateRegex)) return;

            if (premiseService.CheckIfPremiseIsOccupied(premiseId, startDate, endDate))
            {
                MessageBox.Show("Premise is occupied in that time interval.");
                return;
            }

            SimpleRenovation renovation = new SimpleRenovation(renovationId, premiseId, startDate, endDate);
            renovationService.SaveSimpleRenovation(renovation);

            FillRenovationTable();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
