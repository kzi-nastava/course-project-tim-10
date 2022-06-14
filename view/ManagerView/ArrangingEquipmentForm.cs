using HealthCareInfromationSystem.Core.Equipment.Service;
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

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class ArrangingEquipmentForm : Form
    {
        EquipmentService equipmentService = new EquipmentService();

        public ArrangingEquipmentForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Current premise";
            label2.Text = "New premise";
            label3.Text = "Move date";
            textBox1.Enabled = false;
            button1.Text = "Move";
        }

        private bool CheckIfTextBoxesAreEmpty()
        {
            return String.IsNullOrWhiteSpace(textBox1.Text) ||
                    comboBox1.SelectedItem == null ||
                    String.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()) ||
                    String.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void FillComboBox()
        {
            Dictionary<string, string> names = equipmentService.LoadPremiseNameAndId();

            foreach (KeyValuePair<string, string> name in names)
                comboBox1.Items.Add(name.Key + " - " + name.Value);
        }

        private void FillTable()
        {
            dataGridView1.DataSource = equipmentService.LoadAll();
        }

        private void ArrangingEquipmentForm_Load(object sender, EventArgs e)
        {
            SetLabelsAndButtons();
            FillComboBox();
            FillTable();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            if (currentRow == null) return;

            String date = currentRow.Cells[6].Value.ToString();
            String today = $"{DateTime.Today.Day.ToString()}.{DateTime.Today.Month.ToString()}.{DateTime.Today.Year.ToString()}.";
            DateTime dateFromSelection = DateTime.Parse(date);
            DateTime dateToday = DateTime.Parse(today);

            int result = DateTime.Compare(dateFromSelection, dateToday);

            String currentPremise = "";
            if (result == -1 || result == 0) currentPremise = currentRow.Cells[5].Value.ToString();
            else if (result == 1) currentPremise = currentRow.Cells[4].Value.ToString();

            textBox1.Text = currentPremise;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            if (currentRow == null) return;
            if (CheckIfTextBoxesAreEmpty()) return;

            String equipmentId = currentRow.Cells[0].Value.ToString();
            String newPremiseId = comboBox1.SelectedItem.ToString().Split('-')[0].Trim();
            String date = textBox2.Text;

            if (!Regex.IsMatch(date, Constants.dateRegex)) return;

            equipmentService.Transfer(equipmentId, newPremiseId, date);

            FillTable();
        }
    }
}
