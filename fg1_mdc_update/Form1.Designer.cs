namespace fg1_mdc_update
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.fg1Path = new System.Windows.Forms.TextBox();
            this.opBtn1 = new System.Windows.Forms.Button();
            this.ctrlBtn = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.manualReadBtn = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.manualFilePath = new System.Windows.Forms.TextBox();
            this.manualSelBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scrBtn = new System.Windows.Forms.RadioButton();
            this.printBtn = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.includeMdcOff = new System.Windows.Forms.RadioButton();
            this.includeMdcOn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.delRadOn = new System.Windows.Forms.RadioButton();
            this.delRadOff = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.diskBtn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.printReportBtn = new System.Windows.Forms.Button();
            this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "FG-1 Directory";
            // 
            // fg1Path
            // 
            this.fg1Path.Location = new System.Drawing.Point(108, 10);
            this.fg1Path.Name = "fg1Path";
            this.fg1Path.Size = new System.Drawing.Size(320, 20);
            this.fg1Path.TabIndex = 3;
            this.fg1Path.TabStop = false;
            this.fg1Path.Text = "C:\\user\\foodguard-1";
            this.fg1Path.TextChanged += new System.EventHandler(this.fg1Path_TextChanged);
            // 
            // opBtn1
            // 
            this.opBtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opBtn1.Location = new System.Drawing.Point(437, 10);
            this.opBtn1.Name = "opBtn1";
            this.opBtn1.Size = new System.Drawing.Size(28, 23);
            this.opBtn1.TabIndex = 6;
            this.opBtn1.Text = "...";
            this.opBtn1.UseVisualStyleBackColor = true;
            this.opBtn1.Click += new System.EventHandler(this.opBtn1_Click);
            // 
            // ctrlBtn
            // 
            this.ctrlBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlBtn.ForeColor = System.Drawing.Color.Blue;
            this.ctrlBtn.Location = new System.Drawing.Point(332, 66);
            this.ctrlBtn.Name = "ctrlBtn";
            this.ctrlBtn.Size = new System.Drawing.Size(100, 30);
            this.ctrlBtn.TabIndex = 9;
            this.ctrlBtn.Text = "Auto Off";
            this.ctrlBtn.UseVisualStyleBackColor = true;
            this.ctrlBtn.Click += new System.EventHandler(this.ctrlBtn_Click);
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(11, 184);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(446, 134);
            this.logText.TabIndex = 10;
            this.logText.TabStop = false;
            // 
            // manualReadBtn
            // 
            this.manualReadBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualReadBtn.ForeColor = System.Drawing.Color.Blue;
            this.manualReadBtn.Location = new System.Drawing.Point(332, 102);
            this.manualReadBtn.Name = "manualReadBtn";
            this.manualReadBtn.Size = new System.Drawing.Size(100, 30);
            this.manualReadBtn.TabIndex = 11;
            this.manualReadBtn.Text = "Manual";
            this.manualReadBtn.UseVisualStyleBackColor = true;
            this.manualReadBtn.Click += new System.EventHandler(this.manualReadBtn_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Input Report File";
            // 
            // manualFilePath
            // 
            this.manualFilePath.Location = new System.Drawing.Point(108, 41);
            this.manualFilePath.Name = "manualFilePath";
            this.manualFilePath.Size = new System.Drawing.Size(320, 20);
            this.manualFilePath.TabIndex = 13;
            this.manualFilePath.TabStop = false;
            // 
            // manualSelBtn
            // 
            this.manualSelBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualSelBtn.Location = new System.Drawing.Point(437, 39);
            this.manualSelBtn.Name = "manualSelBtn";
            this.manualSelBtn.Size = new System.Drawing.Size(28, 23);
            this.manualSelBtn.TabIndex = 14;
            this.manualSelBtn.Text = "...";
            this.manualSelBtn.UseVisualStyleBackColor = true;
            this.manualSelBtn.Click += new System.EventHandler(this.manualSelBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 8F);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(313, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "2018 Ficom Systems Ltd";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Report Output Device";
            // 
            // scrBtn
            // 
            this.scrBtn.AutoSize = true;
            this.scrBtn.Checked = true;
            this.scrBtn.Location = new System.Drawing.Point(3, 3);
            this.scrBtn.Name = "scrBtn";
            this.scrBtn.Size = new System.Drawing.Size(59, 17);
            this.scrBtn.TabIndex = 17;
            this.scrBtn.TabStop = true;
            this.scrBtn.Text = "Screen";
            this.scrBtn.UseVisualStyleBackColor = true;
            // 
            // printBtn
            // 
            this.printBtn.AutoSize = true;
            this.printBtn.Location = new System.Drawing.Point(64, 4);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(55, 17);
            this.printBtn.TabIndex = 18;
            this.printBtn.Text = "Printer";
            this.printBtn.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "MDC Update";
            // 
            // includeMdcOff
            // 
            this.includeMdcOff.AutoSize = true;
            this.includeMdcOff.Checked = true;
            this.includeMdcOff.Location = new System.Drawing.Point(64, 4);
            this.includeMdcOff.Name = "includeMdcOff";
            this.includeMdcOff.Size = new System.Drawing.Size(39, 17);
            this.includeMdcOff.TabIndex = 21;
            this.includeMdcOff.TabStop = true;
            this.includeMdcOff.Text = "Off";
            this.includeMdcOff.UseVisualStyleBackColor = true;
            // 
            // includeMdcOn
            // 
            this.includeMdcOn.AutoSize = true;
            this.includeMdcOn.Location = new System.Drawing.Point(3, 4);
            this.includeMdcOn.Name = "includeMdcOn";
            this.includeMdcOn.Size = new System.Drawing.Size(39, 17);
            this.includeMdcOn.TabIndex = 20;
            this.includeMdcOn.Text = "On";
            this.includeMdcOn.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.includeMdcOn);
            this.panel1.Controls.Add(this.includeMdcOff);
            this.panel1.Location = new System.Drawing.Point(143, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(120, 25);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Simple Report";
            // 
            // delRadOn
            // 
            this.delRadOn.AutoSize = true;
            this.delRadOn.Location = new System.Drawing.Point(2, 4);
            this.delRadOn.Name = "delRadOn";
            this.delRadOn.Size = new System.Drawing.Size(39, 17);
            this.delRadOn.TabIndex = 24;
            this.delRadOn.Text = "On";
            this.delRadOn.UseVisualStyleBackColor = true;
            // 
            // delRadOff
            // 
            this.delRadOff.AutoSize = true;
            this.delRadOff.Checked = true;
            this.delRadOff.Location = new System.Drawing.Point(63, 4);
            this.delRadOff.Name = "delRadOff";
            this.delRadOff.Size = new System.Drawing.Size(39, 17);
            this.delRadOff.TabIndex = 25;
            this.delRadOff.TabStop = true;
            this.delRadOff.Text = "Off";
            this.delRadOff.UseVisualStyleBackColor = true;
            this.delRadOff.CheckedChanged += new System.EventHandler(this.delRadOff_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 8F);
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(7, 332);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "FEHD - HACTL Airport";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // diskBtn
            // 
            this.diskBtn.AutoSize = true;
            this.diskBtn.Location = new System.Drawing.Point(122, 4);
            this.diskBtn.Name = "diskBtn";
            this.diskBtn.Size = new System.Drawing.Size(46, 17);
            this.diskBtn.TabIndex = 27;
            this.diskBtn.TabStop = true;
            this.diskBtn.Text = "Disk";
            this.diskBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.diskBtn);
            this.panel2.Controls.Add(this.printBtn);
            this.panel2.Controls.Add(this.scrBtn);
            this.panel2.Location = new System.Drawing.Point(143, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 25);
            this.panel2.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.delRadOff);
            this.panel3.Controls.Add(this.delRadOn);
            this.panel3.Location = new System.Drawing.Point(144, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 25);
            this.panel3.TabIndex = 29;
            // 
            // printReportBtn
            // 
            this.printReportBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printReportBtn.ForeColor = System.Drawing.Color.Blue;
            this.printReportBtn.Location = new System.Drawing.Point(333, 136);
            this.printReportBtn.Name = "printReportBtn";
            this.printReportBtn.Size = new System.Drawing.Size(100, 30);
            this.printReportBtn.TabIndex = 30;
            this.printReportBtn.Text = "Print";
            this.printReportBtn.UseVisualStyleBackColor = true;
            this.printReportBtn.Click += new System.EventHandler(this.printReportBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 351);
            this.Controls.Add(this.printReportBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.manualSelBtn);
            this.Controls.Add(this.manualFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.manualReadBtn);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.ctrlBtn);
            this.Controls.Add(this.opBtn1);
            this.Controls.Add(this.fg1Path);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "FG-1 Report Update V2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fg1Path;
        private System.Windows.Forms.Button opBtn1;
        //private System.Windows.Forms.Button opBtn3;
        private System.Windows.Forms.Button ctrlBtn;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.Button manualReadBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox manualFilePath;
        private System.Windows.Forms.Button manualSelBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton scrBtn;
        private System.Windows.Forms.RadioButton printBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton includeMdcOff;
        private System.Windows.Forms.RadioButton includeMdcOn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton delRadOn;
        private System.Windows.Forms.RadioButton delRadOff;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton diskBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button printReportBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog4;
    }
}

