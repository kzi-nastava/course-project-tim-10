
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class ArrangingDynamicEquipmentForm
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
            this.dataGridViewLowStock = new System.Windows.Forms.DataGridView();
            this.ColumnMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPremiseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPremiseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbEquipmentName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewSufficentStock = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbToPremise = new System.Windows.Forms.TextBox();
            this.tbFromPremise = new System.Windows.Forms.TextBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.ColumnOutOfStock1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipmentId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPremiseId1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPremiseName1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLowStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSufficentStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLowStock
            // 
            this.dataGridViewLowStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLowStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMark,
            this.ColumnEquipmentId,
            this.ColumnPremiseId,
            this.ColumnPremiseName,
            this.ColumnQuantity});
            this.dataGridViewLowStock.Location = new System.Drawing.Point(47, 186);
            this.dataGridViewLowStock.Name = "dataGridViewLowStock";
            this.dataGridViewLowStock.RowHeadersWidth = 62;
            this.dataGridViewLowStock.RowTemplate.Height = 28;
            this.dataGridViewLowStock.Size = new System.Drawing.Size(856, 250);
            this.dataGridViewLowStock.TabIndex = 0;
            this.dataGridViewLowStock.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewLowStock_RowHeaderMouseClick);
            // 
            // ColumnMark
            // 
            this.ColumnMark.HeaderText = "Out Of Stock!";
            this.ColumnMark.MinimumWidth = 8;
            this.ColumnMark.Name = "ColumnMark";
            this.ColumnMark.Width = 150;
            // 
            // ColumnEquipmentId
            // 
            this.ColumnEquipmentId.HeaderText = "Equipment Id";
            this.ColumnEquipmentId.MinimumWidth = 8;
            this.ColumnEquipmentId.Name = "ColumnEquipmentId";
            this.ColumnEquipmentId.Visible = false;
            this.ColumnEquipmentId.Width = 150;
            // 
            // ColumnPremiseId
            // 
            this.ColumnPremiseId.HeaderText = "Premise Id";
            this.ColumnPremiseId.MinimumWidth = 8;
            this.ColumnPremiseId.Name = "ColumnPremiseId";
            this.ColumnPremiseId.Width = 150;
            // 
            // ColumnPremiseName
            // 
            this.ColumnPremiseName.HeaderText = "Premise Name";
            this.ColumnPremiseName.MinimumWidth = 8;
            this.ColumnPremiseName.Name = "ColumnPremiseName";
            this.ColumnPremiseName.Width = 150;
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.HeaderText = "Quantity";
            this.ColumnQuantity.MinimumWidth = 8;
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 150;
            // 
            // cbEquipmentName
            // 
            this.cbEquipmentName.FormattingEnabled = true;
            this.cbEquipmentName.Location = new System.Drawing.Point(227, 54);
            this.cbEquipmentName.Name = "cbEquipmentName";
            this.cbEquipmentName.Size = new System.Drawing.Size(261, 28);
            this.cbEquipmentName.TabIndex = 1;
            this.cbEquipmentName.SelectedIndexChanged += new System.EventHandler(this.CbEquipmentName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select equipment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Premises low on stock for selected equipment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1003, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(379, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Premises with sufficent stock for selected equipment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Selected premise to move equipment to:";
            // 
            // dataGridViewSufficentStock
            // 
            this.dataGridViewSufficentStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSufficentStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOutOfStock1,
            this.ColumnEquipmentId1,
            this.ColumnPremiseId1,
            this.ColumnPremiseName1,
            this.ColumnQuantity1});
            this.dataGridViewSufficentStock.Location = new System.Drawing.Point(1007, 186);
            this.dataGridViewSufficentStock.Name = "dataGridViewSufficentStock";
            this.dataGridViewSufficentStock.RowHeadersWidth = 62;
            this.dataGridViewSufficentStock.RowTemplate.Height = 28;
            this.dataGridViewSufficentStock.Size = new System.Drawing.Size(810, 250);
            this.dataGridViewSufficentStock.TabIndex = 6;
            this.dataGridViewSufficentStock.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewSufficentStock_RowHeaderMouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1034, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Selected premise to take equiment from:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1034, 516);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Input quantity for moving:";
            // 
            // tbToPremise
            // 
            this.tbToPremise.Location = new System.Drawing.Point(435, 454);
            this.tbToPremise.Name = "tbToPremise";
            this.tbToPremise.ReadOnly = true;
            this.tbToPremise.Size = new System.Drawing.Size(168, 26);
            this.tbToPremise.TabIndex = 12;
            // 
            // tbFromPremise
            // 
            this.tbFromPremise.Location = new System.Drawing.Point(1372, 460);
            this.tbFromPremise.Name = "tbFromPremise";
            this.tbFromPremise.ReadOnly = true;
            this.tbFromPremise.Size = new System.Drawing.Size(168, 26);
            this.tbFromPremise.TabIndex = 13;
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(1372, 513);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(93, 26);
            this.tbQuantity.TabIndex = 14;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(846, 617);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(195, 55);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "Confirm Move";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // ColumnOutOfStock1
            // 
            this.ColumnOutOfStock1.HeaderText = "Out Of Stock!";
            this.ColumnOutOfStock1.MinimumWidth = 8;
            this.ColumnOutOfStock1.Name = "ColumnOutOfStock1";
            this.ColumnOutOfStock1.Visible = false;
            this.ColumnOutOfStock1.Width = 150;
            // 
            // ColumnEquipmentId1
            // 
            this.ColumnEquipmentId1.HeaderText = "Equipment Id";
            this.ColumnEquipmentId1.MinimumWidth = 8;
            this.ColumnEquipmentId1.Name = "ColumnEquipmentId1";
            this.ColumnEquipmentId1.Visible = false;
            this.ColumnEquipmentId1.Width = 150;
            // 
            // ColumnPremiseId1
            // 
            this.ColumnPremiseId1.HeaderText = "Premise Id";
            this.ColumnPremiseId1.MinimumWidth = 8;
            this.ColumnPremiseId1.Name = "ColumnPremiseId1";
            this.ColumnPremiseId1.Width = 150;
            // 
            // ColumnPremiseName1
            // 
            this.ColumnPremiseName1.HeaderText = "Premise Name";
            this.ColumnPremiseName1.MinimumWidth = 8;
            this.ColumnPremiseName1.Name = "ColumnPremiseName1";
            this.ColumnPremiseName1.Width = 150;
            // 
            // ColumnQuantity1
            // 
            this.ColumnQuantity1.HeaderText = "Quantity";
            this.ColumnQuantity1.MinimumWidth = 8;
            this.ColumnQuantity1.Name = "ColumnQuantity1";
            this.ColumnQuantity1.Width = 150;
            // 
            // ArrangingDynamicEquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1867, 728);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.tbFromPremise);
            this.Controls.Add(this.tbToPremise);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewSufficentStock);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbEquipmentName);
            this.Controls.Add(this.dataGridViewLowStock);
            this.Name = "ArrangingDynamicEquipmentForm";
            this.Text = "Arranging Dynamic Equipment";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLowStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSufficentStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewLowStock;
        private System.Windows.Forms.ComboBox cbEquipmentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewSufficentStock;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbToPremise;
        private System.Windows.Forms.TextBox tbFromPremise;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPremiseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPremiseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutOfStock1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipmentId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPremiseId1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPremiseName1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity1;
    }
}