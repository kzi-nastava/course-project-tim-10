
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class AddReferralLetterForm
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
			this.specialisationComboBox = new System.Windows.Forms.ComboBox();
			this.doctorComboBox = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(63, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Patient:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(63, 165);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Specialisation:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(65, 231);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Doctor:";
			// 
			// patientFullNameLabel
			// 
			this.patientFullNameLabel.AutoSize = true;
			this.patientFullNameLabel.Location = new System.Drawing.Point(268, 103);
			this.patientFullNameLabel.Name = "patientFullNameLabel";
			this.patientFullNameLabel.Size = new System.Drawing.Size(0, 17);
			this.patientFullNameLabel.TabIndex = 3;
			// 
			// specialisationComboBox
			// 
			this.specialisationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.specialisationComboBox.FormattingEnabled = true;
			this.specialisationComboBox.Location = new System.Drawing.Point(271, 156);
			this.specialisationComboBox.Name = "specialisationComboBox";
			this.specialisationComboBox.Size = new System.Drawing.Size(148, 24);
			this.specialisationComboBox.TabIndex = 4;
			// 
			// doctorComboBox
			// 
			this.doctorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.doctorComboBox.FormattingEnabled = true;
			this.doctorComboBox.Location = new System.Drawing.Point(271, 228);
			this.doctorComboBox.Name = "doctorComboBox";
			this.doctorComboBox.Size = new System.Drawing.Size(148, 24);
			this.doctorComboBox.TabIndex = 5;
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
			// AddReferralLetterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.doctorComboBox);
			this.Controls.Add(this.specialisationComboBox);
			this.Controls.Add(this.patientFullNameLabel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "AddReferralLetterForm";
			this.Text = "AddReferralLetterForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label patientFullNameLabel;
		private System.Windows.Forms.ComboBox specialisationComboBox;
		private System.Windows.Forms.ComboBox doctorComboBox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}