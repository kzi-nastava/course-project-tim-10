﻿
namespace HealthCareInfromationSystem.view.PatientView
{
    partial class SearchDoctorForm
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
            this.searchDoctorsLbl = new System.Windows.Forms.Label();
            this.firstNameLbl = new System.Windows.Forms.Label();
            this.lastNameLbl = new System.Windows.Forms.Label();
            this.specialisationLbl = new System.Windows.Forms.Label();
            this.sortByLbl = new System.Windows.Forms.Label();
            this.firstNameTxt = new System.Windows.Forms.TextBox();
            this.lastNameTxt = new System.Windows.Forms.TextBox();
            this.specialisationsComboBox = new System.Windows.Forms.ComboBox();
            this.criteriaComboBox = new System.Windows.Forms.ComboBox();
            this.doctorsGrid = new System.Windows.Forms.DataGridView();
            this.showDoctorsBtn = new System.Windows.Forms.Button();
            this.createAppointmentBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchDoctorsLbl
            // 
            this.searchDoctorsLbl.AutoSize = true;
            this.searchDoctorsLbl.Location = new System.Drawing.Point(510, 31);
            this.searchDoctorsLbl.Name = "searchDoctorsLbl";
            this.searchDoctorsLbl.Size = new System.Drawing.Size(104, 17);
            this.searchDoctorsLbl.TabIndex = 0;
            this.searchDoctorsLbl.Text = "Search doctors";
            // 
            // firstNameLbl
            // 
            this.firstNameLbl.AutoSize = true;
            this.firstNameLbl.Location = new System.Drawing.Point(65, 96);
            this.firstNameLbl.Name = "firstNameLbl";
            this.firstNameLbl.Size = new System.Drawing.Size(78, 17);
            this.firstNameLbl.TabIndex = 1;
            this.firstNameLbl.Text = "First name:";
            // 
            // lastNameLbl
            // 
            this.lastNameLbl.AutoSize = true;
            this.lastNameLbl.Location = new System.Drawing.Point(65, 138);
            this.lastNameLbl.Name = "lastNameLbl";
            this.lastNameLbl.Size = new System.Drawing.Size(78, 17);
            this.lastNameLbl.TabIndex = 2;
            this.lastNameLbl.Text = "Last name:";
            // 
            // specialisationLbl
            // 
            this.specialisationLbl.AutoSize = true;
            this.specialisationLbl.Location = new System.Drawing.Point(65, 189);
            this.specialisationLbl.Name = "specialisationLbl";
            this.specialisationLbl.Size = new System.Drawing.Size(99, 17);
            this.specialisationLbl.TabIndex = 3;
            this.specialisationLbl.Text = "Specialisation:";
            // 
            // sortByLbl
            // 
            this.sortByLbl.AutoSize = true;
            this.sortByLbl.Location = new System.Drawing.Point(65, 430);
            this.sortByLbl.Name = "sortByLbl";
            this.sortByLbl.Size = new System.Drawing.Size(57, 17);
            this.sortByLbl.TabIndex = 4;
            this.sortByLbl.Text = "Sort by:";
            // 
            // firstNameTxt
            // 
            this.firstNameTxt.Location = new System.Drawing.Point(167, 96);
            this.firstNameTxt.Name = "firstNameTxt";
            this.firstNameTxt.Size = new System.Drawing.Size(147, 22);
            this.firstNameTxt.TabIndex = 5;
            // 
            // lastNameTxt
            // 
            this.lastNameTxt.Location = new System.Drawing.Point(167, 138);
            this.lastNameTxt.Name = "lastNameTxt";
            this.lastNameTxt.Size = new System.Drawing.Size(147, 22);
            this.lastNameTxt.TabIndex = 6;
            // 
            // specialisationsComboBox
            // 
            this.specialisationsComboBox.FormattingEnabled = true;
            this.specialisationsComboBox.Location = new System.Drawing.Point(170, 187);
            this.specialisationsComboBox.Name = "specialisationsComboBox";
            this.specialisationsComboBox.Size = new System.Drawing.Size(170, 24);
            this.specialisationsComboBox.TabIndex = 7;
            this.specialisationsComboBox.Text = "Choose specialisation";
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.FormattingEnabled = true;
            this.criteriaComboBox.Location = new System.Drawing.Point(140, 428);
            this.criteriaComboBox.Name = "criteriaComboBox";
            this.criteriaComboBox.Size = new System.Drawing.Size(174, 24);
            this.criteriaComboBox.TabIndex = 8;
            this.criteriaComboBox.Text = "Choose criteria";
            // 
            // doctorsGrid
            // 
            this.doctorsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doctorsGrid.Location = new System.Drawing.Point(399, 96);
            this.doctorsGrid.Name = "doctorsGrid";
            this.doctorsGrid.RowHeadersWidth = 51;
            this.doctorsGrid.RowTemplate.Height = 24;
            this.doctorsGrid.Size = new System.Drawing.Size(644, 204);
            this.doctorsGrid.TabIndex = 9;
            // 
            // showDoctorsBtn
            // 
            this.showDoctorsBtn.Location = new System.Drawing.Point(109, 269);
            this.showDoctorsBtn.Name = "showDoctorsBtn";
            this.showDoctorsBtn.Size = new System.Drawing.Size(157, 31);
            this.showDoctorsBtn.TabIndex = 10;
            this.showDoctorsBtn.Text = "Show doctors";
            this.showDoctorsBtn.UseVisualStyleBackColor = true;
            // 
            // createAppointmentBtn
            // 
            this.createAppointmentBtn.Location = new System.Drawing.Point(625, 423);
            this.createAppointmentBtn.Name = "createAppointmentBtn";
            this.createAppointmentBtn.Size = new System.Drawing.Size(171, 32);
            this.createAppointmentBtn.TabIndex = 11;
            this.createAppointmentBtn.Text = "Create appointment";
            this.createAppointmentBtn.UseVisualStyleBackColor = true;
            // 
            // SearchDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 526);
            this.Controls.Add(this.createAppointmentBtn);
            this.Controls.Add(this.showDoctorsBtn);
            this.Controls.Add(this.doctorsGrid);
            this.Controls.Add(this.criteriaComboBox);
            this.Controls.Add(this.specialisationsComboBox);
            this.Controls.Add(this.lastNameTxt);
            this.Controls.Add(this.firstNameTxt);
            this.Controls.Add(this.sortByLbl);
            this.Controls.Add(this.specialisationLbl);
            this.Controls.Add(this.lastNameLbl);
            this.Controls.Add(this.firstNameLbl);
            this.Controls.Add(this.searchDoctorsLbl);
            this.Name = "SearchDoctorForm";
            this.Text = "SearchDoctorForm";
            ((System.ComponentModel.ISupportInitialize)(this.doctorsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchDoctorsLbl;
        private System.Windows.Forms.Label firstNameLbl;
        private System.Windows.Forms.Label lastNameLbl;
        private System.Windows.Forms.Label specialisationLbl;
        private System.Windows.Forms.Label sortByLbl;
        private System.Windows.Forms.TextBox firstNameTxt;
        private System.Windows.Forms.TextBox lastNameTxt;
        private System.Windows.Forms.ComboBox specialisationsComboBox;
        private System.Windows.Forms.ComboBox criteriaComboBox;
        private System.Windows.Forms.DataGridView doctorsGrid;
        private System.Windows.Forms.Button showDoctorsBtn;
        private System.Windows.Forms.Button createAppointmentBtn;
    }
}