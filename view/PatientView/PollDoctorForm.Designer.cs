
namespace HealthCareInfromationSystem.view.PatientView
{
    partial class PollDoctorForm
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
            this.doctorSurveyLbl = new System.Windows.Forms.Label();
            this.commentLbl = new System.Windows.Forms.Label();
            this.neverLbl = new System.Windows.Forms.Label();
            this.noLbl = new System.Windows.Forms.Label();
            this.dontKnowLbl = new System.Windows.Forms.Label();
            this.yesLbl = new System.Windows.Forms.Label();
            this.alwaysLbl = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.qualityBox = new System.Windows.Forms.GroupBox();
            this.qualityRB5 = new System.Windows.Forms.RadioButton();
            this.qualityRB4 = new System.Windows.Forms.RadioButton();
            this.qualityRB3 = new System.Windows.Forms.RadioButton();
            this.qualityRB2 = new System.Windows.Forms.RadioButton();
            this.qualityRB1 = new System.Windows.Forms.RadioButton();
            this.commentTxt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.recommendRB5 = new System.Windows.Forms.RadioButton();
            this.recommendRB4 = new System.Windows.Forms.RadioButton();
            this.recommendRB3 = new System.Windows.Forms.RadioButton();
            this.recommendRB2 = new System.Windows.Forms.RadioButton();
            this.recommendRB1 = new System.Windows.Forms.RadioButton();
            this.qualityBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // doctorSurveyLbl
            // 
            this.doctorSurveyLbl.AutoSize = true;
            this.doctorSurveyLbl.Location = new System.Drawing.Point(395, 31);
            this.doctorSurveyLbl.Name = "doctorSurveyLbl";
            this.doctorSurveyLbl.Size = new System.Drawing.Size(96, 17);
            this.doctorSurveyLbl.TabIndex = 0;
            this.doctorSurveyLbl.Text = "Doctor survey";
            // 
            // commentLbl
            // 
            this.commentLbl.AutoSize = true;
            this.commentLbl.Location = new System.Drawing.Point(94, 273);
            this.commentLbl.Name = "commentLbl";
            this.commentLbl.Size = new System.Drawing.Size(71, 17);
            this.commentLbl.TabIndex = 5;
            this.commentLbl.Text = "Comment:";
            // 
            // neverLbl
            // 
            this.neverLbl.AutoSize = true;
            this.neverLbl.Location = new System.Drawing.Point(590, 126);
            this.neverLbl.Name = "neverLbl";
            this.neverLbl.Size = new System.Drawing.Size(67, 17);
            this.neverLbl.TabIndex = 6;
            this.neverLbl.Text = "1 - Never";
            // 
            // noLbl
            // 
            this.noLbl.AutoSize = true;
            this.noLbl.Location = new System.Drawing.Point(590, 168);
            this.noLbl.Name = "noLbl";
            this.noLbl.Size = new System.Drawing.Size(47, 17);
            this.noLbl.TabIndex = 7;
            this.noLbl.Text = "2 - No";
            // 
            // dontKnowLbl
            // 
            this.dontKnowLbl.AutoSize = true;
            this.dontKnowLbl.Location = new System.Drawing.Point(590, 211);
            this.dontKnowLbl.Name = "dontKnowLbl";
            this.dontKnowLbl.Size = new System.Drawing.Size(103, 17);
            this.dontKnowLbl.TabIndex = 8;
            this.dontKnowLbl.Text = "3 - I don\'t know";
            // 
            // yesLbl
            // 
            this.yesLbl.AutoSize = true;
            this.yesLbl.Location = new System.Drawing.Point(590, 255);
            this.yesLbl.Name = "yesLbl";
            this.yesLbl.Size = new System.Drawing.Size(53, 17);
            this.yesLbl.TabIndex = 9;
            this.yesLbl.Text = "4 - Yes";
            // 
            // alwaysLbl
            // 
            this.alwaysLbl.AutoSize = true;
            this.alwaysLbl.Location = new System.Drawing.Point(590, 298);
            this.alwaysLbl.Name = "alwaysLbl";
            this.alwaysLbl.Size = new System.Drawing.Size(72, 17);
            this.alwaysLbl.TabIndex = 10;
            this.alwaysLbl.Text = "5 - Always";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(351, 420);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(128, 37);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // qualityBox
            // 
            this.qualityBox.Controls.Add(this.qualityRB5);
            this.qualityBox.Controls.Add(this.qualityRB4);
            this.qualityBox.Controls.Add(this.qualityRB3);
            this.qualityBox.Controls.Add(this.qualityRB2);
            this.qualityBox.Controls.Add(this.qualityRB1);
            this.qualityBox.Location = new System.Drawing.Point(101, 103);
            this.qualityBox.Name = "qualityBox";
            this.qualityBox.Size = new System.Drawing.Size(356, 58);
            this.qualityBox.TabIndex = 12;
            this.qualityBox.TabStop = false;
            this.qualityBox.Text = "Quality:";
            // 
            // qualityRB5
            // 
            this.qualityRB5.AutoSize = true;
            this.qualityRB5.Location = new System.Drawing.Point(297, 23);
            this.qualityRB5.Name = "qualityRB5";
            this.qualityRB5.Size = new System.Drawing.Size(37, 21);
            this.qualityRB5.TabIndex = 4;
            this.qualityRB5.TabStop = true;
            this.qualityRB5.Text = "5";
            this.qualityRB5.UseVisualStyleBackColor = true;
            // 
            // qualityRB4
            // 
            this.qualityRB4.AutoSize = true;
            this.qualityRB4.Location = new System.Drawing.Point(240, 23);
            this.qualityRB4.Name = "qualityRB4";
            this.qualityRB4.Size = new System.Drawing.Size(37, 21);
            this.qualityRB4.TabIndex = 3;
            this.qualityRB4.TabStop = true;
            this.qualityRB4.Text = "4";
            this.qualityRB4.UseVisualStyleBackColor = true;
            // 
            // qualityRB3
            // 
            this.qualityRB3.AutoSize = true;
            this.qualityRB3.Location = new System.Drawing.Point(181, 23);
            this.qualityRB3.Name = "qualityRB3";
            this.qualityRB3.Size = new System.Drawing.Size(37, 21);
            this.qualityRB3.TabIndex = 2;
            this.qualityRB3.TabStop = true;
            this.qualityRB3.Text = "3";
            this.qualityRB3.UseVisualStyleBackColor = true;
            // 
            // qualityRB2
            // 
            this.qualityRB2.AutoSize = true;
            this.qualityRB2.Location = new System.Drawing.Point(125, 23);
            this.qualityRB2.Name = "qualityRB2";
            this.qualityRB2.Size = new System.Drawing.Size(37, 21);
            this.qualityRB2.TabIndex = 1;
            this.qualityRB2.TabStop = true;
            this.qualityRB2.Text = "2";
            this.qualityRB2.UseVisualStyleBackColor = true;
            // 
            // qualityRB1
            // 
            this.qualityRB1.AutoSize = true;
            this.qualityRB1.Location = new System.Drawing.Point(68, 23);
            this.qualityRB1.Name = "qualityRB1";
            this.qualityRB1.Size = new System.Drawing.Size(37, 21);
            this.qualityRB1.TabIndex = 0;
            this.qualityRB1.TabStop = true;
            this.qualityRB1.Text = "1";
            this.qualityRB1.UseVisualStyleBackColor = true;
            // 
            // commentTxt
            // 
            this.commentTxt.Location = new System.Drawing.Point(185, 273);
            this.commentTxt.Multiline = true;
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.Size = new System.Drawing.Size(272, 90);
            this.commentTxt.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.recommendRB5);
            this.groupBox1.Controls.Add(this.recommendRB4);
            this.groupBox1.Controls.Add(this.recommendRB3);
            this.groupBox1.Controls.Add(this.recommendRB2);
            this.groupBox1.Controls.Add(this.recommendRB1);
            this.groupBox1.Location = new System.Drawing.Point(101, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 67);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recommend to friends:";
            // 
            // recommendRB5
            // 
            this.recommendRB5.AutoSize = true;
            this.recommendRB5.Location = new System.Drawing.Point(297, 27);
            this.recommendRB5.Name = "recommendRB5";
            this.recommendRB5.Size = new System.Drawing.Size(37, 21);
            this.recommendRB5.TabIndex = 4;
            this.recommendRB5.TabStop = true;
            this.recommendRB5.Text = "5";
            this.recommendRB5.UseVisualStyleBackColor = true;
            // 
            // recommendRB4
            // 
            this.recommendRB4.AutoSize = true;
            this.recommendRB4.Location = new System.Drawing.Point(240, 27);
            this.recommendRB4.Name = "recommendRB4";
            this.recommendRB4.Size = new System.Drawing.Size(37, 21);
            this.recommendRB4.TabIndex = 3;
            this.recommendRB4.TabStop = true;
            this.recommendRB4.Text = "4";
            this.recommendRB4.UseVisualStyleBackColor = true;
            // 
            // recommendRB3
            // 
            this.recommendRB3.AutoSize = true;
            this.recommendRB3.Location = new System.Drawing.Point(181, 27);
            this.recommendRB3.Name = "recommendRB3";
            this.recommendRB3.Size = new System.Drawing.Size(37, 21);
            this.recommendRB3.TabIndex = 2;
            this.recommendRB3.TabStop = true;
            this.recommendRB3.Text = "3";
            this.recommendRB3.UseVisualStyleBackColor = true;
            // 
            // recommendRB2
            // 
            this.recommendRB2.AutoSize = true;
            this.recommendRB2.Location = new System.Drawing.Point(125, 27);
            this.recommendRB2.Name = "recommendRB2";
            this.recommendRB2.Size = new System.Drawing.Size(37, 21);
            this.recommendRB2.TabIndex = 1;
            this.recommendRB2.TabStop = true;
            this.recommendRB2.Text = "2";
            this.recommendRB2.UseVisualStyleBackColor = true;
            // 
            // recommendRB1
            // 
            this.recommendRB1.AutoSize = true;
            this.recommendRB1.Location = new System.Drawing.Point(68, 27);
            this.recommendRB1.Name = "recommendRB1";
            this.recommendRB1.Size = new System.Drawing.Size(37, 21);
            this.recommendRB1.TabIndex = 0;
            this.recommendRB1.TabStop = true;
            this.recommendRB1.Text = "1";
            this.recommendRB1.UseVisualStyleBackColor = true;
            // 
            // SurveyDoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 486);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.commentTxt);
            this.Controls.Add(this.qualityBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.alwaysLbl);
            this.Controls.Add(this.yesLbl);
            this.Controls.Add(this.dontKnowLbl);
            this.Controls.Add(this.noLbl);
            this.Controls.Add(this.neverLbl);
            this.Controls.Add(this.commentLbl);
            this.Controls.Add(this.doctorSurveyLbl);
            this.Name = "SurveyDoctorForm";
            this.Text = "SurveyDoctor";
            this.qualityBox.ResumeLayout(false);
            this.qualityBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label doctorSurveyLbl;
        private System.Windows.Forms.Label commentLbl;
        private System.Windows.Forms.Label neverLbl;
        private System.Windows.Forms.Label noLbl;
        private System.Windows.Forms.Label dontKnowLbl;
        private System.Windows.Forms.Label yesLbl;
        private System.Windows.Forms.Label alwaysLbl;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox qualityBox;
        private System.Windows.Forms.TextBox commentTxt;
        private System.Windows.Forms.RadioButton qualityRB5;
        private System.Windows.Forms.RadioButton qualityRB4;
        private System.Windows.Forms.RadioButton qualityRB3;
        private System.Windows.Forms.RadioButton qualityRB2;
        private System.Windows.Forms.RadioButton qualityRB1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton recommendRB5;
        private System.Windows.Forms.RadioButton recommendRB4;
        private System.Windows.Forms.RadioButton recommendRB3;
        private System.Windows.Forms.RadioButton recommendRB2;
        private System.Windows.Forms.RadioButton recommendRB1;
    }
}