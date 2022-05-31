using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class DynamicEquipmentAquirementForm : Form
    {
        private string selectedEquipmentId = "";
        private int inputQuantity = -1;
        public DynamicEquipmentAquirementForm()
        {
            InitializeComponent();
            DisplayEquipmentTableData();
        }

        private void DisplayEquipmentTableData()
        {
            List<Equipment> equipment = EquipmentController.GetDynamicEquipmentOutOfStock();
            foreach (Equipment e in equipment)
            {
                dataGridViewEquipment.Rows.Add(e.Id, e.Name);
            }
        }

        private void DataGridViewEquipment_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewEquipment.Rows[e.RowIndex].Cells[0].Value != null)
            {
                selectedEquipmentId = dataGridViewEquipment.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private bool IfQuantityFieldCorrect()
        {
            if (int.TryParse(this.tbQuantity.Text, out int quantity)) {
                if (quantity > 0) return true;
            }
            MessageBox.Show("Incorrect input in quantity field.");
            return false;
        }

        private bool IfRowSelected()
        {
            if (selectedEquipmentId != "") return true;
            else
            {
                MessageBox.Show("No equipment was selected.");
                return false;
            }
        }

        private void BtnRequestSupply_Click(object sender, EventArgs e)
        {
            if (IfRowSelected() && IfQuantityFieldCorrect())
            {
                // Send request
            }
        }
    }
}
