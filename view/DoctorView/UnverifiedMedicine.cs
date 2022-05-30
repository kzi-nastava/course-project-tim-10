using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthCareInfromationSystem.models.entity;
using HealthCareInfromationSystem.contollers;

namespace HealthCareInfromationSystem.view.DoctorView
{
	public partial class UnverifiedMedicine : Form
	{
		public UnverifiedMedicine()
		{
			InitializeComponent();
			FillTable();
		}

		private void FillTable()
		{
			List<Medicine> medicines = MedicineController.LoadAll("select * from medicine where status = \"in progress\" ");
			foreach (Medicine medicine in medicines)
			{
				dataGridView1.Rows.Add(medicine.Name, medicine.Description,
									   medicine.ConvertIngredientsForTable(), medicine.Id) ;

			}
		}

		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void AcceptClick(object sender, EventArgs e)
		{
			if (IsOneRowSelected()) SaveChanges("accepted");
		}

		private void DenyClick(object sender, EventArgs e)
		{
			if (IsOneRowSelected()) SaveChanges("denied");
		}

		private bool IsOneRowSelected() {
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1) return true;

			MessageBox.Show("Please select ONLY ONE row editting.", "Error");
			return false;
		}

		private void SaveChanges(string status) {
			DialogResult dialogResult = MessageBox.Show("Are you sure you want save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				
				MessageBox.Show("Changes saved.", "Success");

			}
		}

		private string GetSelectedMedicineId()
		{
			return dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
		}
	}
}
