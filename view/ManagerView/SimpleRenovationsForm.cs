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
    public partial class SimpleRenovationsForm : Form
    {
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

        private void FillRenovationTable()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                String query = $"select * from simple_renovations";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void FillPremiseTable()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                String query = $"select * from premises";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };

                adapter.Fill(table);
                dataGridView2.DataSource = table;
            }
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
    }
}
