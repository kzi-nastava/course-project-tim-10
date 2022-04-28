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

        private bool CheckIfComboBoxesAreEmpty()
        {
            return comboBox1.SelectedItem == null &&
                    comboBox2.SelectedItem == null &&
                    comboBox3.SelectedItem == null;
        }

        private void FillTable(String query, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            //OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adapter);
            //BindingSource bindingSource = new BindingSource();
            //dataGridView1.DataSource = bindingSource;
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            adapter.Fill(table);
            //bindingSource.DataSource = table;
            dataGridView1.DataSource = table;
        }
    }
}
