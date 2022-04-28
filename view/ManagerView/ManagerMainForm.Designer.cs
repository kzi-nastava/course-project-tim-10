
namespace HealthCareInfromationSystem.view.ManagerView
{
    partial class ManagerMainForm
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
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managingPremisesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchAndFilterEquipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangingEquipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managingPremisesToolStripMenuItem,
            this.searchAndFilterEquipmentToolStripMenuItem,
            this.arrangingEquipmentToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // managingPremisesToolStripMenuItem
            // 
            this.managingPremisesToolStripMenuItem.Name = "managingPremisesToolStripMenuItem";
            this.managingPremisesToolStripMenuItem.Size = new System.Drawing.Size(332, 34);
            this.managingPremisesToolStripMenuItem.Text = "Managing premises";
            this.managingPremisesToolStripMenuItem.Click += new System.EventHandler(this.ManagingPremisesToolStripMenuItem_Click);
            // 
            // searchAndFilterEquipmentToolStripMenuItem
            // 
            this.searchAndFilterEquipmentToolStripMenuItem.Name = "searchAndFilterEquipmentToolStripMenuItem";
            this.searchAndFilterEquipmentToolStripMenuItem.Size = new System.Drawing.Size(332, 34);
            this.searchAndFilterEquipmentToolStripMenuItem.Text = "Search and filter equipment";
            // 
            // arrangingEquipmentToolStripMenuItem
            // 
            this.arrangingEquipmentToolStripMenuItem.Name = "arrangingEquipmentToolStripMenuItem";
            this.arrangingEquipmentToolStripMenuItem.Size = new System.Drawing.Size(332, 34);
            this.arrangingEquipmentToolStripMenuItem.Text = "Arranging equipment";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // ManagerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ManagerMainForm";
            this.Text = "ManagerMainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managingPremisesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchAndFilterEquipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangingEquipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}