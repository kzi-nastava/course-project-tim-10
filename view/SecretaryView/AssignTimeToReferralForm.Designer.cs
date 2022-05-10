
namespace HealthCareInfromationSystem.view.SecretaryView
{
    partial class AssignTimeToReferralForm
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
            this.cbPremise = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.tbDuration = new System.Windows.Forms.TextBox();
            this.tbBeginning = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Premise: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Beginning (dd.MM.yyyy. HH:mm):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Duration:";
            // 
            // cbPremise
            // 
            this.cbPremise.FormattingEnabled = true;
            this.cbPremise.Location = new System.Drawing.Point(332, 63);
            this.cbPremise.Name = "cbPremise";
            this.cbPremise.Size = new System.Drawing.Size(172, 28);
            this.cbPremise.TabIndex = 4;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(332, 163);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(172, 28);
            this.cbType.TabIndex = 6;
            // 
            // tbDuration
            // 
            this.tbDuration.Location = new System.Drawing.Point(332, 221);
            this.tbDuration.Name = "tbDuration";
            this.tbDuration.Size = new System.Drawing.Size(172, 26);
            this.tbDuration.TabIndex = 7;
            // 
            // tbBeginning
            // 
            this.tbBeginning.Location = new System.Drawing.Point(332, 112);
            this.tbBeginning.Name = "tbBeginning";
            this.tbBeginning.Size = new System.Drawing.Size(172, 26);
            this.tbBeginning.TabIndex = 8;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(221, 367);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(138, 53);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Save Assignment";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Doctor";
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(332, 274);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.ReadOnly = true;
            this.tbDoctor.Size = new System.Drawing.Size(172, 26);
            this.tbDoctor.TabIndex = 11;
            // 
            // AssignTimeToReferralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 469);
            this.Controls.Add(this.tbDoctor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbBeginning);
            this.Controls.Add(this.tbDuration);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.cbPremise);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AssignTimeToReferralForm";
            this.Text = "Assign Time To Referral Letter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPremise;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.TextBox tbDuration;
        private System.Windows.Forms.TextBox tbBeginning;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDoctor;
    }
}