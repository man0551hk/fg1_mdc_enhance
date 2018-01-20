namespace fg1_mdc_update
{
    partial class Popup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Popup));
            this.reportFileName = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.ctrlBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportFileName
            // 
            this.reportFileName.AutoSize = true;
            this.reportFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportFileName.Location = new System.Drawing.Point(12, 9);
            this.reportFileName.Name = "reportFileName";
            this.reportFileName.Size = new System.Drawing.Size(105, 13);
            this.reportFileName.TabIndex = 1;
            this.reportFileName.Text = "Report File Name";
            // 
            // printButton
            // 
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.Location = new System.Drawing.Point(15, 36);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(45, 45);
            this.printButton.TabIndex = 2;
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // openButton
            // 
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.Location = new System.Drawing.Point(72, 36);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(45, 45);
            this.openButton.TabIndex = 3;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // ctrlBtn
            // 
            this.ctrlBtn.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlBtn.ForeColor = System.Drawing.Color.Blue;
            this.ctrlBtn.Location = new System.Drawing.Point(569, 50);
            this.ctrlBtn.Name = "ctrlBtn";
            this.ctrlBtn.Size = new System.Drawing.Size(112, 31);
            this.ctrlBtn.TabIndex = 10;
            this.ctrlBtn.Text = "Close";
            this.ctrlBtn.UseVisualStyleBackColor = true;
            this.ctrlBtn.Click += new System.EventHandler(this.ctrlBtn_Click);
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 92);
            this.Controls.Add(this.ctrlBtn);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.reportFileName);
            this.Name = "Popup";
            this.Text = "Popup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reportFileName;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button ctrlBtn;
    }
}