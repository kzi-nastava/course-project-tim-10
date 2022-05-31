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


		private void AcceptClick(object sender, EventArgs e)
		{
			if (IsOneRowSelected()) SaveChanges("accepted");
		}

		private void DenyClick(object sender, EventArgs e)
		{
			if (IsOneRowSelected() && IsCommentFilled()) SaveChanges("denied");
		}

		private bool IsCommentFilled() {
			if (commentComboBox.Text != "") return true;
			MessageBox.Show("Please fill comment for denying.", "Error");
			return false;
		}

		private bool IsOneRowSelected() {
			int selectedRowCount =
			dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
			if (selectedRowCount == 1) return true;

			MessageBox.Show("Please select ONLY ONE row.", "Error");
			return false;
		}

		private void SaveChanges(string status) {
			DialogResult dialogResult = MessageBox.Show("Are you sure you want save changes?", "Check", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				MedicineController.Edit(new Medicine(GetSelectedMedicineId(), GetSelectedMedicineName(),
					GetSelectedMedicineDescription(), GetSelectedMedicineIngridients(), status, commentComboBox.Text ));
				MessageBox.Show("Changes saved.", "Success");

			}
		}

		private int GetSelectedMedicineId()
		{
			string id = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
			return int.Parse(id);
		}

		private string GetSelectedMedicineName()
		{
			return dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
		}

		private string GetSelectedMedicineDescription()
		{
			return dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
		}

		private string[] GetSelectedMedicineIngridients()
		{
			string ingredients = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
			string[] allIngredients = ingredients.Split(',');
			for (int i = 0; i < allIngredients.Length; i++)
			{
				allIngredients[i] = allIngredients[i].Trim();
			}
			return allIngredients;
		}

	}
}
