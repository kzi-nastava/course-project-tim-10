﻿
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class AnamnesisInputForm
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
			this.saveBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.anamnesisTextBox = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// saveBtn
			// 
			this.saveBtn.Location = new System.Drawing.Point(85, 334);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(127, 45);
			this.saveBtn.TabIndex = 0;
			this.saveBtn.Text = "Save";
			this.saveBtn.UseVisualStyleBackColor = true;
			this.saveBtn.Click += new System.EventHandler(this.SaveBtnClick);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(586, 334);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(127, 45);
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.UseVisualStyleBackColor = true;
			this.cancelBtn.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(82, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Amnesis:";
			// 
			// anamnesisTextBox
			// 
			this.anamnesisTextBox.Location = new System.Drawing.Point(213, 87);
			this.anamnesisTextBox.Multiline = true;
			this.anamnesisTextBox.Name = "anamnesisTextBox";
			this.anamnesisTextBox.Size = new System.Drawing.Size(376, 164);
			this.anamnesisTextBox.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(330, 334);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(127, 45);
			this.button1.TabIndex = 4;
			this.button1.Text = "Add prescription";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.AddPrescriptionBtnClick);
			// 
			// AnamnesisInputForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.anamnesisTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.saveBtn);
			this.Name = "AnamnesisInputForm";
			this.Text = "AmnesisInputWindow";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.Button cancelBtn;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox anamnesisTextBox;
		private System.Windows.Forms.Button button1;
	}
}