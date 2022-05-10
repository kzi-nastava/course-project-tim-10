
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class BookingByReferralForm
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
            this.dataGridViewPatients = new System.Windows.Forms.DataGridView();
            this.dataGridViewReferrals = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAssignTime = new System.Windows.Forms.Button();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferrals)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPatients
            // 
            this.dataGridViewPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPatients.Location = new System.Drawing.Point(39, 55);
            this.dataGridViewPatients.Name = "dataGridViewPatients";
            this.dataGridViewPatients.RowHeadersWidth = 62;
            this.dataGridViewPatients.RowTemplate.Height = 28;
            this.dataGridViewPatients.Size = new System.Drawing.Size(500, 495);
            this.dataGridViewPatients.TabIndex = 0;
            this.dataGridViewPatients.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewPatients_RowHeaderMouseClick);
            // 
            // dataGridViewReferrals
            // 
            this.dataGridViewReferrals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReferrals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnDate,
            this.ColumnCreator});
            this.dataGridViewReferrals.Location = new System.Drawing.Point(628, 55);
            this.dataGridViewReferrals.Name = "dataGridViewReferrals";
            this.dataGridViewReferrals.RowHeadersWidth = 62;
            this.dataGridViewReferrals.RowTemplate.Height = 28;
            this.dataGridViewReferrals.Size = new System.Drawing.Size(618, 368);
            this.dataGridViewReferrals.TabIndex = 1;
            this.dataGridViewReferrals.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewReferrals_RowHeaderMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Patients";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Referral Letters";
            // 
            // btnAssignTime
            // 
            this.btnAssignTime.Location = new System.Drawing.Point(895, 449);
            this.btnAssignTime.Name = "btnAssignTime";
            this.btnAssignTime.Size = new System.Drawing.Size(116, 41);
            this.btnAssignTime.TabIndex = 4;
            this.btnAssignTime.Text = "Assign time";
            this.btnAssignTime.UseVisualStyleBackColor = true;
            this.btnAssignTime.Click += new System.EventHandler(this.BtnAssignTime_Click);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "ID";
            this.ColumnId.MinimumWidth = 8;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Width = 150;
            // 
            // ColumnDate
            // 
            this.ColumnDate.HeaderText = "Date Created";
            this.ColumnDate.MinimumWidth = 8;
            this.ColumnDate.Name = "ColumnDate";
            this.ColumnDate.Width = 150;
            // 
            // ColumnCreator
            // 
            this.ColumnCreator.HeaderText = "Created by";
            this.ColumnCreator.MinimumWidth = 8;
            this.ColumnCreator.Name = "ColumnCreator";
            this.ColumnCreator.Width = 150;
            // 
            // BookingByReferralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 614);
            this.Controls.Add(this.btnAssignTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewReferrals);
            this.Controls.Add(this.dataGridViewPatients);
            this.Name = "BookingByReferralForm";
            this.Text = "BookingByReferralForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReferrals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPatients;
        private System.Windows.Forms.DataGridView dataGridViewReferrals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAssignTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreator;
    }
}