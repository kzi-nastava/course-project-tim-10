
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class AddPrescriptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.patientFullNameLabel = new System.Windows.Forms.Label();
            this.medicineComboBox = new System.Windows.Forms.ComboBox();
            this.periodComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.periodTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Medicines:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time taking: (HH:mm)";
            // 
            // patientFullNameLabel
            // 
            this.patientFullNameLabel.AutoSize = true;
            this.patientFullNameLabel.Location = new System.Drawing.Point(289, 41);
            this.patientFullNameLabel.Name = "patientFullNameLabel";
            this.patientFullNameLabel.Size = new System.Drawing.Size(0, 17);
            this.patientFullNameLabel.TabIndex = 3;
            // 
            // medicineComboBox
            // 
            this.medicineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.medicineComboBox.FormattingEnabled = true;
            this.medicineComboBox.Location = new System.Drawing.Point(292, 104);
            this.medicineComboBox.Name = "medicineComboBox";
            this.medicineComboBox.Size = new System.Drawing.Size(148, 24);
            this.medicineComboBox.TabIndex = 4;
            // 
            // periodComboBox
            // 
            this.periodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodComboBox.FormattingEnabled = true;
            this.periodComboBox.Location = new System.Drawing.Point(550, 170);
            this.periodComboBox.Name = "periodComboBox";
            this.periodComboBox.Size = new System.Drawing.Size(148, 24);
            this.periodComboBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 343);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SaveClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 343);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 46);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.CancelClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantity:";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(292, 234);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(148, 22);
            this.quantityTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date: (dd.MM.yyyy.)";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(292, 293);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(148, 22);
            this.dateTextBox.TabIndex = 11;
            // 
            // periodTextBox
            // 
            this.periodTextBox.Location = new System.Drawing.Point(292, 168);
            this.periodTextBox.Name = "periodTextBox";
            this.periodTextBox.Size = new System.Drawing.Size(148, 22);
            this.periodTextBox.TabIndex = 12;
            // 
            // AddPrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.periodTextBox);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.periodComboBox);
            this.Controls.Add(this.medicineComboBox);
            this.Controls.Add(this.patientFullNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddPrescriptionForm";
            this.Text = "AddReferralLetterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label patientFullNameLabel;
		private System.Windows.Forms.ComboBox medicineComboBox;
		private System.Windows.Forms.ComboBox periodComboBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox quantityTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TextBox periodTextBox;
    }
}