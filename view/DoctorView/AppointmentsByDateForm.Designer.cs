
namespace HealthCareInfromationSystem.view.DoctorView
{
	partial class AppointmentsByDateForm
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
			this.premiseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.patientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.patientLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.beggining = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.moreInfoBtn = new System.Windows.Forms.Button();
			this.amnesisBtn = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTextBox = new System.Windows.Forms.TextBox();
			this.searchBtn = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
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
			this.dataGridView1.Location = new System.Drawing.Point(41, 120);
			this.dataGridView1.MinimumSize = new System.Drawing.Size(1100, 450);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(1100, 456);
			this.dataGridView1.TabIndex = 0;
			// 
			// premiseName
			// 
			this.premiseName.HeaderText = "Premise Name";
			this.premiseName.MinimumWidth = 6;
			this.premiseName.Name = "premiseName";
			this.premiseName.ReadOnly = true;
			this.premiseName.Width = 125;
			// 
			// patientName
			// 
			this.patientName.HeaderText = "Patient Name";
			this.patientName.MinimumWidth = 6;
			this.patientName.Name = "patientName";
			this.patientName.ReadOnly = true;
			this.patientName.Width = 125;
			// 
			// patientLastName
			// 
			this.patientLastName.HeaderText = "Patient Last Name";
			this.patientLastName.MinimumWidth = 6;
			this.patientLastName.Name = "patientLastName";
			this.patientLastName.ReadOnly = true;
			this.patientLastName.Width = 125;
			// 
			// beggining
			// 
			this.beggining.HeaderText = "Beggining";
			this.beggining.MinimumWidth = 6;
			this.beggining.Name = "beggining";
			this.beggining.ReadOnly = true;
			this.beggining.Width = 125;
			// 
			// duration
			// 
			this.duration.HeaderText = "Duration (min)";
			this.duration.MinimumWidth = 6;
			this.duration.Name = "duration";
			this.duration.ReadOnly = true;
			this.duration.Width = 125;
			// 
			// type
			// 
			this.type.HeaderText = "Type";
			this.type.MinimumWidth = 6;
			this.type.Name = "type";
			this.type.ReadOnly = true;
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
			// moreInfoBtn
			// 
			this.moreInfoBtn.Location = new System.Drawing.Point(135, 619);
			this.moreInfoBtn.Name = "moreInfoBtn";
			this.moreInfoBtn.Size = new System.Drawing.Size(110, 45);
			this.moreInfoBtn.TabIndex = 1;
			this.moreInfoBtn.Text = "Patient info";
			this.moreInfoBtn.UseVisualStyleBackColor = true;
			this.moreInfoBtn.Click += new System.EventHandler(this.MoreInfoBtnClick);
			// 
			// amnesisBtn
			// 
			this.amnesisBtn.Location = new System.Drawing.Point(375, 619);
			this.amnesisBtn.Name = "amnesisBtn";
			this.amnesisBtn.Size = new System.Drawing.Size(110, 45);
			this.amnesisBtn.TabIndex = 3;
			this.amnesisBtn.Text = "Preforme examination";
			this.amnesisBtn.UseVisualStyleBackColor = true;
			this.amnesisBtn.Click += new System.EventHandler(this.AmnesisBtnClick);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(907, 619);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(110, 45);
			this.button4.TabIndex = 4;
			this.button4.Text = "Cancel";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.CancelClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(105, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 17);
			this.label1.TabIndex = 5;
			this.label1.Text = "Date (dd.MM.yyyy.):";
			// 
			// dateTextBox
			// 
			this.dateTextBox.Location = new System.Drawing.Point(263, 41);
			this.dateTextBox.Name = "dateTextBox";
			this.dateTextBox.Size = new System.Drawing.Size(149, 22);
			this.dateTextBox.TabIndex = 6;
			// 
			// searchBtn
			// 
			this.searchBtn.Location = new System.Drawing.Point(510, 31);
			this.searchBtn.Name = "searchBtn";
			this.searchBtn.Size = new System.Drawing.Size(84, 37);
			this.searchBtn.TabIndex = 7;
			this.searchBtn.Text = "Search";
			this.searchBtn.UseVisualStyleBackColor = true;
			this.searchBtn.Click += new System.EventHandler(this.SearchBtnClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(615, 619);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(110, 45);
			this.button1.TabIndex = 8;
			this.button1.Text = "Referral Letter";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.ReferralLetterClick);
			// 
			// AppointmentsByDateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 753);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.searchBtn);
			this.Controls.Add(this.dateTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.amnesisBtn);
			this.Controls.Add(this.moreInfoBtn);
			this.Controls.Add(this.dataGridView1);
			this.MinimumSize = new System.Drawing.Size(1200, 800);
			this.Name = "AppointmentsByDateForm";
			this.Text = "MainWindowDoctor";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button moreInfoBtn;
		private System.Windows.Forms.Button amnesisBtn;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridViewTextBoxColumn premiseName;
		private System.Windows.Forms.DataGridViewTextBoxColumn patientName;
		private System.Windows.Forms.DataGridViewTextBoxColumn patientLastName;
		private System.Windows.Forms.DataGridViewTextBoxColumn beggining;
		private System.Windows.Forms.DataGridViewTextBoxColumn duration;
		private System.Windows.Forms.DataGridViewTextBoxColumn type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox dateTextBox;
		private System.Windows.Forms.Button searchBtn;
		private System.Windows.Forms.Button button1;
	}
}
