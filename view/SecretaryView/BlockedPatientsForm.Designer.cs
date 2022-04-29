
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class BlockedPatientsForm
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
            this.dataGridViewBlockedPatients = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbBlocker = new System.Windows.Forms.TextBox();
            this.btnUnblock = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlockedPatients)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBlockedPatients
            // 
            this.dataGridViewBlockedPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBlockedPatients.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewBlockedPatients.Name = "dataGridViewBlockedPatients";
            this.dataGridViewBlockedPatients.ReadOnly = true;
            this.dataGridViewBlockedPatients.Size = new System.Drawing.Size(541, 266);
            this.dataGridViewBlockedPatients.TabIndex = 0;
            this.dataGridViewBlockedPatients.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewBlockedPatients_RowHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 340);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient with Id";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(102, 337);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(44, 20);
            this.tbId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "blocked by";
            // 
            // tbBlocker
            // 
            this.tbBlocker.Location = new System.Drawing.Point(217, 337);
            this.tbBlocker.Name = "tbBlocker";
            this.tbBlocker.Size = new System.Drawing.Size(100, 20);
            this.tbBlocker.TabIndex = 4;
            // 
            // btnUnblock
            // 
            this.btnUnblock.Location = new System.Drawing.Point(388, 330);
            this.btnUnblock.Name = "btnUnblock";
            this.btnUnblock.Size = new System.Drawing.Size(89, 33);
            this.btnUnblock.TabIndex = 5;
            this.btnUnblock.Text = "Unblock";
            this.btnUnblock.UseVisualStyleBackColor = true;
            this.btnUnblock.Click += new System.EventHandler(this.BtnUnblock_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(385, 366);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(43, 13);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "Status: ";
            // 
            // BlockedPatientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 413);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnUnblock);
            this.Controls.Add(this.tbBlocker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewBlockedPatients);
            this.Name = "BlockedPatientsForm";
            this.Text = "BlockedPatientsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlockedPatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBlockedPatients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbBlocker;
        private System.Windows.Forms.Button btnUnblock;
        private System.Windows.Forms.Label labelStatus;
    }
}