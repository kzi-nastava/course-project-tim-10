
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class RescheduleAppointmentForm
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
            this.dataGridViewAppointments = new System.Windows.Forms.DataGridView();
            this.ColumnBeginning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRescheduledBeginning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDoctor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnReschedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAppointments
            // 
            this.dataGridViewAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnBeginning,
            this.ColumnDuration,
            this.ColumnRescheduledBeginning,
            this.ColumnDoctor,
            this.ColumnPatient});
            this.dataGridViewAppointments.Location = new System.Drawing.Point(31, 32);
            this.dataGridViewAppointments.Name = "dataGridViewAppointments";
            this.dataGridViewAppointments.RowHeadersWidth = 62;
            this.dataGridViewAppointments.RowTemplate.Height = 28;
            this.dataGridViewAppointments.Size = new System.Drawing.Size(816, 378);
            this.dataGridViewAppointments.TabIndex = 0;
            // 
            // ColumnBeginning
            // 
            this.ColumnBeginning.HeaderText = "Original Beginning";
            this.ColumnBeginning.MinimumWidth = 8;
            this.ColumnBeginning.Name = "ColumnBeginning";
            this.ColumnBeginning.Width = 150;
            // 
            // ColumnDuration
            // 
            this.ColumnDuration.HeaderText = "Duration";
            this.ColumnDuration.MinimumWidth = 8;
            this.ColumnDuration.Name = "ColumnDuration";
            this.ColumnDuration.Width = 150;
            // 
            // ColumnRescheduledBeginning
            // 
            this.ColumnRescheduledBeginning.HeaderText = "Rescheduled Beginning";
            this.ColumnRescheduledBeginning.MinimumWidth = 8;
            this.ColumnRescheduledBeginning.Name = "ColumnRescheduledBeginning";
            this.ColumnRescheduledBeginning.Width = 150;
            // 
            // ColumnDoctor
            // 
            this.ColumnDoctor.HeaderText = "Doctor";
            this.ColumnDoctor.MinimumWidth = 8;
            this.ColumnDoctor.Name = "ColumnDoctor";
            this.ColumnDoctor.Width = 150;
            // 
            // ColumnPatient
            // 
            this.ColumnPatient.HeaderText = "Patient";
            this.ColumnPatient.MinimumWidth = 8;
            this.ColumnPatient.Name = "ColumnPatient";
            this.ColumnPatient.Width = 150;
            // 
            // btnReschedule
            // 
            this.btnReschedule.Location = new System.Drawing.Point(370, 428);
            this.btnReschedule.Name = "btnReschedule";
            this.btnReschedule.Size = new System.Drawing.Size(161, 55);
            this.btnReschedule.TabIndex = 1;
            this.btnReschedule.Text = "Reschedule";
            this.btnReschedule.UseVisualStyleBackColor = true;
            this.btnReschedule.Click += new System.EventHandler(this.BtnReschedule_Click);
            // 
            // RescheduleAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 505);
            this.Controls.Add(this.btnReschedule);
            this.Controls.Add(this.dataGridViewAppointments);
            this.Name = "RescheduleAppointmentForm";
            this.Text = "RescheduleAppointmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAppointments;
        private System.Windows.Forms.Button btnReschedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBeginning;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRescheduledBeginning;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatient;
    }
}