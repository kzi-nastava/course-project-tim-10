
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class AddVacationRequestForm
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
			this.beginningTextBox = new System.Windows.Forms.TextBox();
			this.reasonTextBox = new System.Windows.Forms.TextBox();
			this.endingTextBox = new System.Windows.Forms.TextBox();
			this.isUrgentCheckBox = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(103, 66);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Beginning:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(103, 124);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Ending:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(103, 186);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Reason:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(103, 258);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Is urgent:";
			// 
			// beginningTextBox
			// 
			this.beginningTextBox.Location = new System.Drawing.Point(322, 66);
			this.beginningTextBox.Name = "beginningTextBox";
			this.beginningTextBox.Size = new System.Drawing.Size(138, 22);
			this.beginningTextBox.TabIndex = 5;
			// 
			// reasonTextBox
			// 
			this.reasonTextBox.Location = new System.Drawing.Point(320, 186);
			this.reasonTextBox.Name = "reasonTextBox";
			this.reasonTextBox.Size = new System.Drawing.Size(140, 22);
			this.reasonTextBox.TabIndex = 6;
			// 
			// endingTextBox
			// 
			this.endingTextBox.Location = new System.Drawing.Point(320, 124);
			this.endingTextBox.Name = "endingTextBox";
			this.endingTextBox.Size = new System.Drawing.Size(140, 22);
			this.endingTextBox.TabIndex = 7;
			// 
			// isUrgentCheckBox
			// 
			this.isUrgentCheckBox.AutoSize = true;
			this.isUrgentCheckBox.Location = new System.Drawing.Point(322, 258);
			this.isUrgentCheckBox.Name = "isUrgentCheckBox";
			this.isUrgentCheckBox.Size = new System.Drawing.Size(18, 17);
			this.isUrgentCheckBox.TabIndex = 8;
			this.isUrgentCheckBox.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(22, 310);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(168, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "Date format: dd.MM.yyyy.";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(106, 367);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 34);
			this.button1.TabIndex = 10;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.SaveBtnClick);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(376, 367);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(84, 34);
			this.button2.TabIndex = 11;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.CancelBtnClick);
			// 
			// AddVacationRequestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.isUrgentCheckBox);
			this.Controls.Add(this.endingTextBox);
			this.Controls.Add(this.reasonTextBox);
			this.Controls.Add(this.beginningTextBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "AddVacationRequestForm";
			this.Text = "AddVacationRequestForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox beginningTextBox;
		private System.Windows.Forms.TextBox reasonTextBox;
		private System.Windows.Forms.TextBox endingTextBox;
		private System.Windows.Forms.CheckBox isUrgentCheckBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}