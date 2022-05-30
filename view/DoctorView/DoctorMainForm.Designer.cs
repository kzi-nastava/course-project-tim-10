
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class DoctorMainForm
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.dateAppoinmentsBtn = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.flowLayoutPanel1.Controls.Add(this.dateAppoinmentsBtn);
			this.flowLayoutPanel1.Controls.Add(this.button3);
			this.flowLayoutPanel1.Controls.Add(this.button4);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 322);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(129, 49);
			this.button1.TabIndex = 2;
			this.button1.Text = "All Appointments";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.AllAppointmentsButtonClick);
			// 
			// dateAppoinmentsBtn
			// 
			this.dateAppoinmentsBtn.Location = new System.Drawing.Point(3, 58);
			this.dateAppoinmentsBtn.Name = "dateAppoinmentsBtn";
			this.dateAppoinmentsBtn.Size = new System.Drawing.Size(129, 49);
			this.dateAppoinmentsBtn.TabIndex = 3;
			this.dateAppoinmentsBtn.Text = "Appointments For Date";
			this.dateAppoinmentsBtn.UseVisualStyleBackColor = true;
			this.dateAppoinmentsBtn.Click += new System.EventHandler(this.DateAppoinmentsBtnClick);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(3, 113);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(129, 49);
			this.button3.TabIndex = 4;
			this.button3.Text = "Unverified Medicine";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.UnverifiedMedicineClick);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(3, 168);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(129, 49);
			this.button4.TabIndex = 3;
			this.button4.Text = "button4";
			this.button4.UseVisualStyleBackColor = true;
			// 
			// DoctorMainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 322);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Name = "DoctorMainForm";
			this.Text = "MainDoctor";
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button dateAppoinmentsBtn;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
	}
}