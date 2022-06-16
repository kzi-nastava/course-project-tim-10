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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class EquipmentOverviewSearchFilterForm : Form
    {
        EquipmentService equipmentService = new EquipmentService();

        public EquipmentOverviewSearchFilterForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Search term";
            label2.Text = "Premises type";
            label3.Text = "Quantity";
            label4.Text = "Equipment type";
            button1.Text = "Search";
            button2.Text = "Filter";
            button3.Text = "Show all";
        }

        private void FillComboBox()
        {
            comboBox1.Items.Add("operational room");
            comboBox1.Items.Add("examination room");
            comboBox1.Items.Add("rest room");
            comboBox1.Items.Add("warehouse");
            comboBox1.Items.Add("other");
            comboBox2.Items.Add("out of stock");
            comboBox2.Items.Add("0-10");
            comboBox2.Items.Add("10+");
            comboBox3.Items.Add("examination equipment");
            comboBox3.Items.Add("equipment for operations");
            comboBox3.Items.Add("room furniture");
            comboBox3.Items.Add("equipment in the hallways");
        }

        private bool ValidateForm()
        {
            return comboBox1.SelectedItem == null &&
                    comboBox2.SelectedItem == null &&
                    comboBox3.SelectedItem == null;
        }

        private void FillTable()
        {
            dataGridView1.DataSource = equipmentService.LoadAll();
        }

        private void EquipmentOverviewSearchFilterForm_Load(object sender, EventArgs e)
        {
            SetLabelsAndButtons();
            FillComboBox();
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            FillTable();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String searchTerm = textBox1.Text;

            dataGridView1.DataSource = equipmentService.SearchByTerm(searchTerm);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) return;

            String premisesType = comboBox1.SelectedItem == null ? "" : comboBox1.SelectedItem.ToString();
            String quantity = comboBox2.SelectedItem == null ? "" : comboBox2.SelectedItem.ToString();
            String equipmentType = comboBox3.SelectedItem == null ? "" : comboBox3.SelectedItem.ToString();

            dataGridView1.DataSource = equipmentService.SearchByCriteria(premisesType, quantity, equipmentType);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            FillTable();
        }
    }
}
