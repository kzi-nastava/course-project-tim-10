
namespace HealthCareInfromationSystem.view.PatientView
{
    partial class PatientMainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chooseOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPriorityAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anamnesisReviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchDoctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationTimeLbl = new System.Windows.Forms.Label();
            this.notificationTimeTxt = new System.Windows.Forms.TextBox();
            this.setNotificationTimeButton = new System.Windows.Forms.Button();
            this.welcomeLbl = new System.Windows.Forms.Label();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pollHospitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseOptionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chooseOptionToolStripMenuItem
            // 
            this.chooseOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appointmentReviewToolStripMenuItem,
            this.createAppointmentToolStripMenuItem,
            this.createPriorityAppointmentToolStripMenuItem,
            this.anamnesisReviewToolStripMenuItem,
            this.searchDoctorsToolStripMenuItem,
            this.pollHospitalToolStripMenuItem});
            this.chooseOptionToolStripMenuItem.Name = "chooseOptionToolStripMenuItem";
            this.chooseOptionToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.chooseOptionToolStripMenuItem.Text = "Options";
            // 
            // appointmentReviewToolStripMenuItem
            // 
            this.appointmentReviewToolStripMenuItem.Name = "appointmentReviewToolStripMenuItem";
            this.appointmentReviewToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.appointmentReviewToolStripMenuItem.Text = "Appointment review";
            this.appointmentReviewToolStripMenuItem.Click += new System.EventHandler(this.AppointmentReviewToolStripMenuItem_Click);
            // 
            // createAppointmentToolStripMenuItem
            // 
            this.createAppointmentToolStripMenuItem.Name = "createAppointmentToolStripMenuItem";
            this.createAppointmentToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.createAppointmentToolStripMenuItem.Text = "Create appointment";
            this.createAppointmentToolStripMenuItem.Click += new System.EventHandler(this.CreateAppointmentToolStripMenuItem_Click);
            // 
            // createPriorityAppointmentToolStripMenuItem
            // 
            this.createPriorityAppointmentToolStripMenuItem.Name = "createPriorityAppointmentToolStripMenuItem";
            this.createPriorityAppointmentToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.createPriorityAppointmentToolStripMenuItem.Text = "Create priority appointment";
            this.createPriorityAppointmentToolStripMenuItem.Click += new System.EventHandler(this.CreatePriorityAppointmentToolStripMenuItem_Click);
            // 
            // anamnesisReviewToolStripMenuItem
            // 
            this.anamnesisReviewToolStripMenuItem.Name = "anamnesisReviewToolStripMenuItem";
            this.anamnesisReviewToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.anamnesisReviewToolStripMenuItem.Text = "Anamnesis review";
            this.anamnesisReviewToolStripMenuItem.Click += new System.EventHandler(this.AnamnesisReviewToolStripMenuItem_Click);
            // 
            // searchDoctorsToolStripMenuItem
            // 
            this.searchDoctorsToolStripMenuItem.Name = "searchDoctorsToolStripMenuItem";
            this.searchDoctorsToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.searchDoctorsToolStripMenuItem.Text = "Search doctors";
            this.searchDoctorsToolStripMenuItem.Click += new System.EventHandler(this.SearchDoctorsToolStripMenuItem_Click);
            // 
            // notificationTimeLbl
            // 
            this.notificationTimeLbl.AutoSize = true;
            this.notificationTimeLbl.Location = new System.Drawing.Point(338, 269);
            this.notificationTimeLbl.Name = "notificationTimeLbl";
            this.notificationTimeLbl.Size = new System.Drawing.Size(112, 17);
            this.notificationTimeLbl.TabIndex = 1;
            this.notificationTimeLbl.Text = "Notification time:";
            // 
            // notificationTimeTxt
            // 
            this.notificationTimeTxt.Location = new System.Drawing.Point(456, 266);
            this.notificationTimeTxt.Name = "notificationTimeTxt";
            this.notificationTimeTxt.Size = new System.Drawing.Size(153, 22);
            this.notificationTimeTxt.TabIndex = 2;
            // 
            // setNotificationTimeButton
            // 
            this.setNotificationTimeButton.Location = new System.Drawing.Point(412, 306);
            this.setNotificationTimeButton.Name = "setNotificationTimeButton";
            this.setNotificationTimeButton.Size = new System.Drawing.Size(89, 34);
            this.setNotificationTimeButton.TabIndex = 3;
            this.setNotificationTimeButton.Text = "Set time";
            this.setNotificationTimeButton.UseVisualStyleBackColor = true;
            this.setNotificationTimeButton.Click += new System.EventHandler(this.SetNotificationTimeButton_Click);
            // 
            // welcomeLbl
            // 
            this.welcomeLbl.AutoSize = true;
            this.welcomeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.welcomeLbl.Location = new System.Drawing.Point(275, 56);
            this.welcomeLbl.Name = "welcomeLbl";
            this.welcomeLbl.Size = new System.Drawing.Size(104, 26);
            this.welcomeLbl.TabIndex = 4;
            this.welcomeLbl.Text = "Welcome";
            // 
            // notify
            // 
            this.notify.Text = "Tekst koji se prikazuje";
            this.notify.Visible = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pollHospitalToolStripMenuItem
            // 
            this.pollHospitalToolStripMenuItem.Name = "pollHospitalToolStripMenuItem";
            this.pollHospitalToolStripMenuItem.Size = new System.Drawing.Size(277, 26);
            this.pollHospitalToolStripMenuItem.Text = "Poll hospital";
            this.pollHospitalToolStripMenuItem.Click += new System.EventHandler(this.PollHospitalToolStripMenuItem_Click);
            // 
            // PatientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 368);
            this.Controls.Add(this.welcomeLbl);
            this.Controls.Add(this.setNotificationTimeButton);
            this.Controls.Add(this.notificationTimeTxt);
            this.Controls.Add(this.notificationTimeLbl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PatientMainForm";
            this.Text = "PatientMainForm";
            this.Load += new System.EventHandler(this.PatientMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chooseOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createPriorityAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anamnesisReviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchDoctorsToolStripMenuItem;
        private System.Windows.Forms.Label notificationTimeLbl;
        private System.Windows.Forms.TextBox notificationTimeTxt;
        private System.Windows.Forms.Button setNotificationTimeButton;
        private System.Windows.Forms.Label welcomeLbl;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem pollHospitalToolStripMenuItem;
    }
}