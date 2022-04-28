using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.ManagerView
{
    public partial class ManagerMainForm : Form
    {
        public ManagerMainForm()
        {
            InitializeComponent();
        }

        private void ManagingPremisesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PremisesCRUDForm premisesCRUDForm = new PremisesCRUDForm();
            premisesCRUDForm.Show();
        }

        private void SearchAndFilterEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquipmentOverviewSearchFilterForm equipmentOverviewSearchFilterForm = new EquipmentOverviewSearchFilterForm();
            equipmentOverviewSearchFilterForm.Show();
        }

        private void ArrangingEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrangingEquipmentForm arrangingEquipmentForm = new ArrangingEquipmentForm();
            arrangingEquipmentForm.Show();
        }
    }
}
