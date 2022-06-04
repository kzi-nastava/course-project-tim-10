using HealthCareInfromationSystem.contollers;
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
        private RenovationController renovationController = new RenovationController();

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

        private void SimpleRenovationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimpleRenovationsForm simpleRenovationsForm = new SimpleRenovationsForm();
            simpleRenovationsForm.Show();
        }

        private void ComplexRenovationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComplexRenovationsForm complexRenovationsForm = new ComplexRenovationsForm();
            complexRenovationsForm.Show();
        }

        private void ManagerMainForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Checking if there is complex renovations to be executed...";

            renovationController.CheckForComplexRenovationToExecute();
            renovationController.CheckForComplexMovingToExecute();

            label1.Text = "Done checking.";
        }

        private void medicineManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedicineManagementForm medicineManagement = new MedicineManagementForm();
            medicineManagement.Show();
        }
    }
}
