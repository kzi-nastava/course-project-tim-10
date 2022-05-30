using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
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
    public partial class MedicineManagementForm : Form
    {
        MedicineController medicineController = new MedicineController();

        public MedicineManagementForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "ID";
            label2.Text = "Name";
            label3.Text = "Description";
            label4.Text = "Ingredients";
            label5.Text = "Comment";
            button1.Text = "Clear";
            button2.Text = "Add";
            button3.Text = "Edit";
        }

        private bool IsFormValid()
        {
            return !String.IsNullOrWhiteSpace(textBox1.Text) &&
                !String.IsNullOrWhiteSpace(textBox2.Text) &&
                !String.IsNullOrWhiteSpace(textBox3.Text) &&
                !String.IsNullOrWhiteSpace(textBox4.Text);
        }

        private void FillTable()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                String query = $"" +
                    $"select id, name, description, ingredients, comment " +
                    $"from medicine " +
                    $"where status=\"denied\"";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void MedicineManagementForm_Load(object sender, EventArgs e)
        {
            SetLabelsAndButtons();
            FillTable();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow currentRow = dataGridView1.CurrentRow;
            if (currentRow == null) return;

            String id = currentRow.Cells[0].Value.ToString();
            String name = currentRow.Cells[1].Value.ToString();
            String description = currentRow.Cells[2].Value.ToString();
            String ingredients = currentRow.Cells[3].Value.ToString();
            String comment = currentRow.Cells[4].Value.ToString();

            textBox1.Text = id;
            textBox1.Enabled = false;
            textBox2.Text = name;
            textBox2.Enabled = false;
            textBox3.Text = description;
            textBox3.Enabled = false;
            textBox4.Text = ingredients;
            textBox5.Text = comment;
            textBox5.Enabled = false;
        }

        private void ResetFieldsClick(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (!IsFormValid() || 
                textBox1.Enabled == false ||
                MedicineController.LoadOneById(textBox1.Text) != null) return;

            int id = Convert.ToInt32(textBox1.Text);
            string name = textBox2.Text;
            string description = textBox3.Text;
            string[] ingredients = textBox4.Text.Split(',');

            Medicine medicine = new Medicine(id, name, description, ingredients, "in progress", "");

            medicineController.Save(medicine);

            MessageBox.Show("Medicine added.");
        }
    }
}
