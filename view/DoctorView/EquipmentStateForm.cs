using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.Core.Equipment;
using HealthCareInfromationSystem.Servise;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class EquipmentStateForm : Form
	{
		private Premise premise;
		EquipmentController equipmentController = new EquipmentController();

		public EquipmentStateForm()
		{
			InitializeComponent();
		}

		public EquipmentStateForm(Premise premise)
		{
			InitializeComponent();
			this.premise = premise;
			
			FillTable();
			
		}

		private void FillTable()
		{
			List<Equipment> equipments = equipmentController.LoadEquipmentsFromPremise(premise.Id);
			foreach (Equipment equipment in equipments)
			{
				dataGridView1.Rows.Add(equipment.Name, equipment.Quantity, equipment.Id);

			}
		}



		private void EditBtnClick(object sender, EventArgs e)
		{
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1)
			{
				equipmentName.Text = GetSelectedEquipmentName() + " spent:";
			}
			else
			{
				MessageBox.Show("Please select ONLY ONE row editting.", "Error");
			}
		}

		private void SaveBtnClick(object sender, EventArgs e)
		{
			if (!IsValidInput(quantitySpentTextBox.Text)) return;
			DialogResult dialogResult = MessageBox.Show("Are you sure you want save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				int newQuantity = CalculateNewQuantity();
				equipmentController.Add(GetSelectedEquipmentId(), newQuantity);
				MessageBox.Show("Changes saved.", "Success");
				
			}

		}

		private int CalculateNewQuantity()
		{
			int quantityToRemove = int.Parse(quantitySpentTextBox.Text);
			return GetSelectedEquipmentQuantity() - quantityToRemove;
		}

		private bool IsValidInput(string quantitySpent)
		{
			try
			{
				int quantityToRemove = int.Parse(quantitySpent);
				if (quantityToRemove > GetSelectedEquipmentQuantity()) {
					MessageBox.Show("Please input a smaler number than the curent quantity.", "Error");
					return false;
				}
				return true;
			}
			catch
			{
				MessageBox.Show("Please input a number.", "Error");
				return false;
			}
		}

		private string GetSelectedEquipmentId()
		{
			return dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
		}

		private string GetSelectedEquipmentName()
		{
			return dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
		}

		private int GetSelectedEquipmentQuantity()
		{
			String quantity = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
			return int.Parse(quantity);
		}
	}
}
