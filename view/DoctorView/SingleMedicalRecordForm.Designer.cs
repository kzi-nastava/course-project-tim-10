
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class SingleMedicalRecordForm
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
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.heightTextBox = new System.Windows.Forms.TextBox();
			this.alergiesTextBox = new System.Windows.Forms.TextBox();
			this.diseaseTextBox = new System.Windows.Forms.TextBox();
			this.weightTextBox = new System.Windows.Forms.TextBox();
			this.bloodTypeComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(121, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Height:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(121, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Weight:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(121, 152);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Blood type";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(126, 208);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Diseases:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(126, 279);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Alergies";
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(170, 343);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(96, 39);
			this.saveBtn.TabIndex = 5;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(514, 343);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(96, 39);
			this.cancelBtn.TabIndex = 6;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// heightTextBox
			// 
			this.heightTextBox.Location = new System.Drawing.Point(348, 41);
			this.heightTextBox.Name = "heightTextBox";
			this.heightTextBox.Size = new System.Drawing.Size(121, 22);
			this.heightTextBox.TabIndex = 7;
			// 
			// alergiesTextBox
			// 
			this.alergiesTextBox.Location = new System.Drawing.Point(348, 274);
			this.alergiesTextBox.Name = "alergiesTextBox";
			this.alergiesTextBox.Size = new System.Drawing.Size(362, 22);
			this.alergiesTextBox.TabIndex = 8;
			// 
			// diseaseTextBox
			// 
			this.diseaseTextBox.Location = new System.Drawing.Point(348, 208);
			this.diseaseTextBox.Name = "diseaseTextBox";
			this.diseaseTextBox.Size = new System.Drawing.Size(362, 22);
			this.diseaseTextBox.TabIndex = 9;
			// 
			// weightTextBox
			// 
			this.weightTextBox.Location = new System.Drawing.Point(348, 93);
			this.weightTextBox.Name = "weightTextBox";
			this.weightTextBox.Size = new System.Drawing.Size(121, 22);
			this.weightTextBox.TabIndex = 10;
			// 
			// bloodTypeComboBox
			// 
			this.bloodTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.bloodTypeComboBox.FormattingEnabled = true;
			this.bloodTypeComboBox.Location = new System.Drawing.Point(348, 145);
			this.bloodTypeComboBox.Name = "bloodTypeComboBox";
			this.bloodTypeComboBox.Size = new System.Drawing.Size(121, 24);
			this.bloodTypeComboBox.TabIndex = 11;
			// 
			// MedicalRecordWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.bloodTypeComboBox);
			this.Controls.Add(this.weightTextBox);
			this.Controls.Add(this.diseaseTextBox);
			this.Controls.Add(this.alergiesTextBox);
			this.Controls.Add(this.heightTextBox);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "MedicalRecordWindow";
			this.Text = "MedicalRecordWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.TextBox heightTextBox;
		private System.Windows.Forms.TextBox alergiesTextBox;
		private System.Windows.Forms.TextBox diseaseTextBox;
		private System.Windows.Forms.TextBox weightTextBox;
		private System.Windows.Forms.ComboBox bloodTypeComboBox;
	}
}