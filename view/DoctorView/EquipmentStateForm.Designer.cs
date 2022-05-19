
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class EquipmentStateForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.equipmentName = new System.Windows.Forms.Label();
			this.spentTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Equipment,
            this.Quantity});
			this.dataGridView1.Location = new System.Drawing.Point(136, 53);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.Size = new System.Drawing.Size(302, 150);
			this.dataGridView1.TabIndex = 0;
			// 
			// Equipment
			// 
			this.Equipment.HeaderText = "Equipment";
			this.Equipment.MinimumWidth = 6;
			this.Equipment.Name = "Equipment";
			this.Equipment.Width = 125;
			// 
			// Quantity
			// 
			this.Quantity.HeaderText = "Quantity";
			this.Quantity.MinimumWidth = 6;
			this.Quantity.Name = "Quantity";
			this.Quantity.Width = 125;
			// 
			// equipmentName
			// 
			this.equipmentName.AutoSize = true;
			this.equipmentName.Location = new System.Drawing.Point(133, 331);
			this.equipmentName.Name = "equipmentName";
			this.equipmentName.Size = new System.Drawing.Size(0, 17);
			this.equipmentName.TabIndex = 1;
			// 
			// spentTextBox
			// 
			this.spentTextBox.Location = new System.Drawing.Point(304, 326);
			this.spentTextBox.Name = "spentTextBox";
			this.spentTextBox.Size = new System.Drawing.Size(100, 22);
			this.spentTextBox.TabIndex = 2;
			// 
			// EquipmentStateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(576, 450);
			this.Controls.Add(this.spentTextBox);
			this.Controls.Add(this.equipmentName);
			this.Controls.Add(this.dataGridView1);
			this.Name = "EquipmentStateForm";
			this.Text = "EquipmentStateForm";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Equipment;
		private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
		private System.Windows.Forms.Label equipmentName;
		private System.Windows.Forms.TextBox spentTextBox;
	}
}