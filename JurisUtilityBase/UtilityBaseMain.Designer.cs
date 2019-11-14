namespace JurisUtilityBase
{
    partial class UtilityBaseMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UtilityBaseMain));
            this.JurisLogoImageBox = new System.Windows.Forms.PictureBox();
            this.LexisNexisLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBoxCompanies = new System.Windows.Forms.ListBox();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.labelCurrentStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelPercentComplete = new System.Windows.Forms.Label();
            this.OpenFileDialogOpen = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbMatter = new System.Windows.Forms.RadioButton();
            this.rbClient = new System.Windows.Forms.RadioButton();
            this.rbCM = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFSAll = new System.Windows.Forms.RadioButton();
            this.rbFSClosed = new System.Windows.Forms.RadioButton();
            this.rbFSopen = new System.Windows.Forms.RadioButton();
            this.buttonReport = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cbPG = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.JurisLogoImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LexisNexisLogoPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // JurisLogoImageBox
            // 
            this.JurisLogoImageBox.Image = ((System.Drawing.Image)(resources.GetObject("JurisLogoImageBox.Image")));
            this.JurisLogoImageBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("JurisLogoImageBox.InitialImage")));
            this.JurisLogoImageBox.Location = new System.Drawing.Point(0, 1);
            this.JurisLogoImageBox.Name = "JurisLogoImageBox";
            this.JurisLogoImageBox.Size = new System.Drawing.Size(104, 336);
            this.JurisLogoImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.JurisLogoImageBox.TabIndex = 0;
            this.JurisLogoImageBox.TabStop = false;
            // 
            // LexisNexisLogoPictureBox
            // 
            this.LexisNexisLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LexisNexisLogoPictureBox.Image")));
            this.LexisNexisLogoPictureBox.Location = new System.Drawing.Point(8, 343);
            this.LexisNexisLogoPictureBox.Name = "LexisNexisLogoPictureBox";
            this.LexisNexisLogoPictureBox.Size = new System.Drawing.Size(96, 28);
            this.LexisNexisLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LexisNexisLogoPictureBox.TabIndex = 1;
            this.LexisNexisLogoPictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 384);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(683, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(134, 17);
            this.toolStripStatusLabel.Text = "Status: Ready to Execute";
            // 
            // listBoxCompanies
            // 
            this.listBoxCompanies.FormattingEnabled = true;
            this.listBoxCompanies.Location = new System.Drawing.Point(111, 1);
            this.listBoxCompanies.Name = "listBoxCompanies";
            this.listBoxCompanies.Size = new System.Drawing.Size(262, 69);
            this.listBoxCompanies.TabIndex = 0;
            this.listBoxCompanies.SelectedIndexChanged += new System.EventHandler(this.listBoxCompanies_SelectedIndexChanged);
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.labelCurrentStatus);
            this.statusGroupBox.Controls.Add(this.progressBar);
            this.statusGroupBox.Controls.Add(this.labelPercentComplete);
            this.statusGroupBox.Location = new System.Drawing.Point(393, 1);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(279, 73);
            this.statusGroupBox.TabIndex = 5;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Utility Status:";
            // 
            // labelCurrentStatus
            // 
            this.labelCurrentStatus.AutoSize = true;
            this.labelCurrentStatus.Location = new System.Drawing.Point(7, 50);
            this.labelCurrentStatus.Name = "labelCurrentStatus";
            this.labelCurrentStatus.Size = new System.Drawing.Size(77, 13);
            this.labelCurrentStatus.TabIndex = 2;
            this.labelCurrentStatus.Text = "Current Status:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 27);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(255, 20);
            this.progressBar.TabIndex = 0;
            // 
            // labelPercentComplete
            // 
            this.labelPercentComplete.AutoSize = true;
            this.labelPercentComplete.Location = new System.Drawing.Point(171, 11);
            this.labelPercentComplete.Name = "labelPercentComplete";
            this.labelPercentComplete.Size = new System.Drawing.Size(62, 13);
            this.labelPercentComplete.TabIndex = 0;
            this.labelPercentComplete.Text = "% Complete";
            // 
            // OpenFileDialogOpen
            // 
            this.OpenFileDialogOpen.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Navy;
            this.button1.Location = new System.Drawing.Point(329, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.LightGray;
            this.btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.Navy;
            this.btExit.Location = new System.Drawing.Point(483, 333);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(148, 38);
            this.btExit.TabIndex = 7;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Navy;
            this.textBox1.Location = new System.Drawing.Point(111, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(560, 22);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Change Fee Schedule on client/matters. ";
            // 
            // cbFrom
            // 
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Location = new System.Drawing.Point(108, 133);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(268, 21);
            this.cbFrom.TabIndex = 9;
            this.cbFrom.SelectedIndexChanged += new System.EventHandler(this.cbFrom_SelectedIndexChanged);
            // 
            // cbTo
            // 
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Location = new System.Drawing.Point(398, 133);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(270, 21);
            this.cbTo.TabIndex = 10;
            this.cbTo.SelectedIndexChanged += new System.EventHandler(this.cbTo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbMatter);
            this.groupBox2.Controls.Add(this.rbClient);
            this.groupBox2.Controls.Add(this.rbCM);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(111, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 55);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Client Matter Option";
            // 
            // rbMatter
            // 
            this.rbMatter.AutoSize = true;
            this.rbMatter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMatter.ForeColor = System.Drawing.Color.Navy;
            this.rbMatter.Location = new System.Drawing.Point(383, 20);
            this.rbMatter.Name = "rbMatter";
            this.rbMatter.Size = new System.Drawing.Size(91, 20);
            this.rbMatter.TabIndex = 2;
            this.rbMatter.Text = "Matter only";
            this.rbMatter.UseVisualStyleBackColor = true;
            // 
            // rbClient
            // 
            this.rbClient.AutoSize = true;
            this.rbClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbClient.ForeColor = System.Drawing.Color.Navy;
            this.rbClient.Location = new System.Drawing.Point(195, 19);
            this.rbClient.Name = "rbClient";
            this.rbClient.Size = new System.Drawing.Size(87, 20);
            this.rbClient.TabIndex = 1;
            this.rbClient.Text = "Client only";
            this.rbClient.UseVisualStyleBackColor = true;
            // 
            // rbCM
            // 
            this.rbCM.AutoSize = true;
            this.rbCM.Checked = true;
            this.rbCM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbCM.ForeColor = System.Drawing.Color.Navy;
            this.rbCM.Location = new System.Drawing.Point(6, 19);
            this.rbCM.Name = "rbCM";
            this.rbCM.Size = new System.Drawing.Size(125, 20);
            this.rbCM.TabIndex = 0;
            this.rbCM.TabStop = true;
            this.rbCM.Text = "Client and Matter";
            this.rbCM.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Navy;
            this.textBox2.Location = new System.Drawing.Point(110, 105);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(268, 22);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Select Fee Schedule to Change from";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Navy;
            this.textBox3.Location = new System.Drawing.Point(398, 105);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(268, 22);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Select Fee Schedule to Change to";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFSAll);
            this.groupBox1.Controls.Add(this.rbFSClosed);
            this.groupBox1.Controls.Add(this.rbFSopen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(111, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 55);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Matter Status";
            // 
            // rbFSAll
            // 
            this.rbFSAll.AutoSize = true;
            this.rbFSAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFSAll.ForeColor = System.Drawing.Color.Navy;
            this.rbFSAll.Location = new System.Drawing.Point(383, 20);
            this.rbFSAll.Name = "rbFSAll";
            this.rbFSAll.Size = new System.Drawing.Size(88, 20);
            this.rbFSAll.TabIndex = 2;
            this.rbFSAll.Text = "All Matters";
            this.rbFSAll.UseVisualStyleBackColor = true;
            // 
            // rbFSClosed
            // 
            this.rbFSClosed.AutoSize = true;
            this.rbFSClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFSClosed.ForeColor = System.Drawing.Color.Navy;
            this.rbFSClosed.Location = new System.Drawing.Point(195, 19);
            this.rbFSClosed.Name = "rbFSClosed";
            this.rbFSClosed.Size = new System.Drawing.Size(146, 20);
            this.rbFSClosed.TabIndex = 1;
            this.rbFSClosed.Text = "Closed Matters Only";
            this.rbFSClosed.UseVisualStyleBackColor = true;
            // 
            // rbFSopen
            // 
            this.rbFSopen.AutoSize = true;
            this.rbFSopen.Checked = true;
            this.rbFSopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFSopen.ForeColor = System.Drawing.Color.Navy;
            this.rbFSopen.Location = new System.Drawing.Point(6, 19);
            this.rbFSopen.Name = "rbFSopen";
            this.rbFSopen.Size = new System.Drawing.Size(136, 20);
            this.rbFSopen.TabIndex = 0;
            this.rbFSopen.TabStop = true;
            this.rbFSopen.Text = "Open Matters Only";
            this.rbFSopen.UseVisualStyleBackColor = true;
            // 
            // buttonReport
            // 
            this.buttonReport.BackColor = System.Drawing.Color.LightGray;
            this.buttonReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReport.ForeColor = System.Drawing.Color.MidnightBlue;
            this.buttonReport.Location = new System.Drawing.Point(117, 333);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(148, 38);
            this.buttonReport.TabIndex = 16;
            this.buttonReport.Text = "Pre-Report";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Navy;
            this.textBox4.Location = new System.Drawing.Point(139, 160);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(209, 22);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Select Practice Class Group";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // cbPG
            // 
            this.cbPG.FormattingEnabled = true;
            this.cbPG.Location = new System.Drawing.Point(354, 160);
            this.cbPG.Name = "cbPG";
            this.cbPG.Size = new System.Drawing.Size(268, 21);
            this.cbPG.TabIndex = 18;
            this.cbPG.SelectedIndexChanged += new System.EventHandler(this.cbPG_SelectedIndexChanged);
            // 
            // UtilityBaseMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(683, 406);
            this.Controls.Add(this.cbPG);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbTo);
            this.Controls.Add(this.cbFrom);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.listBoxCompanies);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.LexisNexisLogoPictureBox);
            this.Controls.Add(this.JurisLogoImageBox);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UtilityBaseMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JPS - Fee Schedule Reassignment Utility";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JurisLogoImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LexisNexisLogoPictureBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox JurisLogoImageBox;
        private System.Windows.Forms.PictureBox LexisNexisLogoPictureBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ListBox listBoxCompanies;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label labelCurrentStatus;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelPercentComplete;
        private System.Windows.Forms.OpenFileDialog OpenFileDialogOpen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbMatter;
        private System.Windows.Forms.RadioButton rbClient;
        private System.Windows.Forms.RadioButton rbCM;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFSAll;
        private System.Windows.Forms.RadioButton rbFSClosed;
        private System.Windows.Forms.RadioButton rbFSopen;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cbPG;
    }
}

