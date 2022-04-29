
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class AppointmentRequestForm
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
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPreviousTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNewTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNewDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnReqTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnDecline = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnPatientId,
            this.ColumnPatientName,
            this.ColumnPreviousTime,
            this.ColumnType,
            this.ColumnNewTime,
            this.ColumnNewDoctor,
            this.ColumnReqTime});
            this.dataGridViewRequests.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.ReadOnly = true;
            this.dataGridViewRequests.Size = new System.Drawing.Size(843, 315);
            this.dataGridViewRequests.TabIndex = 0;
            this.dataGridViewRequests.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRequests_RowHeaderMouseClick);
            // 
            // ColumnId
            // 
            this.ColumnId.HeaderText = "Request Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // ColumnPatientId
            // 
            this.ColumnPatientId.HeaderText = "Patient Id";
            this.ColumnPatientId.Name = "ColumnPatientId";
            this.ColumnPatientId.ReadOnly = true;
            // 
            // ColumnPatientName
            // 
            this.ColumnPatientName.HeaderText = "Patient Name";
            this.ColumnPatientName.Name = "ColumnPatientName";
            this.ColumnPatientName.ReadOnly = true;
            // 
            // ColumnPreviousTime
            // 
            this.ColumnPreviousTime.HeaderText = "Previous time";
            this.ColumnPreviousTime.Name = "ColumnPreviousTime";
            this.ColumnPreviousTime.ReadOnly = true;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type Of Request";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // ColumnNewTime
            // 
            this.ColumnNewTime.HeaderText = "New time";
            this.ColumnNewTime.Name = "ColumnNewTime";
            this.ColumnNewTime.ReadOnly = true;
            // 
            // ColumnNewDoctor
            // 
            this.ColumnNewDoctor.HeaderText = "New Doctor";
            this.ColumnNewDoctor.Name = "ColumnNewDoctor";
            this.ColumnNewDoctor.ReadOnly = true;
            // 
            // ColumnReqTime
            // 
            this.ColumnReqTime.HeaderText = "Request time";
            this.ColumnReqTime.Name = "ColumnReqTime";
            this.ColumnReqTime.ReadOnly = true;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(129, 367);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(89, 34);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.BtnAccept_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(286, 367);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(92, 35);
            this.btnDecline.TabIndex = 2;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseVisualStyleBackColor = true;
            this.btnDecline.Click += new System.EventHandler(this.BtnDecline_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(435, 389);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(43, 13);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "Status: ";
            // 
            // AppointmentRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 450);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dataGridViewRequests);
            this.Name = "AppointmentRequestForm";
            this.Text = "AppointmentRequestForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnDecline;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPreviousTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNewTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNewDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnReqTime;
        private System.Windows.Forms.Label labelStatus;
    }
}