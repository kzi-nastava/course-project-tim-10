using HealthCareInfromationSystem.contollers;
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
    public partial class PremisesCRUDForm : Form
    {
        private PremiseController premiseController = new PremiseController();

        public PremisesCRUDForm()
        {
            InitializeComponent();
        }

        private void SetLabelsAndButtons()
        {
            label1.Text = "Premise ID";
            label2.Text = "Name";
            label3.Text = "Premise type";
            label4.Text = "";
            button1.Text = "Add new";
            button2.Text = "Edit";
            button3.Text = "Delete";
            button4.Text = "Clear";
        }

        private void FillComboBox()
        {
            comboBox1.Items.Add("operational room");
            comboBox1.Items.Add("examination room");
            comboBox1.Items.Add("rest room");
            comboBox1.Items.Add("other");
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

        private void RefreshTable()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                FillTable("select * from premises where type <> \"warehouse\"", connection);
            }
        }
    }
}
