
namespace HealthCareInfromationSystem
{
    partial class AppointmentForm
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
            this.aboutAppointmentLabel = new System.Windows.Forms.Label();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimeTxt = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.doctorsGrid = new System.Windows.Forms.DataGridView();
            this.showDoctorsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutAppointmentLabel
            // 
            this.aboutAppointmentLabel.AutoSize = true;
            this.aboutAppointmentLabel.Location = new System.Drawing.Point(322, 24);
            this.aboutAppointmentLabel.Name = "aboutAppointmentLabel";
            this.aboutAppointmentLabel.Size = new System.Drawing.Size(131, 17);
            this.aboutAppointmentLabel.TabIndex = 0;
            this.aboutAppointmentLabel.Text = "About appointment:";
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = true;
            this.dateTimeLabel.Location = new System.Drawing.Point(55, 93);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(140, 17);
            this.dateTimeLabel.TabIndex = 1;
            this.dateTimeLabel.Text = "Enter date and time: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select doctor:";
            // 
            // dateTimeTxt
            // 
            this.dateTimeTxt.Location = new System.Drawing.Point(213, 93);
            this.dateTimeTxt.Name = "dateTimeTxt";
            this.dateTimeTxt.Size = new System.Drawing.Size(145, 22);
            this.dateTimeTxt.TabIndex = 3;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(340, 395);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 30);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // doctorsGrid
            // 
            this.doctorsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorsGrid.Location = new System.Drawing.Point(36, 168);
            this.doctorsGrid.Name = "doctorsGrid";
            this.doctorsGrid.RowHeadersWidth = 51;
            this.doctorsGrid.RowTemplate.Height = 24;
            this.doctorsGrid.Size = new System.Drawing.Size(728, 174);
            this.doctorsGrid.TabIndex = 6;
            this.doctorsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoctorsGrid_CellContentClick);
            // 
            // showDoctorsButton
            // 
            this.showDoctorsButton.Location = new System.Drawing.Point(450, 91);
            this.showDoctorsButton.Name = "showDoctorsButton";
            this.showDoctorsButton.Size = new System.Drawing.Size(204, 26);
            this.showDoctorsButton.TabIndex = 7;
            this.showDoctorsButton.Text = "Show available doctors";
            this.showDoctorsButton.UseVisualStyleBackColor = true;
            this.showDoctorsButton.Click += new System.EventHandler(this.ShowDoctorsButton_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showDoctorsButton);
            this.Controls.Add(this.doctorsGrid);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.dateTimeTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.aboutAppointmentLabel);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aboutAppointmentLabel;
        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dateTimeTxt;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.DataGridView doctorsGrid;
        private System.Windows.Forms.Button showDoctorsButton;
    }
}