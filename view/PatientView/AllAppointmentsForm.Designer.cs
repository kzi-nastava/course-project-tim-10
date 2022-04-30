
namespace HealthCareInfromationSystem
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
            this.scheduledAppLabel = new System.Windows.Forms.Label();
            this.addNewButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.appointmentsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // scheduledAppLabel
            // 
            this.scheduledAppLabel.AutoSize = true;
            this.scheduledAppLabel.Location = new System.Drawing.Point(340, 32);
            this.scheduledAppLabel.Name = "scheduledAppLabel";
            this.scheduledAppLabel.Size = new System.Drawing.Size(164, 17);
            this.scheduledAppLabel.TabIndex = 0;
            this.scheduledAppLabel.Text = "Scheduled appointments";
            // 
            // addNewButton
            // 
            this.addNewButton.Location = new System.Drawing.Point(168, 393);
            this.addNewButton.Name = "addNewButton";
            this.addNewButton.Size = new System.Drawing.Size(105, 33);
            this.addNewButton.TabIndex = 1;
            this.addNewButton.Text = "Add new";
            this.addNewButton.UseVisualStyleBackColor = false;
            this.addNewButton.Click += new System.EventHandler(this.AddNewButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(354, 393);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(80, 33);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(508, 393);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(77, 33);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // appointmentsGrid
            // 
            this.appointmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsGrid.Location = new System.Drawing.Point(25, 73);
            this.appointmentsGrid.Name = "appointmentsGrid";
            this.appointmentsGrid.RowHeadersWidth = 51;
            this.appointmentsGrid.RowTemplate.Height = 24;
            this.appointmentsGrid.Size = new System.Drawing.Size(742, 224);
            this.appointmentsGrid.TabIndex = 4;
            this.appointmentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppointmentsGrid_CellContentClick);
            // 
            // AllAppointmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.appointmentsGrid);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addNewButton);
            this.Controls.Add(this.scheduledAppLabel);
            this.Name = "AllAppointmentsForm";
            this.Text = "AllAppointmentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scheduledAppLabel;
        private System.Windows.Forms.Button addNewButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DataGridView appointmentsGrid;
    }
}