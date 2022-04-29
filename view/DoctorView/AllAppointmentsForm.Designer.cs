
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class AllAppointmentsForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.premiseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.patientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.patientLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.beggining = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
			this.premiseName,
			this.patientName,
			this.patientLastName,
			this.beggining,
			this.duration,
			this.type,
			this.Id});
			this.dataGridView1.Location = new System.Drawing.Point(39, 34);
			this.dataGridView1.MinimumSize = new System.Drawing.Size(1100, 550);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1100, 550);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(135, 619);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(110, 45);
			this.button1.TabIndex = 1;
			this.button1.Text = "Add";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(644, 619);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(110, 45);
			this.button2.TabIndex = 2;
			this.button2.Text = "Delete";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.DeleteButtonClick);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(375, 619);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(110, 45);
			this.button3.TabIndex = 3;
			this.button3.Text = "Edit";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.EditButtonClick);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(907, 619);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(110, 45);
			this.button4.TabIndex = 4;
			this.button4.Text = "Cancel";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.CancleButtonClick);
			// 
			// premiseName
			// 
			this.premiseName.HeaderText = "Premise Name";
			this.premiseName.MinimumWidth = 6;
			this.premiseName.Name = "premiseName";
			this.premiseName.Width = 125;
			// 
			// patientName
			// 
			this.patientName.HeaderText = "Patient Name";
			this.patientName.MinimumWidth = 6;
			this.patientName.Name = "patientName";
			this.patientName.Width = 125;
			// 
			// patientLastName
			// 
			this.patientLastName.HeaderText = "Patient Last Name";
			this.patientLastName.MinimumWidth = 6;
			this.patientLastName.Name = "patientLastName";
			this.patientLastName.Width = 125;
			// 
			// beggining
			// 
			this.beggining.HeaderText = "Beggining";
			this.beggining.MinimumWidth = 6;
			this.beggining.Name = "beggining";
			this.beggining.Width = 125;
			// 
			// duration
			// 
			this.duration.HeaderText = "Duration (min)";
			this.duration.MinimumWidth = 6;
			this.duration.Name = "duration";
			this.duration.Width = 125;
			// 
			// type
			// 
			this.type.HeaderText = "Type";
			this.type.MinimumWidth = 6;
			this.type.Name = "type";
			this.type.Width = 125;
			// 
			// Id
			// 
			this.Id.HeaderText = "Appointment Id";
			this.Id.MinimumWidth = 6;
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Width = 125;
			// 
			// TableAppointments
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 753);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.MinimumSize = new System.Drawing.Size(1200, 800);
			this.Name = "TableAppointments";
			this.Text = "MainWindowDoctor";
			this.Load += new System.EventHandler(this.TableAppointments_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridViewTextBoxColumn premiseName;
		private System.Windows.Forms.DataGridViewTextBoxColumn patientName;
		private System.Windows.Forms.DataGridViewTextBoxColumn patientLastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn beggining;
		private System.Windows.Forms.DataGridViewTextBoxColumn duration;
		private System.Windows.Forms.DataGridViewTextBoxColumn type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
	}
}