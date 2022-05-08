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

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class BookingByReferralForm : Form
    {
        public BookingByReferralForm()
        {
            InitializeComponent();
            DisplayPatientsTableData();
        }

        private void FillPatientsTable(String query, OleDbConnection connection)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);

            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };

            adapter.Fill(table);
            dataGridViewPatients.DataSource = table;
        }


        private void DisplayPatientsTableData()
        {
            using (OleDbConnection connection = new OleDbConnection(Constants.connectionString))
            {
                FillPatientsTable("select name, last_name as \'last name\', username from users where role=\"patient\" and blocked=\"false\"", connection);
            }
        }

    }
}
