using HealthCareInfromationSystem.contollers;
using HealthCareInfromationSystem.models.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCareInfromationSystem.view.SecretaryView
{
    public partial class ArrangingDynamicEquipmentForm : Form
    {
        private string selectedFromPremiseId = "";
        private string selectedToPremiseId = "";
        private int selectedQuantity;
        private EquipmentController equipmentController = new EquipmentController();
        public ArrangingDynamicEquipmentForm()
        {
            InitializeComponent();
            InitializeEquipmentNameComboBox();
        }

        private void ClearFields()
        {
            tbToPremise.Text = "";
            selectedToPremiseId = "";
            tbFromPremise.Text = "";
            selectedFromPremiseId = "";
            tbQuantity.Text = "";
            selectedQuantity = 0;
        }
        private void InitializeEquipmentNameComboBox()
        {
            foreach (string name in equipmentController.GetEquipmentNames())
            {
                this.cbEquipmentName.Items.Add(name);
            }
        }


        private void DisplayEquipmentLowOnStockTable(string equipmentName)
        {
            dataGridViewLowStock.Rows.Clear();
            foreach (List<string> row in equipmentController.GetRowsForEquipmentLowOnStock(equipmentName)) 
            {
                dataGridViewLowStock.Rows.Add(row[0], row[1], row[2], row[3], row[4]); 
            }
        }

        private void DisplayEquipmentWithSufficentStockTable(string equipmentName)
        {
            dataGridViewSufficentStock.Rows.Clear();
            foreach (List<string> row in equipmentController.GetRowsForEquipmentWithSufficentStock(equipmentName))
            {
                dataGridViewSufficentStock.Rows.Add(row[0], row[1], row[2], row[3], row[4]);
            }
        }

        private void CbEquipmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFields();
            DisplayEquipmentLowOnStockTable(cbEquipmentName.Text);
            DisplayEquipmentWithSufficentStockTable(cbEquipmentName.Text);
        }

        private void DataGridViewLowStock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewLowStock.Rows[e.RowIndex].Cells[0].Value != null)
            {
                tbToPremise.Text = dataGridViewLowStock.Rows[e.RowIndex].Cells[3].Value.ToString();
                selectedToPremiseId = dataGridViewLowStock.Rows[e.RowIndex].Cells[2].Value.ToString();
            } else
            {
                tbToPremise.Text = "";
                selectedToPremiseId = "";
            }
        }

        private void DataGridViewSufficentStock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewSufficentStock.Rows[e.RowIndex].Cells[0].Value != null)
            {
                tbFromPremise.Text = dataGridViewSufficentStock.Rows[e.RowIndex].Cells[3].Value.ToString();
                selectedFromPremiseId = dataGridViewSufficentStock.Rows[e.RowIndex].Cells[2].Value.ToString();
                selectedQuantity = int.Parse(dataGridViewSufficentStock.Rows[e.RowIndex].Cells[4].Value.ToString());
            } else
            {
                tbFromPremise.Text = "";
                selectedFromPremiseId = "";
                selectedQuantity = 0;
            }

        }

        private bool IfQuantityFieldCorrect()
        {
            if (int.TryParse(this.tbQuantity.Text, out int quantity))
            {
                if (quantity > 0 && quantity <= selectedQuantity) return true;
            }
            MessageBox.Show("Incorrect input in quantity field.\nQuantity can't be higher than available in selected premise.");
            return false;
        }

        private bool IfEquipmentSelected()
        {
            if (selectedToPremiseId != "" && selectedFromPremiseId != "") return true;
            else
            {
                MessageBox.Show("Equipment must be selected.");
                return false;
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (IfEquipmentSelected() && IfQuantityFieldCorrect())
            {
                try
                {
                equipmentController.Move(cbEquipmentName.Text, selectedFromPremiseId, selectedToPremiseId, int.Parse(tbQuantity.Text.ToString()));
                MessageBox.Show("Equipment successfully arranged.");
                ClearFields();
                dataGridViewLowStock.Rows.Clear();
                dataGridViewSufficentStock.Rows.Clear();
                } catch (OleDbException)
                {
                    MessageBox.Show("Error occured.");
                }
            }
        }

    }
}
