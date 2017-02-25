namespace CSC430_Project
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deletePersButton = new System.Windows.Forms.RadioButton();
            this.modifyButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.RadioButton();
            this.rescheButton = new System.Windows.Forms.RadioButton();
            this.scheduleButton = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(444, 20);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 65);
            this.label1.TabIndex = 6;
            this.label1.Text = "Welcome to Patient Appointment Scheduler!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.deletePersButton);
            this.groupBox1.Controls.Add(this.modifyButton);
            this.groupBox1.Controls.Add(this.cancelButton);
            this.groupBox1.Controls.Add(this.rescheButton);
            this.groupBox1.Controls.Add(this.scheduleButton);
            this.groupBox1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 95);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(384, 228);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select an option";
            // 
            // deletePersButton
            // 
            this.deletePersButton.AutoSize = true;
            this.deletePersButton.Location = new System.Drawing.Point(30, 182);
            this.deletePersButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deletePersButton.Name = "deletePersButton";
            this.deletePersButton.Size = new System.Drawing.Size(348, 31);
            this.deletePersButton.TabIndex = 4;
            this.deletePersButton.TabStop = true;
            this.deletePersButton.Text = "Delete Personal Information";
            this.deletePersButton.UseVisualStyleBackColor = true;
            // 
            // modifyButton
            // 
            this.modifyButton.AutoSize = true;
            this.modifyButton.Location = new System.Drawing.Point(30, 145);
            this.modifyButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(352, 31);
            this.modifyButton.TabIndex = 3;
            this.modifyButton.TabStop = true;
            this.modifyButton.Text = "Modify Personal Information";
            this.modifyButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Location = new System.Drawing.Point(30, 105);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(296, 31);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.TabStop = true;
            this.cancelButton.Text = "Cancel an appointment";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // rescheButton
            // 
            this.rescheButton.AutoSize = true;
            this.rescheButton.Location = new System.Drawing.Point(30, 69);
            this.rescheButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rescheButton.Name = "rescheButton";
            this.rescheButton.Size = new System.Drawing.Size(348, 31);
            this.rescheButton.TabIndex = 1;
            this.rescheButton.TabStop = true;
            this.rescheButton.Text = "Reschedule an appointment";
            this.rescheButton.UseVisualStyleBackColor = true;
            // 
            // scheduleButton
            // 
            this.scheduleButton.AutoSize = true;
            this.scheduleButton.Location = new System.Drawing.Point(30, 31);
            this.scheduleButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(321, 31);
            this.scheduleButton.TabIndex = 0;
            this.scheduleButton.TabStop = true;
            this.scheduleButton.Text = "Schedule an appointment";
            this.scheduleButton.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Rockwell", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(466, 337);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(296, 30);
            this.comboBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 291);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Upcoming Appointments:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(21, 335);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(384, 46);
            this.button1.TabIndex = 9;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(810, 395);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Home";
            this.Text = "Home";
            this.Activated += new System.EventHandler(this.Home_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton deletePersButton;
        private System.Windows.Forms.RadioButton modifyButton;
        private System.Windows.Forms.RadioButton cancelButton;
        private System.Windows.Forms.RadioButton rescheButton;
        private System.Windows.Forms.RadioButton scheduleButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

