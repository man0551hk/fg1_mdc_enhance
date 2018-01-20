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
            this.autoPrintOn = new System.Windows.Forms.RadioButton();
            this.autoPrintOff = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.includeMdcOff = new System.Windows.Forms.RadioButton();
            this.includeMdcOn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 13);
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
            this.ctrlBtn.Location = new System.Drawing.Point(69, 140);
            this.ctrlBtn.Name = "ctrlBtn";
            this.ctrlBtn.Size = new System.Drawing.Size(112, 31);
            this.ctrlBtn.TabIndex = 9;
            this.ctrlBtn.Text = "Auto Off";
            this.ctrlBtn.UseVisualStyleBackColor = true;
            this.ctrlBtn.Click += new System.EventHandler(this.ctrlBtn_Click);
            // 
            // logText
            // 
            this.logText.Location = new System.Drawing.Point(13, 177);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logText.Size = new System.Drawing.Size(449, 165);
            this.logText.TabIndex = 10;
            this.logText.TabStop = false;
            // 
            // manualReadBtn
            // 
            this.manualReadBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualReadBtn.ForeColor = System.Drawing.Color.Blue;
            this.manualReadBtn.Location = new System.Drawing.Point(278, 140);
            this.manualReadBtn.Name = "manualReadBtn";
            this.manualReadBtn.Size = new System.Drawing.Size(111, 31);
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
            this.label4.Location = new System.Drawing.Point(10, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Report File";
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
            this.label2.Location = new System.Drawing.Point(316, 345);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "2017 Ficom Systems Ltd";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Auto Print";
            // 
            // autoPrintOn
            // 
            this.autoPrintOn.AutoSize = true;
            this.autoPrintOn.Location = new System.Drawing.Point(111, 100);
            this.autoPrintOn.Name = "autoPrintOn";
            this.autoPrintOn.Size = new System.Drawing.Size(39, 17);
            this.autoPrintOn.TabIndex = 17;
            this.autoPrintOn.Text = "On";
            this.autoPrintOn.UseVisualStyleBackColor = true;
            this.autoPrintOn.CheckedChanged += new System.EventHandler(this.autoPrintOn_CheckedChanged);
            // 
            // autoPrintOff
            // 
            this.autoPrintOff.AutoSize = true;
            this.autoPrintOff.Checked = true;
            this.autoPrintOff.Location = new System.Drawing.Point(156, 100);
            this.autoPrintOff.Name = "autoPrintOff";
            this.autoPrintOff.Size = new System.Drawing.Size(39, 17);
            this.autoPrintOff.TabIndex = 18;
            this.autoPrintOff.TabStop = true;
            this.autoPrintOff.Text = "Off";
            this.autoPrintOff.UseVisualStyleBackColor = true;
            this.autoPrintOff.CheckedChanged += new System.EventHandler(this.autoPrintOff_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Include MDC";
            // 
            // includeMdcOff
            // 
            this.includeMdcOff.AutoSize = true;
            this.includeMdcOff.Checked = true;
            this.includeMdcOff.Enabled = false;
            this.includeMdcOff.Location = new System.Drawing.Point(48, 8);
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
            this.includeMdcOn.Enabled = false;
            this.includeMdcOn.Location = new System.Drawing.Point(3, 8);
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
            this.panel1.Location = new System.Drawing.Point(108, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 28);
            this.panel1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 368);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.autoPrintOff);
            this.Controls.Add(this.autoPrintOn);
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
            this.Text = "FG-1 MDC Update V2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.RadioButton autoPrintOn;
        private System.Windows.Forms.RadioButton autoPrintOff;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton includeMdcOff;
        private System.Windows.Forms.RadioButton includeMdcOn;
        private System.Windows.Forms.Panel panel1;
    }
}

