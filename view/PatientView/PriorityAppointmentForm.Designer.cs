
namespace HealthCareInfromationSystem.view.PatientView
{
    partial class PriorityAppointmentForm
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.doctorsBox = new System.Windows.Forms.ComboBox();
            this.dayTxt = new System.Windows.Forms.TextBox();
            this.lowerLimitTxt = new System.Windows.Forms.TextBox();
            this.upperLimitTxt = new System.Windows.Forms.TextBox();
            this.endDayTxt = new System.Windows.Forms.TextBox();
            this.showAvailableAppointmentsButton = new System.Windows.Forms.Button();
            this.doctorLabel = new System.Windows.Forms.Label();
            this.dayLabel = new System.Windows.Forms.Label();
            this.lowerLimitLabel = new System.Windows.Forms.Label();
            this.upperLimitLabel = new System.Windows.Forms.Label();
            this.noLaterLabel = new System.Windows.Forms.Label();
            this.messageLbl = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.priorityBox = new System.Windows.Forms.ComboBox();
            this.appointmentsBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(300, 32);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(235, 17);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Schedule an appointment by priority";
            // 
            // doctorsBox
            // 
            this.doctorsBox.FormattingEnabled = true;
            this.doctorsBox.Location = new System.Drawing.Point(159, 98);
            this.doctorsBox.Name = "doctorsBox";
            this.doctorsBox.Size = new System.Drawing.Size(190, 24);
            this.doctorsBox.TabIndex = 1;
            this.doctorsBox.Text = "Choose";
            // 
            // dayTxt
            // 
            this.dayTxt.Location = new System.Drawing.Point(549, 101);
            this.dayTxt.Name = "dayTxt";
            this.dayTxt.Size = new System.Drawing.Size(159, 22);
            this.dayTxt.TabIndex = 2;
            // 
            // lowerLimitTxt
            // 
            this.lowerLimitTxt.Location = new System.Drawing.Point(159, 161);
            this.lowerLimitTxt.Name = "lowerLimitTxt";
            this.lowerLimitTxt.Size = new System.Drawing.Size(190, 22);
            this.lowerLimitTxt.TabIndex = 3;
            // 
            // upperLimitTxt
            // 
            this.upperLimitTxt.Location = new System.Drawing.Point(549, 159);
            this.upperLimitTxt.Name = "upperLimitTxt";
            this.upperLimitTxt.Size = new System.Drawing.Size(159, 22);
            this.upperLimitTxt.TabIndex = 4;
            // 
            // endDayTxt
            // 
            this.endDayTxt.Location = new System.Drawing.Point(159, 224);
            this.endDayTxt.Name = "endDayTxt";
            this.endDayTxt.Size = new System.Drawing.Size(190, 22);
            this.endDayTxt.TabIndex = 5;
            // 
            // showAvailableAppointmentsButton
            // 
            this.showAvailableAppointmentsButton.Location = new System.Drawing.Point(312, 301);
            this.showAvailableAppointmentsButton.Name = "showAvailableAppointmentsButton";
            this.showAvailableAppointmentsButton.Size = new System.Drawing.Size(208, 48);
            this.showAvailableAppointmentsButton.TabIndex = 6;
            this.showAvailableAppointmentsButton.Text = "Show available appointments";
            this.showAvailableAppointmentsButton.UseVisualStyleBackColor = true;
            this.showAvailableAppointmentsButton.Click += new System.EventHandler(this.ShowAvailableAppointmentsButton_Click);
            // 
            // doctorLabel
            // 
            this.doctorLabel.AutoSize = true;
            this.doctorLabel.Location = new System.Drawing.Point(45, 101);
            this.doctorLabel.Name = "doctorLabel";
            this.doctorLabel.Size = new System.Drawing.Size(108, 17);
            this.doctorLabel.TabIndex = 7;
            this.doctorLabel.Text = "Choose doctor: ";
            // 
            // dayLabel
            // 
            this.dayLabel.AutoSize = true;
            this.dayLabel.Location = new System.Drawing.Point(452, 101);
            this.dayLabel.Name = "dayLabel";
            this.dayLabel.Size = new System.Drawing.Size(91, 17);
            this.dayLabel.TabIndex = 8;
            this.dayLabel.Text = "Choose day: ";
            // 
            // lowerLimitLabel
            // 
            this.lowerLimitLabel.AutoSize = true;
            this.lowerLimitLabel.Location = new System.Drawing.Point(68, 164);
            this.lowerLimitLabel.Name = "lowerLimitLabel";
            this.lowerLimitLabel.Size = new System.Drawing.Size(82, 17);
            this.lowerLimitLabel.TabIndex = 9;
            this.lowerLimitLabel.Text = "Lower limit: ";
            // 
            // upperLimitLabel
            // 
            this.upperLimitLabel.AutoSize = true;
            this.upperLimitLabel.Location = new System.Drawing.Point(452, 164);
            this.upperLimitLabel.Name = "upperLimitLabel";
            this.upperLimitLabel.Size = new System.Drawing.Size(83, 17);
            this.upperLimitLabel.TabIndex = 10;
            this.upperLimitLabel.Text = "Upper limit: ";
            // 
            // noLaterLabel
            // 
            this.noLaterLabel.AutoSize = true;
            this.noLaterLabel.Location = new System.Drawing.Point(56, 225);
            this.noLaterLabel.Name = "noLaterLabel";
            this.noLaterLabel.Size = new System.Drawing.Size(94, 17);
            this.noLaterLabel.TabIndex = 11;
            this.noLaterLabel.Text = "No later than:";
            // 
            // messageLbl
            // 
            this.messageLbl.AutoSize = true;
            this.messageLbl.Location = new System.Drawing.Point(56, 419);
            this.messageLbl.Name = "messageLbl";
            this.messageLbl.Size = new System.Drawing.Size(289, 17);
            this.messageLbl.TabIndex = 12;
            this.messageLbl.Text = "Choose appointment:";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(357, 597);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(77, 27);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(472, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Prirority:";
            // 
            // priorityBox
            // 
            this.priorityBox.FormattingEnabled = true;
            this.priorityBox.Items.AddRange(new object[] {
            "Datetime",
            "Doctor"});
            this.priorityBox.Location = new System.Drawing.Point(549, 222);
            this.priorityBox.Name = "priorityBox";
            this.priorityBox.Size = new System.Drawing.Size(159, 24);
            this.priorityBox.TabIndex = 15;
            this.priorityBox.Text = "Choose";
            // 
            // appointmentsBox
            // 
            this.appointmentsBox.FormattingEnabled = true;
            this.appointmentsBox.Location = new System.Drawing.Point(380, 416);
            this.appointmentsBox.Name = "appointmentsBox";
            this.appointmentsBox.Size = new System.Drawing.Size(328, 24);
            this.appointmentsBox.TabIndex = 16;
            // 
            // PriorityAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 642);
            this.Controls.Add(this.appointmentsBox);
            this.Controls.Add(this.priorityBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.messageLbl);
            this.Controls.Add(this.noLaterLabel);
            this.Controls.Add(this.upperLimitLabel);
            this.Controls.Add(this.lowerLimitLabel);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.doctorLabel);
            this.Controls.Add(this.showAvailableAppointmentsButton);
            this.Controls.Add(this.endDayTxt);
            this.Controls.Add(this.upperLimitTxt);
            this.Controls.Add(this.lowerLimitTxt);
            this.Controls.Add(this.dayTxt);
            this.Controls.Add(this.doctorsBox);
            this.Controls.Add(this.messageLabel);
            this.Name = "PriorityAppointmentForm";
            this.Text = "CreatePriorityAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.ComboBox doctorsBox;
        private System.Windows.Forms.TextBox dayTxt;
        private System.Windows.Forms.TextBox lowerLimitTxt;
        private System.Windows.Forms.TextBox upperLimitTxt;
        private System.Windows.Forms.TextBox endDayTxt;
        private System.Windows.Forms.Button showAvailableAppointmentsButton;
        private System.Windows.Forms.Label doctorLabel;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label lowerLimitLabel;
        private System.Windows.Forms.Label upperLimitLabel;
        private System.Windows.Forms.Label noLaterLabel;
        private System.Windows.Forms.Label messageLbl;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox priorityBox;
        private System.Windows.Forms.ComboBox appointmentsBox;
    }
}