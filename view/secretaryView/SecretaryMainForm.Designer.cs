
namespace HealthCareInfromationSystem.view.secretaryView
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
            this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aquirementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestsForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientsToolStripMenuItem,
            this.appointmentsToolStripMenuItem,
            this.equipmentToolStripMenuItem,
            this.requestsForToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // patientsToolStripMenuItem
            // 
            this.patientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managePatientsToolStripMenuItem,
            this.blockedPatientsToolStripMenuItem});
            this.patientsToolStripMenuItem.Name = "patientsToolStripMenuItem";
            this.patientsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.patientsToolStripMenuItem.Text = "Patients";
            // 
            // managePatientsToolStripMenuItem
            // 
            this.managePatientsToolStripMenuItem.Name = "managePatientsToolStripMenuItem";
            this.managePatientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.managePatientsToolStripMenuItem.Text = "Manage patients";
            this.managePatientsToolStripMenuItem.Click += new System.EventHandler(this.managePatientsToolStripMenuItem_Click);
            // 
            // blockedPatientsToolStripMenuItem
            // 
            this.blockedPatientsToolStripMenuItem.Name = "blockedPatientsToolStripMenuItem";
            this.blockedPatientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blockedPatientsToolStripMenuItem.Text = "Blocked patients";
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestsForChangeAndCancellationToolStripMenuItem,
            this.bookingToolStripMenuItem});
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            // 
            // requestsForChangeAndCancellationToolStripMenuItem
            // 
            this.requestsForChangeAndCancellationToolStripMenuItem.Name = "requestsForChangeAndCancellationToolStripMenuItem";
            this.requestsForChangeAndCancellationToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.requestsForChangeAndCancellationToolStripMenuItem.Text = "Requests for change and cancellation";
            // 
            // bookingToolStripMenuItem
            // 
            this.bookingToolStripMenuItem.Name = "bookingToolStripMenuItem";
            this.bookingToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.bookingToolStripMenuItem.Text = "Booking";
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aquirementToolStripMenuItem,
            this.placementToolStripMenuItem});
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.equipmentToolStripMenuItem.Text = "Equipment";
            // 
            // aquirementToolStripMenuItem
            // 
            this.aquirementToolStripMenuItem.Name = "aquirementToolStripMenuItem";
            this.aquirementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aquirementToolStripMenuItem.Text = "Aquirement";
            // 
            // placementToolStripMenuItem
            // 
            this.placementToolStripMenuItem.Name = "placementToolStripMenuItem";
            this.placementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.placementToolStripMenuItem.Text = "Placement";
            // 
            // requestsForToolStripMenuItem
            // 
            this.requestsForToolStripMenuItem.Name = "requestsForToolStripMenuItem";
            this.requestsForToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.requestsForToolStripMenuItem.Text = "Requests for off days";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.logOutToolStripMenuItem.Text = "Log out";
            // 
            // SecretaryMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SecretaryMainForm";
            this.Text = "Secretary Start Page";
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
        private System.Windows.Forms.ToolStripMenuItem requestsForToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}