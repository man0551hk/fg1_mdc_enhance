﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using fg1_mdc_update.objClass;
using System.Threading;
using System.Drawing.Printing;

namespace fg1_mdc_update
{
    public partial class Form1 : Form
    {
        initSetup thisSetup = new initSetup();
        BgCount bgCount = new BgCount();
        EffValue effValue = new EffValue();
        Report report = new Report();
        string jsonPath = AppDomain.CurrentDomain.BaseDirectory + "initSetup.json";

        public static bool autoPrint = false;

        public const bool delRad = true;            // Radionuclide data deletion function
        public const bool includeMDC = true;        // MDC Update function
        public const bool includeRatioSum = false;
        public const bool showI131 = false;         // Flag to show I-131 data
        public const bool showRu103 = false;
        public const bool showCs137 = true;
        public const bool showCs134 = true;
        public const bool showK40 = false;
        public const bool show137134 = true;

        public const double i131Br = 0.817;
        public const double ru103Br = 0.91;
        public const double cs137Br = 0.851;
        public const double cs134Br = 0.855;
        public const double k40Br = 0.1067;
        // Define Filenames for Background and Calibration
        string fg_path = "C:\\USER\\Foodguard-1";
        string bgd_file = "\\BKGCNT.DAT";
        string Cal_file = "\\CALINFO.DAT";

        List<string> reportLines = null;
        List<string> historyLine = null;

        DateTime startUp = new DateTime();

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
           
        }

        public void LoadJson()
        {
            //WriteLog("Start read json");
            WriteLog("Manual Mode");
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                thisSetup = js.Deserialize<initSetup>(File.ReadAllText(jsonPath));
                fg1Path.Text = thisSetup.fg1Path;
                //bgValuesPath.Text = thisSetup.bgValuesPath;
                //effValuesPath.Text = thisSetup.effValuesPath;
            }
            catch (Exception ex)
            {
                WriteLog("Read Json Error" + ex.Message);
            }
            logText.Focus();
        }

        public void LoadHistory()
        {
            string historyPath = AppDomain.CurrentDomain.BaseDirectory + "history.log";
            if (!File.Exists(historyPath))
            {
                File.WriteAllText(historyPath, "");
            }
            historyLine = new List<string>(File.ReadAllLines(historyPath));
        }

        public void WriteLog(string msg)
        {
            try
            {
                logText.AppendText(msg + System.Environment.NewLine);
            }
            catch
            {

            }
        }

        public void WriteLogThread(string msg)
        {
            try
            {
                logText.Invoke(new MethodInvoker(delegate { logText.AppendText(msg + System.Environment.NewLine); }));
            }
            catch
            {

            }
        }

        private void opBtn1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                thisSetup.fg1Path = folderBrowserDialog1.SelectedPath;
                fg1Path.Text = thisSetup.fg1Path;
                SaveInitSetup();
            }
        }

        public void SaveInitSetup()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(thisSetup);
            File.WriteAllText(jsonPath, json);
        }

        private void manualSelBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                manualFilePath.Text = openFileDialog1.FileName;
            }
        }

        bool manaulRun = false;
        private void manualReadBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(manualFilePath.Text) && File.Exists(manualFilePath.Text))
            {
                Thread readThread = new Thread(new ThreadStart(RunManaul));
                readThread.Start();
            }
            else
            {
                WriteLog("Input Report File to Update : ");
            }
        }

        public void RunManaul()
        {
            // comment out 
            // WriteLog("Start Read" + manualFilePath.Text);
            string fileExtension = Path.GetExtension(manualFilePath.Text);
            if (fileExtension.ToLower() == ".txt")
            {
                bool isCal = false;
                bool isValid = false;
                bool haveUnCert = false;
                string unitName = "Bq/Kg";
                bool process = ReadReportFile(manualFilePath.Text, ref isCal, ref isValid, ref haveUnCert, ref unitName);
                if (process)
                {
                    //bool isBg = ReadBgCnt(bgValuesPath.Text);
                    bool isBg = ReadBgCnt(thisSetup.bgValuesPath);

                    bool isEff = ReadEff(thisSetup.effValuesPath);
                    if (isBg && isEff)
                    {
                        Calculate(haveUnCert, unitName);
                        WriteReport(manualFilePath.Text);
                    }
                    WriteLogThread("Report Updated");
                }
                else if (isCal)
                {
                    WriteLogThread("Report Already Updated");
                }
                else if (!isValid)
                {
                    WriteLogThread("Invalid File Format");
                }
            }
            else
            {
                WriteLogThread(manualFilePath.Text + " This is NOT FG-1 Report !");
            }
            manaulRun = false;
        }

        public string ReplaceText(string origin, string elementName)
        {
            return origin.Replace(elementName, "").Replace("Detected", "").Replace("Not", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Replace("Bq/L", "").Trim();
        }

        public bool ReadReportFile(string path, ref bool isCal, ref bool isValidFile, ref bool haveUnCert, ref string unitName)
        {
            bool process = true;
            reportLines = new List<string>(File.ReadAllLines(path));
            bool startReadAct = false;
            bool isShortReport = false;
            bool findElement = false;
            for (int i = 0; i < reportLines.Count; i++)
            {
                try
                {
                    if (reportLines[i].Contains("Sample Weight:"))
                    {
                        string line = reportLines[i].Replace("Kilograms", "").Replace("Sample Weight:", "").Replace("Liters", "").Trim();
                        report.sampleWeight = Convert.ToDouble(line);
                    }
                    else if (reportLines[i].Contains("Counting Time:"))
                    {
                        string line = reportLines[i].Replace("Counting Time:", "").Replace("Min", "").Trim();
                        report.countTime = Convert.ToDouble(line);
                    }
                    else if (reportLines[i].Contains("I-131") && ((reportLines[i].Contains("Detected") || startReadAct) || reportLines[i].Contains("Activity:")))
                    {
                        string line = ReplaceText(reportLines[i], "I-131");
                        if (reportLines[i].Contains("Activity:"))
                        {
                            isShortReport = true;
                        }
                        //string line = reportLines[i].Replace("Detected", "").Replace("Not", "").Replace("I-131", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Trim();
                        if (line.Contains(" "))
                        {
                            if (haveUnCert)
                            {
                                string line1 = line.Substring(0, line.IndexOf(" "));
                                string line2 = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                                line = line1.Trim();
                                report.i131Uncert = line2.Trim();
                            }
                            else if (reportLines[i].Contains("Uncertainty:"))
                            {

                            }
                            else
                            {
                                line = line.Substring(0, line.IndexOf(" "));
                            }
                        }
                        report.i131Act = Convert.ToDouble(line);
                        findElement = true;
                    }
                    else if (reportLines[i].Contains("Ru-103") && ((reportLines[i].Contains("Detected") || startReadAct) || reportLines[i].Contains("Activity:")))
                    {
                        string line = ReplaceText(reportLines[i], "Ru-103");
                        if (reportLines[i].Contains("Activity:"))
                        {
                            isShortReport = true;
                        }
                        //string line = reportLines[i].Replace("Detected", "").Replace("Not", "").Replace("Ru-103", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Trim();
                        if (line.Contains(" "))
                        {
                            if (haveUnCert)
                            {
                                string line1 = line.Substring(0, line.IndexOf(" "));
                                string line2 = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                                line = line1.Trim();
                                report.ru103Uncert = line2.Trim();
                            }
                            else
                            {
                                line = line.Substring(0, line.IndexOf(" "));
                            }
                        }
                        report.ru103Act = Convert.ToDouble(line);
                        findElement = true;

                    }
                    else if (reportLines[i].Contains("Cs-137/Cs-134 ") && ((reportLines[i].Contains("Detected") || startReadAct) || reportLines[i].Contains("Activity:")))
                    {
                        string line = ReplaceText(reportLines[i], "Cs-137/Cs-134");
                        if (reportLines[i].Contains("Activity:"))
                        {
                            isShortReport = true;
                        }
                        //string line = reportLines[i].Replace("Detected", "").Replace("Not", "").Replace("Cs-137/Cs-134", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Trim();
                        if (line.Contains(" "))
                        {
                            if (haveUnCert)
                            {
                                string line1 = line.Substring(0, line.IndexOf(" "));
                                string line2 = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                                line = line1.Trim();
                                report.cs137134Uncert = line2.Trim();
                            }
                            else
                            {
                                line = line.Substring(0, line.IndexOf(" "));
                            }
                        }
                        report.cs137134Act = Convert.ToDouble(line);
                        findElement = true;

                    }
                    else if (reportLines[i].Contains("Cs-137") && ((reportLines[i].Contains("Detected") || startReadAct) || reportLines[i].Contains("Activity:")))
                    {
                        string line = ReplaceText(reportLines[i], "Cs-137");
                        if (reportLines[i].Contains("Activity:"))
                        {
                            isShortReport = true;
                        }
                        //string line = reportLines[i].Replace("Detected", "").Replace("Not", "").Replace("Cs-137", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Trim();
                        if (line.Contains(" "))
                        {
                            if (haveUnCert)
                            {
                                string line1 = line.Substring(0, line.IndexOf(" "));
                                string line2 = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                                line = line1.Trim();
                                report.cs137Uncert = line2.Trim();
                            }
                            else
                            {
                                line = line.Substring(0, line.IndexOf(" "));
                            }
                        }
                        report.cs137Act = Convert.ToDouble(line);
                        findElement = true;

                    }
                    else if (reportLines[i].Contains("Cs-134") && ((reportLines[i].Contains("Detected") || startReadAct) || reportLines[i].Contains("Activity:")))
                    {
                        string line = ReplaceText(reportLines[i], "Cs-134");
                        if (reportLines[i].Contains("Activity:"))
                        {
                            isShortReport = true;
                        }
                        //string line = reportLines[i].Replace("Detected", "").Replace("Not", "").Replace("Cs-134", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Trim();
                        if (line.Contains(" "))
                        {
                            if (haveUnCert)
                            {
                                string line1 = line.Substring(0, line.IndexOf(" "));
                                string line2 = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                                line = line1.Trim();
                                report.cs134Uncert = line2.Trim();
                            }
                            else
                            {
                                line = line.Substring(0, line.IndexOf(" "));
                            }
                        }
                        report.cs134Act = Convert.ToDouble(line);
                        findElement = true;

                    }
                    else if (reportLines[i].Contains("K-40") && ((reportLines[i].Contains("Detected") || startReadAct) || reportLines[i].Contains("Activity:")))
                    {
                        string line = ReplaceText(reportLines[i], "K-40");
                        if (reportLines[i].Contains("Activity:"))
                        {
                            isShortReport = true;
                        }
                        //string line = reportLines[i].Replace("Detected", "").Replace("Not", "").Replace("K-40", "").Replace("*", "").Replace("Activity:", "").Replace("Bq/Kg", "").Trim();
                        if (line.Contains(" "))
                        {
                            if (haveUnCert)
                            {
                                string line1 = line.Substring(0, line.IndexOf(" "));
                                string line2 = line.Substring(line.IndexOf(" ") + 1, line.Length - (line.IndexOf(" ") + 1));
                                line = line1.Trim();
                                report.k40Uncert = line2.Trim();
                            }
                            else
                            {
                                line = line.Substring(0, line.IndexOf(" "));
                            }
                        }
                        report.k40Act = Convert.ToDouble(line);
                        findElement = true;

                    }
                    else if (reportLines[i].Contains("----") && !reportLines[i].Contains(":"))
                    {
                        startReadAct = true;
                    }
                    //else if (reportLines[i].Contains("====") && !reportLines[i].Contains(":"))
                    //{
                    //    startReadAct = true;
                    //}
                    // Modified MDC Value to Report Value by Ron
                    else if ((reportLines[i].Contains("Report Value (Bq/Kg)") || reportLines[i].Contains("Report Value (Bq/L)")) && reportLines[i].Contains("Radionuclide"))
                    {
                        isCal = true;
                    }
                    else if (reportLines[i].Contains("Uncertainty (%)") && (reportLines[i].Contains("Activity (Bq/Kg)") || reportLines[i].Contains("Activity (Bq/L)")) && reportLines[i].Contains("Radionuclide"))
                    {
                        haveUnCert = true;
                        if (reportLines[i].Contains("Bq/Kg"))
                        {
                            unitName = "Bq/Kg";
                        }
                        else if (reportLines[i].Contains("Bq/L"))
                        {
                            unitName = "Bq/L";
                        }
                    }
                    else if ((reportLines[i].Contains("Activity (Bq/Kg)") || reportLines[i].Contains("Activity (Bq/L)")) && reportLines[i].Contains("Radionuclide"))
                    {
                        if (reportLines[i].Contains("Bq/Kg"))
                        {
                            unitName = "Bq/Kg";
                        }
                        else if (reportLines[i].Contains("Bq/L"))
                        {
                            unitName = "Bq/L";
                        }
                    }

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Input string was not in a correct format") && isShortReport)
                    { }
                    else
                    {
                        WriteLog("Read Report Line" + i + " Error:" + ex.Message + " " + reportLines[i]);
                    }
                }
            }

            if (findElement)
            {
                isValidFile = true;
            }

            //temp 
            if (isShortReport)
            {
                isValidFile = false;
            }

            if (isValidFile && !isCal)
            {
                process = true;
            }
            else
            {
                process = false;
            }
            if (findElement && process)
            {
                if (isShortReport)
                {
                    WriteLogThread(path.Substring(path.LastIndexOf(@"\") + 1, path.Length - (path.LastIndexOf(@"\") + 1)) + " is short report");
                }
                else
                {
                    WriteLogThread(path.Substring(path.LastIndexOf(@"\") + 1, path.Length - (path.LastIndexOf(@"\") + 1)) + " read ok !");
                }
            }
            return process;
        }

        public bool ReadBgCnt(string path)
        {
            bool isRead = true;
            int tryCount = 0;
            while (tryCount < 2)
            {
                bgCount = new BgCount();
                string tempPath = "";
                try
                {
                    tempPath = path.Replace(".DAT", "_temp.DAT");
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }
                    File.Copy(path, tempPath);
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    // WriteLogThread(ex.Message); modified on 25 Jan 2018
                }

                if (!File.Exists(tempPath))
                {
                    isRead = false;
                    WriteLogThread(tempPath + " not existed");
                    Thread.Sleep(500); // sleep 1 sec to wwait release
                }
                if (isRead)
                {
                    FileInfo fileInfo = new FileInfo(tempPath);
                    long fileSize = fileInfo.Length;
                    if (fileSize != 170)
                    {
                        isRead = false;
                    }
                    else
                    {
                        BinaryReader b = null;
                        try
                        {
                            using (b = new BinaryReader(File.Open(tempPath, FileMode.Open)))
                            {
                                int ctPOS = 96;
                                int ctLenght = 2;

                                byte[] ct = b.ReadBytes(ctLenght);
                                bgCount.bgTime = BitConverter.ToInt16(ct, 0);

                                ctPOS = ctPOS + ctLenght;
                                ctLenght = 8;

                                int lastPos = ctPOS + (8 * 6);
                                int countEle = 0;
                                while (countEle <= 5)
                                {
                                    try
                                    {
                                        b.BaseStream.Seek(ctPOS, SeekOrigin.Begin);
                                        ct = b.ReadBytes(ctLenght);
                                        switch (countEle)
                                        {
                                            case 0: bgCount.i131CPS = BitConverter.ToDouble(ct, 0); break;
                                            case 1: bgCount.ru103CPS = BitConverter.ToDouble(ct, 0); break;
                                            case 2: bgCount.cs137CPS = BitConverter.ToDouble(ct, 0); break;
                                            case 3: bgCount.cs134CPS = BitConverter.ToDouble(ct, 0); break;
                                            case 4: bgCount.k40CPS = BitConverter.ToDouble(ct, 0); break;
                                            case 5: bgCount.totalCPS = BitConverter.ToDouble(ct, 0); break;
                                        }
                                        ctPOS += 8;
                                        countEle++;
                                    }
                                    catch (Exception ex)
                                    {
                                        WriteLogThread("Counting error" + ex.Message);
                                    }
                                }
                                //double start = BitConverter.ToDouble(by, 0);
                            }

                        }
                        catch (Exception ex)
                        {
                            isRead = false;
                            WriteLogThread("Binary Error:" + ex.Message);
                            Thread.Sleep(1000); // sleep 1 sec to wwait release
                        }
                        finally
                        {
                            b.Dispose();
                        }
                    }
                }
                tryCount++;
            }
            return isRead;
        }

        public bool ReadEff(string path)
        {
            bool isRead = true;
            int tryCount = 0;
            while (tryCount < 2)
            {
                string tempPath = "";
                try
                {
                    tempPath = path.Replace(".DAT", "_temp.DAT");
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                    }
                    File.Copy(path, tempPath);
                    Thread.Sleep(800);
                }
                catch (Exception ex)
                {
                    //WriteLogThread("Copy .Dat error: " + ex.Message);
                }

                if (!File.Exists(tempPath))
                {
                    isRead = false;
                    WriteLogThread(tempPath + " not existed");
                }
                if (isRead)
                {
                    FileInfo fileInfo = new FileInfo(tempPath);
                    long fileSize = fileInfo.Length;
                    if (fileSize != 672)
                    {
                        isRead = false;
                    }
                    else
                    {
                        BinaryReader b = null;
                        try
                        {
                            using (b = new BinaryReader(File.Open(tempPath, FileMode.Open)))
                            {
                                int ctPOS = 592;
                                int ctLenght = 8;
                                byte[] ct = null;

                                int lastPos = ctPOS + (8 * 6);
                                int countEle = 0;
                                while (countEle <= 4)
                                {
                                    try
                                    {
                                        b.BaseStream.Seek(ctPOS, SeekOrigin.Begin);
                                        ct = b.ReadBytes(ctLenght);
                                        switch (countEle)
                                        {
                                            case 0: effValue.i131Eff = BitConverter.ToDouble(ct, 0); break;
                                            case 1: effValue.ru103Eff = BitConverter.ToDouble(ct, 0); break;
                                            case 2: effValue.cs137Eff = BitConverter.ToDouble(ct, 0); break;
                                            case 3: effValue.cs134Eff = BitConverter.ToDouble(ct, 0); break;
                                            case 4: effValue.k40Eff = BitConverter.ToDouble(ct, 0); break;
                                        }
                                        ctPOS += 8;
                                        countEle++;
                                    }
                                    catch (Exception ex)
                                    {
                                        WriteLogThread(ex.Message);
                                    }
                                }
                                //double start = BitConverter.ToDouble(by, 0);
                            }
                        }
                        catch (Exception ex)
                        {
                            isRead = false;
                            WriteLogThread(ex.Message);
                        }
                        finally
                        {
                            b.Dispose();
                        }
                    }
                }
                tryCount++;
            }
            return isRead;
        }

        public void Calculate(bool haveUnCert, string unitName)
        {
            // { { 4.66 X SqRt [ ( Bgd X Bgd_Time ) X ( 1 + CTime / Bgd_Time ) ] } / ( Eff X CTime X BR ) } / W - For different bgd &  measuring time 
            //   { 4.66 X SqRt [ ( Bgd X Bgd_Time ) ] / ( Eff X CTime X BR ) } / W - FG-1 MDC equation    
            report.i131Mdc = (4.66 * Math.Sqrt(bgCount.i131CPS * report.countTime * 60) / (effValue.i131Eff * report.countTime * 60)) / report.sampleWeight;
            report.ru103Mdc = (4.66 * Math.Sqrt(bgCount.ru103CPS * report.countTime * 60) / (effValue.ru103Eff * report.countTime * 60)) / report.sampleWeight;
            report.cs137Mdc = (4.66 * Math.Sqrt(bgCount.cs137CPS * report.countTime * 60) / (effValue.cs137Eff * report.countTime * 60)) / report.sampleWeight;
            report.cs134Mdc = (4.66 * Math.Sqrt(bgCount.cs134CPS * report.countTime * 60) / (effValue.cs134Eff * report.countTime * 60)) / report.sampleWeight;
            report.k40Mdc = (4.66 * Math.Sqrt(bgCount.k40CPS * report.countTime * 60) / (effValue.k40Eff * report.countTime * 60)) / report.sampleWeight;
            report.cs137134Mdc = report.cs137Mdc + report.cs134Mdc;

            report.i131Mdc = Math.Round(report.i131Mdc, 2, MidpointRounding.AwayFromZero);
            report.ru103Mdc = Math.Round(report.ru103Mdc, 2, MidpointRounding.AwayFromZero);
            report.cs137Mdc = Math.Round(report.cs137Mdc, 2, MidpointRounding.AwayFromZero);
            report.cs134Mdc = Math.Round(report.cs134Mdc, 2, MidpointRounding.AwayFromZero);
            report.k40Mdc = Math.Round(report.k40Mdc, 2, MidpointRounding.AwayFromZero);
            report.cs137134Mdc = Math.Round(report.cs137134Mdc, 2, MidpointRounding.AwayFromZero);

            if (report.i131Act >= report.i131Mdc) // modifed by Ron
            {
                report.i131Res = report.i131Act.ToString();
                if (haveUnCert)
                {
                    //report.i131Res += " " + unitName + " " + report.i131Uncert + "%";
                    report.i131Res += " +/- " + Math.Round((Convert.ToDouble(report.i131Uncert) / 100) * report.i131Act, 2, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                report.i131Res = "< " + report.i131Mdc;
            }

            if (report.ru103Act >= report.ru103Mdc)
            {
                report.ru103Res = report.ru103Act.ToString();
                if (haveUnCert)
                {
                    //report.ru103Res += " " + unitName + " " + report.ru103Uncert + "%";
                    report.ru103Res += " +/- " + Math.Round((Convert.ToDouble(report.ru103Uncert) / 100) * report.ru103Act, 2, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                report.ru103Res = "< " + report.ru103Mdc;
            }

            if (report.cs137Act >= report.cs137Mdc)
            {
                report.cs137Res = report.cs137Act.ToString();
                if (haveUnCert)
                {
                    //report.cs137Res += " " + unitName + " " + report.cs137Uncert + "%";
                    report.cs137Res += " +/- " + Math.Round((Convert.ToDouble(report.cs137Uncert) / 100) * report.cs137Act, 2, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                report.cs137Res = "< " + report.cs137Mdc;
            }

            if (report.cs134Act >= report.cs134Mdc)
            {
                report.cs134Res = report.cs134Act.ToString();
                if (haveUnCert)
                {
                    // report.cs134Res += " " + unitName + " " + report.cs134Uncert + "%";
                    report.cs134Res += " +/- " + Math.Round((Convert.ToDouble(report.cs134Uncert) / 100) * report.cs134Act, 2, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                report.cs134Res = "< " + report.cs134Mdc;
            }

            if (report.k40Act >= report.k40Mdc)
            {
                report.k40Res = report.k40Act.ToString();
                if (haveUnCert)
                {
                    //report.k40Res += " " + unitName + " " + report.k40Uncert + "%";
                    report.k40Res += " +/- " + Math.Round((Convert.ToDouble(report.k40Uncert) / 100) * report.k40Act, 2, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                report.k40Res = "< " + report.k40Mdc;
            }

            if (report.cs137134Act >= report.cs137134Mdc)
            {
                report.cs137134Res = report.cs137134Act.ToString();
                if (haveUnCert)
                {
                    //report.cs137134Res += " " + unitName + " " + report.cs137134Uncert + "%";
                    report.cs137134Res += " +/- " + Math.Round((Convert.ToDouble(report.cs137134Uncert) / 100) * report.cs137134Act, 2, MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                report.cs137134Res = "< " + report.cs137134Mdc;
            }

            // Comment out after debug 
            /*
            WriteLogThread("MDC I-131 = " + report.i131Mdc + "      CPS = " + bgCount.i131CPS + "      Eff = " + effValue.i131Eff + "      Act = " + report.i131Act + "      Result = " + report.i131Res);
            WriteLogThread("MDC RU-103 = " + report.ru103Mdc + "      CPS:" + bgCount.ru103CPS + "      Eff = " + effValue.ru103Eff + "      Act = " + report.ru103Act + "      Result = " + report.ru103Res);
            WriteLogThread("MDC Cs-137 = " + report.cs137Mdc + "      CPS:" + bgCount.cs137CPS + "      Eff = " + effValue.cs137Eff + "      Act = " + report.cs137Act + "      Result = " + report.cs137Res);
            WriteLogThread("MDC Cs-134 = " + report.cs134Mdc + "      CPS:" + bgCount.cs134CPS + "      Eff = " + effValue.cs134Eff + "      Act = " + report.cs134Act + "      Result = " + report.cs134Res);
            WriteLogThread("MDC K-40 = " + report.k40Mdc + "      CPS:" + bgCount.k40CPS + "      Eff = " + effValue.k40Eff + "      Act = " + report.k40Act + "      Result = " + report.k40Res);
            WriteLogThread("MDC Cs-137/Cs-134 = " + report.cs137134Mdc + report.cs137134Mdc + "      CPS:" + (bgCount.cs137CPS + bgCount.cs134CPS) + "      Result = " + report.cs137134Res);
            */
        }

        public void WriteReport(string originPath)
        {
            StringBuilder sb = new StringBuilder();
            bool startWrite = false;
            for (int i = 0; i < reportLines.Count; i++)
            {
                if (reportLines[i].Contains("Radionuclide") && reportLines[i].Contains("Activity (Bq/Kg)"))
                {
                    if (includeMDC && includeMdcOn.Checked)
                    {
                        sb.AppendLine("Radionuclide           Activity (Bq/Kg)          Report Value (Bq/Kg)");
                    }
                    else
                    {
                        sb.AppendLine(reportLines[i]);
                    }
                }
                else if (reportLines[i].Contains("Radionuclide") && reportLines[i].Contains("Activity (Bq/L)"))
                {
                    if (includeMDC && includeMdcOn.Checked)
                    {
                        sb.AppendLine("Radionuclide           Activity (Bq/L)            Report Value (Bq/L)");
                    }
                    else
                    {
                        sb.AppendLine(reportLines[i]);
                    }
                }
                else if (reportLines[i].Contains("==========") && !reportLines[i].Contains(":"))
                {
                    sb.AppendLine("=====================================================================");
                }
                else if (reportLines[i].Contains("------") && !reportLines[i].Contains(":"))
                {
                    sb.AppendLine("---------------------------------------------------------------------");
                    startWrite = true;
                }
                else if (reportLines[i].Contains("I-131") && ((reportLines[i].Contains("Detected") || startWrite) || reportLines[i].Contains("Activity:")))
                {
                    // Modified on 24 Jan 2018
                    
                    
                    
                    if (!(delRadOn.Checked && !showI131))        // show I-131 condition
                        {
                        if (includeMDC && includeMdcOn.Checked)
                            {
                            sb.AppendLine(ReturnLine(reportLines[i], "I-131", report.i131Act, report.i131Res));
                            }
                        else 
                            {
                            sb.AppendLine(reportLines[i]);
                            }
                        }
                }
                else if (reportLines[i].Contains("Ru-103") && ((reportLines[i].Contains("Detected") || startWrite) || reportLines[i].Contains("Activity:")))
                {
                    if (!(delRadOn.Checked && !showRu103))        // show Ru-103 condition
                    {
                        if (includeMDC && includeMdcOn.Checked)
                        {
                            sb.AppendLine(ReturnLine(reportLines[i], "Ru-103", report.ru103Act, report.ru103Res));
                        }
                        else
                        {
                            sb.AppendLine(reportLines[i]);
                        }
                    }
                }
                else if (reportLines[i].Contains("Cs-137/Cs-134") && ((reportLines[i].Contains("Detected") || startWrite) || reportLines[i].Contains("Activity:")))
                {
                    if (!(delRadOn.Checked && !show137134))
                    {
                        if (includeMDC && includeMdcOn.Checked)
                        {
                            sb.AppendLine(ReturnLine(reportLines[i], "Cs-137/Cs-134", report.cs137134Act, report.cs137134Res));
                        }
                        else
                        {
                            sb.AppendLine(reportLines[i]);
                        }
                    }
                }
                else if (reportLines[i].Contains("Cs-137") && ((reportLines[i].Contains("Detected") || startWrite) || reportLines[i].Contains("Activity:")))
                {
                    if (!(delRadOn.Checked && !showCs137))
                    {
                        if (includeMDC && includeMdcOn.Checked)
                        {
                            sb.AppendLine(ReturnLine(reportLines[i], "Cs-137", report.cs137Act, report.cs137Res));
                        }
                        else
                        {
                            sb.AppendLine(reportLines[i]);
                        }
                        
                    }
                }
                else if (reportLines[i].Contains("Cs-134") && ((reportLines[i].Contains("Detected") || startWrite) || reportLines[i].Contains("Activity:")))
                {
                    if (!(delRadOn.Checked && !showCs134))
                    {
                        if (includeMDC && includeMdcOn.Checked)
                        {
                            sb.AppendLine(ReturnLine(reportLines[i], "Cs-134", report.cs134Act, report.cs134Res));
                        }
                        else
                        {
                            sb.AppendLine(reportLines[i]);
                        }
                    }
                }
                else if (reportLines[i].Contains("K-40") && ((reportLines[i].Contains("Detected") || startWrite) || reportLines[i].Contains("Activity:")))
                {
                    if (!(delRadOn.Checked && !showK40))
                    {
                        if (includeMDC && includeMdcOn.Checked)
                        {
                            sb.AppendLine(ReturnLine(reportLines[i], "K-40", report.k40Act, report.k40Res));
                        }
                        else
                        {
                            sb.AppendLine(reportLines[i]);    
                        }
                    }
                }
                else if (reportLines[i].Contains("Originator: _______________________________ Post: ______________________________"))
                {
                    sb.AppendLine("Originator: _________________________ Post: _________________________");
                }
                else if (reportLines[i].Contains("                      (Name & Signature)"))
                {
                    sb.AppendLine("                    (Name & Signature)");
                }
                else if (reportLines[i].Contains("Ratio Sum:"))
                {
                    if (includeRatioSum)
                    {
                        sb.AppendLine(reportLines[i]);
                    }
                }
                else
                {
                    sb.AppendLine(reportLines[i]);
                }
            }

            
            // 19 Jan 2018
            // Do not Append -UPD suffix; when BOTH includeMDCOff and delRadOff are ON

            string newPath;
            bool noNeedToSave = false;
            if ( includeMdcOff.Checked && delRadOff.Checked)
            {
                noNeedToSave = true;
                newPath = originPath;
            }
            else
            {
                newPath = originPath.Substring(0, originPath.LastIndexOf(".")).Replace(" ", "-") + "-UPD.txt";
            }
            if(noNeedToSave == false)
            {
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }
                File.WriteAllText(newPath, sb.ToString());
            }
            
            AppendHistory(originPath.Substring(originPath.LastIndexOf(@"\") + 1, originPath.Length - (originPath.LastIndexOf(@"\") + 1)));
            //System.Diagnostics.Process.Start(newPath);
            //System.Diagnostics.Process.Start(@"C:\Program Files\Windows NT\Accessories\wordpad.exe", newPath);

            FileContents = sb.ToString();
            saveAsContents = sb.ToString();
            this.BeginInvoke((Action)delegate
            {
                //Popup pu = new Popup(newPath);
                ////pu.fileName = newPath;
                //pu.Show();
              
                if (scrBtn.Checked) 
                {
                    //print thread
                    Thread printThread = new Thread(new ThreadStart(ShowPrint));
                    printThread.Start();

                    //save as
                    DialogResult dialogResult = MessageBox.Show(new Form() { TopMost = true }, "Would like to save file?", "Save as", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "txt files (*.txt)|*.txt";
                        sfd.FilterIndex = 2;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            File.WriteAllText(sfd.FileName, saveAsContents);
                            historyLine.Add(sfd.FileName);
                            AppendHistory(sfd.FileName);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else
                    }

                }
                if (printBtn.Checked)
                {
                    //auto print
                    PrintDocument pd = new PrintDocument();
                    //PrinterSettings printerName = new PrinterSettings();
                    //foreach (string s in PrinterSettings.InstalledPrinters)
                    //{
                      
                    //}
                    pd.DocumentName = newPath;
                    pd.Print();

                }
                if (scrBtn.Checked)
                {

                }
            });
        }

        public void ShowPrint()
        {

            PrintPreviewDialog ppd = new PrintPreviewDialog();
            ppd.Width = (Screen.PrimaryScreen.WorkingArea.Width) / 2;     // 27 Jan 2018
            ppd.Height = Screen.PrimaryScreen.WorkingArea.Height;
           
            System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
            pd.PrintPage += pd_PrintPage;
            ppd.Document = pd;
            ppd.ShowDialog();
        }


        private static string FileContents = "";
        private static string saveAsContents = "";
        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            using (Font font = new Font("Courier New", 10))
            {
                using (StringFormat string_format = new StringFormat())
                {
                    SizeF layout_area = new SizeF(e.MarginBounds.Width, e.MarginBounds.Height);
                    int chars_fitted, lines_filled;
                    e.Graphics.MeasureString(FileContents, font, layout_area, string_format, out chars_fitted, out lines_filled);
                    e.Graphics.DrawString(FileContents.Substring(0, chars_fitted), font, Brushes.Black, e.MarginBounds, string_format);
                    FileContents = FileContents.Substring(chars_fitted).Trim();
                }
            }

            // See if we are done.
            e.HasMorePages = FileContents.Length > 0;
            if (!e.HasMorePages)
            {
                FileContents = saveAsContents;
            }
        }


        public string ReturnLine(string line, string name, double act, string res)
        {
            string d = "";
            string s = "";
            if (line.Contains("*"))
            {
                s = "*";
            }
            int spaceLength = 38 - name.Length - act.ToString().Length;
            string space = "";
            for (int k = 0; k < spaceLength; k++)
            {
                space += " ";
            }
            string secondSpace = "    ";
            if (s == "*")
            {
                secondSpace = "   ";
            }
            int lastSpaceLength = 69 - (name + space + act + s + secondSpace + d).Length - res.Length;
            string lastSpace = "";
            for (int k = 0; k < lastSpaceLength; k++)
            {
                lastSpace += " ";
            }
            return name + space + act + s + secondSpace + d + lastSpace + res;
        }

        bool run = false;
        Thread readThread = null;
        private void ctrlBtn_Click(object sender, EventArgs e)
        {
            if (readThread != null)
            {
                readThread.Abort();
            }
            readThread = new Thread(new ThreadStart(StartTrigger));
            if (ctrlBtn.Text == "Auto Off")
            {
                startUp = DateTime.Now; //get the button click time for trigger
                ctrlBtn.Text = "Auto On";
                WriteLog("Auto Mode");
                DisableCtrl();
                run = true;
                readThread.Start();
            }
            else
            {
                ctrlBtn.Text = "Auto Off";
                WriteLog("Manual Mode");
                EnableCtrl();
                readThread.Abort();
                run = false;
            }
        }

        public bool FindInHistory(string name)
        {
            bool found = false;
            for (int i = 0; i < historyLine.Count; i++)
            {
                if (historyLine[i] == name)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public void StartTrigger()
        {
            try
            {
                string thisFg1Path = "";
                string reportDirectory = "";
                fg1Path.Invoke(new MethodInvoker(delegate { thisFg1Path = fg1Path.Text; }));
                //bool isBg = ReadBgCnt(fg1Path.Text + bgd_file);
                //bool isBg = ReadBgCnt(bgd_file);
                // bool isEff = ReadEff(Cal_file);
                //bool isEff = ReadEff(fg1Path.Text + Cal_file);

                reportDirectory = thisFg1Path + "\\reports";
                if (!Directory.Exists(reportDirectory))
                {
                    WriteLogThread(reportDirectory + " not existed");
                }

                if (Directory.Exists(reportDirectory))
                {
                    string[] fileEntries = null;
                    while (run)
                    {
                        bool isBg = ReadBgCnt(thisSetup.bgValuesPath);
                        bool isEff = ReadEff(thisSetup.effValuesPath);
                        fileEntries = Directory.GetFiles(reportDirectory);
                        if (isBg && isEff)
                        {
                            try
                            {
                                foreach (string fileName in fileEntries)
                                {
                                    if (!fileName.Contains("-UPD"))
                                    {
                                        string fileExtension = Path.GetExtension(fileName);
                                        string mdcName = fileName.Substring(0, fileName.LastIndexOf(".")).Replace(" ", "-") + "-UPD.txt";
                                        DateTime lastModifiedTime = File.GetLastWriteTime(fileName);
                                        bool isFound = FindInHistory(fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - (fileName.LastIndexOf(@"\") + 1)));// check if the report is chekced before

                                        bool pass = true;
                                        if (isFound)
                                        {
                                            pass = false;
                                        }

                                        if (fileExtension.ToLower() != ".txt" && pass)
                                        {
                                            pass = false;
                                            WriteLogThread(fileName + "  This is NOT FG-1 Report !");
                                        }

                                        //if (lastModifiedTime < DateTime.Parse("2017-09-01 00:00:00") && pass)
                                        if (lastModifiedTime < startUp && pass)
                                        {
                                            pass = false;
                                            //WriteLogThread(fileName + " it is not a new file");
                                        }

                                        if (File.Exists(mdcName) && pass)
                                        {
                                            pass = false;
                                            WriteLogThread(mdcName + " existed");
                                        }


                                        if (pass)
                                        {
                                            // Comment Out 
                                            // WriteLogThread("Start Read" + fileName);
                                            bool isCal = false;
                                            bool isValid = false;
                                            bool haveUnCert = false;
                                            string unitName = "Bq/Kg";
                                            bool process = ReadReportFile(fileName, ref isCal, ref isValid, ref haveUnCert, ref unitName);
                                            if (process)
                                            {
                                                Calculate(haveUnCert, unitName);
                                                WriteReport(fileName);
                                                WriteLogThread("Update Completed !");
                                                WriteLogThread("");
                                            }
                                            else if (isCal)
                                            {
                                                WriteLogThread("Report Already Updated !");
                                                AppendHistory(fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - (fileName.LastIndexOf(@"\") + 1)));
                                            }
                                            else if (!isValid)
                                            {
                                                WriteLogThread("Invalid File Format !");
                                                AppendHistory(fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - (fileName.LastIndexOf(@"\") + 1)));
                                            }
                                        }
                                        else
                                        {
                                            if (!isFound)
                                            {
                                                //WriteLogThread(fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - (fileName.LastIndexOf(@"\") + 1)) + " Can't procced");
                                                AppendHistory(fileName.Substring(fileName.LastIndexOf(@"\") + 1, fileName.Length - (fileName.LastIndexOf(@"\") + 1)));
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                WriteLog("Trigger Error !" + ex.Message);
                            }
                        }
                        //try
                        //{
                        //    if (!string.IsNullOrEmpty(fg1Path.Text))
                        //    {
                        //        fileEntries = Directory.GetFiles(fg1Path.Text);
                        //    }
                        //}
                        //catch(Exception ex) {
                        //    WriteLog("Get file list error! " + ex.Message);
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                // WriteLogThread(ex.Message); // Modified on 25 Jan 2018
            }
        }

        //add the file after calculated
        public void AppendHistory(string name)
        {
            historyLine.Add(name);
            string historyPath = AppDomain.CurrentDomain.BaseDirectory + "history.log";
            File.AppendAllText(historyPath, name + System.Environment.NewLine);
        }

        public void DisableCtrl()
        {
            fg1Path.Enabled = false;
            opBtn1.Enabled = false;
            //bgValuesPath.Enabled = false;
            //opBtn2.Enabled = false;
            //effValuesPath.Enabled = false;
            //opBtn3.Enabled = false;
            manualFilePath.Enabled = false;
            manualSelBtn.Enabled = false;
            manualReadBtn.Enabled = false;
            scrBtn.Enabled = true;  // 27 Jan 2018
            printBtn.Enabled = true;
            // added by Ron 24 Jan 18
            if (!includeMDC)
            {
                includeMdcOn.Enabled = false;
                includeMdcOff.Enabled = false;
            }

            if(!delRad)
            {
                delRadOff.Enabled = false;
                delRadOn.Enabled = false;
            }
        }

        public void EnableCtrl()
        {
            fg1Path.Enabled = true;
            opBtn1.Enabled = true;
            //bgValuesPath.Enabled = true;
            //opBtn2.Enabled = true;
            //effValuesPath.Enabled = true;
            //opBtn3.Enabled = true;
            manualFilePath.Enabled = true;
            manualSelBtn.Enabled = true;
            manualReadBtn.Enabled = true;
            scrBtn.Enabled = true;
            printBtn.Enabled = true;

            // added by Ron 24 Jan 2018
            if ( includeMDC )
                {
                    includeMdcOn.Enabled = true;
                    includeMdcOff.Enabled = true;
                }

            if (delRad)
            {
                delRadOff.Enabled = true;
                delRadOn.Enabled = true;
            }
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (readThread != null)
            {
                readThread.Abort();
            }
            Environment.Exit(Environment.ExitCode);
            //Close();
        }

        private void fg1Path_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadJson();
            LoadHistory();
            openFileDialog1.FileName = "";
            openFileDialog2.FileName = "";
            openFileDialog3.FileName = "";

            includeMdcOn.Checked = false;
            includeMdcOff.Checked = true;
            delRadOn.Checked = false;
            delRadOff.Checked = true;
            openFileDialog4.InitialDirectory = fg1Path.Text;
            //else
            //{
            //    includeMdcOn.Checked = false;
            //    includeMdcOff.Checked = true;
            //}

            if ( printBtn.Checked)
            {
                autoPrint = true;
            }
            if (printBtn.Checked)
            {
                autoPrint = false;
            }
            
           
            if (thisSetup.autoMode == 1)
            {
                readThread = new Thread(new ThreadStart(StartTrigger));
                if (ctrlBtn.Text == "Auto Off")
                {
                    startUp = DateTime.Now; //get the button click time for trigger
                    ctrlBtn.Text = "Auto On";
                    WriteLog("Auto Mode");
                    DisableCtrl();
                    run = true;
                    readThread.Start();
                }
                else
                {
                    ctrlBtn.Text = "Auto Off";
                    WriteLog("Manual Mode");
                    EnableCtrl();
                    readThread.Abort();
                    run = false;
                }
            }
        }

        private void autoPrintOn_CheckedChanged(object sender, EventArgs e)
        {
            if (printBtn.Checked)
            {
                autoPrint = true;
            }
            if (printBtn.Checked)
            {
                autoPrint = false;
            }
        }

        private void autoPrintOff_CheckedChanged(object sender, EventArgs e)
        {
            if (printBtn.Checked)
            {
                autoPrint = true;
            }
            if (printBtn.Checked)
            {
                autoPrint = false;
            }
        }

        
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void delRadOff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void printReportBtn_Click(object sender, EventArgs e)
        {
            openFileDialog4.InitialDirectory = "C:\\User\\FoodGuard-1\\Reports\\";  // 29 Jan 2018 Set Default Report Directory
            if (openFileDialog4.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog4.FileName))
            {
                FileContents = File.ReadAllText(openFileDialog4.FileName);
                saveAsContents = FileContents;
                ShowPrint();
            }
        } 

    }
}
