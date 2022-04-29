
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class EdditAppointmentForm
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
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.premiseComboBox = new System.Windows.Forms.ComboBox();
			this.patientComboBox = new System.Windows.Forms.ComboBox();
			this.beginningTextBox = new System.Windows.Forms.TextBox();
			this.durationTextBox = new System.Windows.Forms.TextBox();
			this.typeComboBox = new System.Windows.Forms.ComboBox();
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(102, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Premise:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(102, 69);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Patient:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(102, 112);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(221, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Beginning (dd.MM.yyyy. HH:mm) :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(102, 157);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Duration:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(102, 202);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Type:";
			// 
			// premiseComboBox
			// 
			this.premiseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.premiseComboBox.FormattingEnabled = true;
			this.premiseComboBox.Location = new System.Drawing.Point(409, 19);
			this.premiseComboBox.Name = "premiseComboBox";
			this.premiseComboBox.Size = new System.Drawing.Size(176, 24);
			this.premiseComboBox.TabIndex = 5;
			// 
			// patientComboBox
			// 
			this.patientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.patientComboBox.FormattingEnabled = true;
			this.patientComboBox.Location = new System.Drawing.Point(409, 62);
			this.patientComboBox.Name = "patientComboBox";
			this.patientComboBox.Size = new System.Drawing.Size(176, 24);
			this.patientComboBox.TabIndex = 6;
			// 
			// beginningTextBox
			// 
			this.beginningTextBox.Location = new System.Drawing.Point(409, 107);
			this.beginningTextBox.Name = "beginningTextBox";
			this.beginningTextBox.Size = new System.Drawing.Size(176, 22);
			this.beginningTextBox.TabIndex = 7;
			// 
			// durationTextBox
			// 
			this.durationTextBox.Location = new System.Drawing.Point(409, 152);
			this.durationTextBox.Name = "durationTextBox";
			this.durationTextBox.Size = new System.Drawing.Size(176, 22);
			this.durationTextBox.TabIndex = 8;
			// 
			// typeComboBox
			// 
			this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeComboBox.FormattingEnabled = true;
			this.typeComboBox.Location = new System.Drawing.Point(409, 195);
			this.typeComboBox.Name = "typeComboBox";
			this.typeComboBox.Size = new System.Drawing.Size(176, 24);
			this.typeComboBox.TabIndex = 9;
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(178, 257);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(84, 38);
			this.saveBtn.TabIndex = 10;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(409, 257);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(84, 38);
			this.cancelBtn.TabIndex = 11;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// EdditAppointment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(642, 327);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.typeComboBox);
			this.Controls.Add(this.durationTextBox);
			this.Controls.Add(this.beginningTextBox);
			this.Controls.Add(this.patientComboBox);
			this.Controls.Add(this.premiseComboBox);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "EdditAppointment";
			this.Text = "EdditAppointment";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox premiseComboBox;
		private System.Windows.Forms.ComboBox patientComboBox;
		private System.Windows.Forms.TextBox beginningTextBox;
		private System.Windows.Forms.TextBox durationTextBox;
		private System.Windows.Forms.ComboBox typeComboBox;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
	}
}