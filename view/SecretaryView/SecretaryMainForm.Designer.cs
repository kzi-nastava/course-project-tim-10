
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class SecretaryMainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.patientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockedPatientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestsForChangeAndCancellationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byReferralToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emergencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aquirementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestsForOffDaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.equipmentToolStripMenuItem,
            this.requestsForOffDaysToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managePatientsToolStripMenuItem,
            this.blockedPatientsToolStripMenuItem});
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(89, 29);
            this.patientsToolStripMenuItem.Text = "Patients";
            // 
            // managePatientsToolStripMenuItem
            // 
            this.managePatientsToolStripMenuItem.Name = "managePatientsToolStripMenuItem";
            this.managePatientsToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.managePatientsToolStripMenuItem.Text = "Manage patients";
            this.managePatientsToolStripMenuItem.Click += new System.EventHandler(this.ManagePatientsToolStripMenuItem_Click);
            // 
            // blockedPatientsToolStripMenuItem
            // 
            this.blockedPatientsToolStripMenuItem.Name = "blockedPatientsToolStripMenuItem";
            this.blockedPatientsToolStripMenuItem.Size = new System.Drawing.Size(246, 34);
            this.blockedPatientsToolStripMenuItem.Text = "Blocked patients";
            this.blockedPatientsToolStripMenuItem.Click += new System.EventHandler(this.BlockedPatientsToolStripMenuItem_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestsForChangeAndCancellationToolStripMenuItem,
            this.bookingToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(142, 29);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // requestsForChangeAndCancellationToolStripMenuItem
            // 
            this.requestsForChangeAndCancellationToolStripMenuItem.Name = "requestsForChangeAndCancellationToolStripMenuItem";
            this.requestsForChangeAndCancellationToolStripMenuItem.Size = new System.Drawing.Size(407, 34);
            this.requestsForChangeAndCancellationToolStripMenuItem.Text = "Requests for change and cancellation";
            this.requestsForChangeAndCancellationToolStripMenuItem.Click += new System.EventHandler(this.RequestsForChangeAndCancellationToolStripMenuItem_Click);
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byReferralToolStripMenuItem,
            this.emergencyToolStripMenuItem});
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(407, 34);
            this.bookingToolStripMenuItem.Text = "Booking";
            // 
            // byReferralToolStripMenuItem
            // 
            this.byReferralToolStripMenuItem.Name = "byReferralToolStripMenuItem";
            this.byReferralToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.byReferralToolStripMenuItem.Text = "By referral";
            this.byReferralToolStripMenuItem.Click += new System.EventHandler(this.ByReferralToolStripMenuItem_Click);
            // 
            // emergencyToolStripMenuItem
            // 
            this.emergencyToolStripMenuItem.Name = "emergencyToolStripMenuItem";
            this.emergencyToolStripMenuItem.Size = new System.Drawing.Size(201, 34);
            this.emergencyToolStripMenuItem.Text = "Emergency";
            this.emergencyToolStripMenuItem.Click += new System.EventHandler(this.EmergencyToolStripMenuItem_Click);
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aquirementToolStripMenuItem,
            this.placementToolStripMenuItem});
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.equipmentToolStripMenuItem.Text = "Equipment";
            // 
            // aquirementToolStripMenuItem
            // 
            this.aquirementToolStripMenuItem.Name = "aquirementToolStripMenuItem";
            this.aquirementToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.aquirementToolStripMenuItem.Text = "Aquirement";
            this.aquirementToolStripMenuItem.Click += new System.EventHandler(this.aquirementToolStripMenuItem_Click);
            // 
            // placementToolStripMenuItem
            // 
            this.placementToolStripMenuItem.Name = "placementToolStripMenuItem";
            this.placementToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.placementToolStripMenuItem.Text = "Placement";
            // 
            // requestsForOffDaysToolStripMenuItem
            // 
            this.requestsForOffDaysToolStripMenuItem.Name = "requestsForOffDaysToolStripMenuItem";
            this.requestsForOffDaysToolStripMenuItem.Size = new System.Drawing.Size(197, 29);
            this.requestsForOffDaysToolStripMenuItem.Text = "Requests for off days";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(90, 29);
            this.logOutToolStripMenuItem.Text = "Log out";
            // 
            // SecretaryMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SecretaryMainForm";
            this.Text = "SecretaryMainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem patientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managePatientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockedPatientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestsForChangeAndCancellationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aquirementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestsForOffDaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byReferralToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emergencyToolStripMenuItem;
    }
}