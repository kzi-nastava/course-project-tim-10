
namespace HealthCareInfromationSystem.view.PatientView
{
    partial class AnamnesisReviewForm
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
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.bloodTypeLabel = new System.Windows.Forms.Label();
            this.diseaseLabel = new System.Windows.Forms.Label();
            this.alergiesLabel = new System.Windows.Forms.Label();
            this.appointmentsLabel = new System.Windows.Forms.Label();
            this.appointmentsGrid = new System.Windows.Forms.DataGridView();
            this.showAnamnesisButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.sortByBox = new System.Windows.Forms.ComboBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.keyWordLabel = new System.Windows.Forms.Label();
            this.keyWordTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(42, 90);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(82, 17);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First name: ";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(42, 122);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(82, 17);
            this.lastNameLabel.TabIndex = 1;
            this.lastNameLabel.Text = "Last name: ";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(42, 154);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(57, 17);
            this.heightLabel.TabIndex = 2;
            this.heightLabel.Text = "Height: ";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(42, 184);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(60, 17);
            this.weightLabel.TabIndex = 3;
            this.weightLabel.Text = "Weight: ";
            // 
            // bloodTypeLabel
            // 
            this.bloodTypeLabel.AutoSize = true;
            this.bloodTypeLabel.Location = new System.Drawing.Point(42, 214);
            this.bloodTypeLabel.Name = "bloodTypeLabel";
            this.bloodTypeLabel.Size = new System.Drawing.Size(83, 17);
            this.bloodTypeLabel.TabIndex = 4;
            this.bloodTypeLabel.Text = "Blood type: ";
            // 
            // diseaseLabel
            // 
            this.diseaseLabel.AutoSize = true;
            this.diseaseLabel.Location = new System.Drawing.Point(42, 245);
            this.diseaseLabel.Name = "diseaseLabel";
            this.diseaseLabel.Size = new System.Drawing.Size(67, 17);
            this.diseaseLabel.TabIndex = 5;
            this.diseaseLabel.Text = "Disease: ";
            // 
            // alergiesLabel
            // 
            this.alergiesLabel.AutoSize = true;
            this.alergiesLabel.Location = new System.Drawing.Point(42, 277);
            this.alergiesLabel.Name = "alergiesLabel";
            this.alergiesLabel.Size = new System.Drawing.Size(67, 17);
            this.alergiesLabel.TabIndex = 6;
            this.alergiesLabel.Text = "Alergies: ";
            // 
            // appointmentsLabel
            // 
            this.appointmentsLabel.AutoSize = true;
            this.appointmentsLabel.Location = new System.Drawing.Point(547, 27);
            this.appointmentsLabel.Name = "appointmentsLabel";
            this.appointmentsLabel.Size = new System.Drawing.Size(98, 17);
            this.appointmentsLabel.TabIndex = 7;
            this.appointmentsLabel.Text = "Appointments:";
            // 
            // appointmentsGrid
            // 
            this.appointmentsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsGrid.Location = new System.Drawing.Point(328, 76);
            this.appointmentsGrid.Name = "appointmentsGrid";
            this.appointmentsGrid.RowHeadersWidth = 51;
            this.appointmentsGrid.RowTemplate.Height = 24;
            this.appointmentsGrid.Size = new System.Drawing.Size(700, 229);
            this.appointmentsGrid.TabIndex = 8;
            this.appointmentsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppointmentsGrid_CellContentClick);
            // 
            // showAnamnesisButton
            // 
            this.showAnamnesisButton.Location = new System.Drawing.Point(50, 413);
            this.showAnamnesisButton.Name = "showAnamnesisButton";
            this.showAnamnesisButton.Size = new System.Drawing.Size(135, 39);
            this.showAnamnesisButton.TabIndex = 9;
            this.showAnamnesisButton.Text = "Show anamnesis";
            this.showAnamnesisButton.UseVisualStyleBackColor = true;
            this.showAnamnesisButton.Click += new System.EventHandler(this.ShowAnamnesisButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(440, 438);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(119, 36);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // sortByLabel
            // 
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Location = new System.Drawing.Point(785, 394);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(57, 17);
            this.sortByLabel.TabIndex = 11;
            this.sortByLabel.Text = "Sort by:";
            // 
            // sortByBox
            // 
            this.sortByBox.FormattingEnabled = true;
            this.sortByBox.Items.AddRange(new object[] {
            "Date",
            "Doctor",
            "Specialisation"});
            this.sortByBox.Location = new System.Drawing.Point(863, 391);
            this.sortByBox.Name = "sortByBox";
            this.sortByBox.Size = new System.Drawing.Size(160, 24);
            this.sortByBox.TabIndex = 12;
            this.sortByBox.Text = "Sort by";
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(863, 438);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(111, 36);
            this.sortButton.TabIndex = 13;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.SortButton_Click);
            // 
            // keyWordLabel
            // 
            this.keyWordLabel.AutoSize = true;
            this.keyWordLabel.Location = new System.Drawing.Point(358, 404);
            this.keyWordLabel.Name = "keyWordLabel";
            this.keyWordLabel.Size = new System.Drawing.Size(132, 17);
            this.keyWordLabel.TabIndex = 14;
            this.keyWordLabel.Text = "Search by keyword:";
            // 
            // keyWordTxt
            // 
            this.keyWordTxt.Location = new System.Drawing.Point(496, 401);
            this.keyWordTxt.Name = "keyWordTxt";
            this.keyWordTxt.Size = new System.Drawing.Size(176, 22);
            this.keyWordTxt.TabIndex = 15;
            // 
            // AnamnesisReviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 544);
            this.Controls.Add(this.keyWordTxt);
            this.Controls.Add(this.keyWordLabel);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.sortByBox);
            this.Controls.Add(this.sortByLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.showAnamnesisButton);
            this.Controls.Add(this.appointmentsGrid);
            this.Controls.Add(this.appointmentsLabel);
            this.Controls.Add(this.alergiesLabel);
            this.Controls.Add(this.diseaseLabel);
            this.Controls.Add(this.bloodTypeLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Name = "AnamnesisReviewForm";
            this.Text = "AnamnesisReviewForm";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label bloodTypeLabel;
        private System.Windows.Forms.Label diseaseLabel;
        private System.Windows.Forms.Label alergiesLabel;
        private System.Windows.Forms.Label appointmentsLabel;
        private System.Windows.Forms.DataGridView appointmentsGrid;
        private System.Windows.Forms.Button showAnamnesisButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label sortByLabel;
        private System.Windows.Forms.ComboBox sortByBox;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Label keyWordLabel;
        private System.Windows.Forms.TextBox keyWordTxt;
    }
}