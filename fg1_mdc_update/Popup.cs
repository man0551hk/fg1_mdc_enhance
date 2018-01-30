using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fg1_mdc_update
{
    public partial class Popup : Form
    {
        public static string fileName = "";
        public event EventHandler PrintReady;
        public Popup(string fileName)
        {
            InitializeComponent();
            this.CenterToScreen();
            reportFileName.Text = fileName;
            try
            {
                if (Form1.autoPrint)
                {
                    Print(fileName);
                }
            }
            catch (Exception ex)
            { 
                
            }
            finally
            {
                
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            Print(reportFileName.Text);
        }

        public void Print(string fileName)
        {
            Process print = new Process();
            print.StartInfo.FileName = fileName;
            print.StartInfo.Verb = "Print";
            print.StartInfo.UseShellExecute = true;
            print.StartInfo.CreateNoWindow = true;
            print.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            print.Start();
            print.CloseMainWindow();
            print.Close();

            //while (print.Responding)
            //{
            //    Debug.WriteLine("Status = Running");
            //}
            //this.Close();

            //PrintDocument pd = new PrintDocument();
            //pd.DocumentName = fileName;
            //pd.EndPrint += new PrintEventHandler(printDocument_EndPrint);
            //pd.Print();
        }

        void printDocument_EndPrint(object sender, PrintEventArgs e)
        {
            if (this.PrintReady != null)
            {
                this.PrintReady.Invoke(this, null);
                this.Close();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(reportFileName.Text))
            {
                //System.Diagnostics.Process.Start(reportFileName.Text);
                System.Diagnostics.Process.Start(@"C:\Program Files\Windows NT\Accessories\wordpad.exe", reportFileName.Text);
            }
        }

        private void ctrlBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();

        }
    }
}
