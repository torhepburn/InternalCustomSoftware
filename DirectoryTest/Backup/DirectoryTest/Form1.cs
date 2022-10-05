using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DirectoryTest
{
    public partial class Form1 : Form
    {
        private string fab;
        private string firstDirectory = "\\\\zygocorp\\manufacturing" +
            "\\nif\\qc inspection reports\\cea\\cea\\status_4_accepted_by_cea";
        private string secondDirectory = "\\\\zygocorp\\manufacturing" +
            "\\nif\\qc inspection reports\\cea\\cea\\status_5_uploaded_to_cea";
        private string thirdDirectory = "\\\\zygocorp\\manufacturing" +
            "\\nif\\qc inspection reports\\cea\\cea\\status_3_submitted_to_CEA";
        private string SNdirectory = "\\\\zygocorp\\manufacturing" +
            "\\nif\\qc inspection reports\\cea\\cea";
        private int lineCount = 0;
        private int fileCount = 0;
        private string name;
        private string sourcePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"c:\a\cea.txt"))
                {
                    string line;
            
                    while ((line = sr.ReadLine()) != null)
                    {
                        fab = line.Remove(7);

                        lineCount++;

                        DirectoryInfo di1 = new DirectoryInfo(firstDirectory);
                        DirectoryInfo[] diArr1 = di1.GetDirectories(fab);

                        DirectoryInfo di2 = new DirectoryInfo(secondDirectory);
                        DirectoryInfo[] diArr2 = di2.GetDirectories(fab);

                        DirectoryInfo di3 = new DirectoryInfo(thirdDirectory);
                        DirectoryInfo[] diArr3 = di3.GetDirectories(fab);


                        if (diArr1.Length > 0)
                        {
                            FileInfo[] fiArr1 = diArr1[0].GetFiles("pvri*");
                            name = fiArr1[0].Name;
                            sourcePath = diArr1[0].FullName;
                            fileCount++;
                        }

                        if (diArr2.Length > 0)
                        {
                            FileInfo[] fiArr2 = diArr2[0].GetFiles("pvri*");
                            name = fiArr2[0].Name;
                            sourcePath = diArr2[0].FullName;
                            fileCount++;
                        }

                        if (diArr3.Length > 0)
                        {
                            FileInfo[] fiArr3 = diArr3[0].GetFiles("pvri*");
                            name = fiArr3[0].Name;
                            sourcePath = diArr3[0].FullName;
                            fileCount++;
                        }

                        File.AppendAllText(@"C:\A\test.txt", lineCount + "    " + fileCount + Environment.NewLine);

                        try
                        {
                            string startFile = sourcePath + "\\" + name;
                            string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                            Directory.CreateDirectory("c:\\a\\b\\" + fab);
                            File.Copy(startFile, endFile, true);
                        }
                        catch (IOException ioex)
                        {
                            MessageBox.Show(ioex.ToString());
                        }

                        DirectoryInfo di4 = new DirectoryInfo(SNdirectory);
                        DirectoryInfo[] diDir4 = di4.GetDirectories(fab);

                        FileInfo[] fiSN = diDir4[0].GetFiles("*.dat");
                        sourcePath = diDir4[0].FullName;
                        int ii = 0;
                        while (ii < fiSN.Length)
                        {
                            name = fiSN[ii].Name;
                            string startFile = sourcePath + "\\" + name;
                            string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                            File.Copy(startFile, endFile, true);
                            fileCount++;
                            ii++;
                        }

                        FileInfo[] fiNCMR = diDir4[0].GetFiles("*NCMR*");
                        sourcePath = diDir4[0].FullName;
                        ii = 0;
                        while (ii < fiNCMR.Length)
                        {
                            name = fiNCMR[ii].Name;
                            string startFile = sourcePath + "\\" + name;
                            string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                            File.Copy(startFile, endFile, true);
                            fileCount++;
                            ii++;
                        }


                        if (diDir4.Length > 0)
                        {
                            DirectoryInfo[] diNewView = diDir4[0].GetDirectories("New View Data");
                            DirectoryInfo[] diS1 = diDir4[0].GetDirectories("S1*");
                            DirectoryInfo[] diS2 = diDir4[0].GetDirectories("S2*");
                            DirectoryInfo[] diNCMR = diDir4[0].GetDirectories("NCMR");
                            
                            if (diNewView.Length > 0)
                            {
                                DirectoryInfo[] subS = diNewView[0].GetDirectories();
                                FileInfo[] fS1 = subS[0].GetFiles("*.dat");
                                sourcePath = subS[0].FullName;
                                int j = 0;
                                
                                while (j < fS1.Length)
                                {
                                    name = fS1[j].Name;
                                    string startFile = sourcePath + "\\" + name;
                                    string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                                    File.Copy(startFile, endFile, true);
                                    fileCount++;
                                    j++;
                                }

                                FileInfo[] fS2 = subS[1].GetFiles("*.dat");
                                sourcePath = subS[1].FullName;
                                j = 0;

                                while (j < fS2.Length)
                                {
                                    name = fS2[j].Name;
                                    string startFile = sourcePath + "\\" + name;
                                    string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                                    File.Copy(startFile, endFile, true);
                                    fileCount++;
                                    j++;
                                }


                            }
                            if (diS1.Length > 0)
                            {
                                FileInfo[] fiS1 = diS1[0].GetFiles("*.dat");
                                sourcePath = diS1[0].FullName;
                                int i = 0;
                                while (i< fiS1.Length)
                                {
                                name = fiS1[i].Name;
                                string startFile = sourcePath + "\\" + name;
                                string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                                File.Copy(startFile, endFile, true);
                                fileCount++;
                                i++;
                                }
                            }
                            if (diS2.Length > 0)
                            {
                                FileInfo[] fiS2 = diS2[0].GetFiles("*.dat");
                                sourcePath = diS2[0].FullName;
                                int i = 0;
                                while (i < fiS2.Length)
                                {
                                    name = fiS2[i].Name;
                                    string startFile = sourcePath + "\\" + name;
                                    string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                                    File.Copy(startFile, endFile, true);
                                    fileCount++;
                                    i++;
                                }
                            }
                            if (diNCMR.Length > 0)
                            {
                                FileInfo[] fiNCMR1 = diNCMR[0].GetFiles("*ncmr*");
                                sourcePath = diNCMR[0].FullName;
                                int i = 0;
                                while (i < fiNCMR1.Length)
                                {
                                    name = fiNCMR1[i].Name;
                                    string startFile = sourcePath + "\\" + name;
                                    string endFile = "c:\\a\\b\\" + fab + "\\" + name;
                                    File.Copy(startFile, endFile, true);
                                    fileCount++;
                                    i++;
                                }

                            }
                            File.AppendAllText(@"C:\A\test.txt", lineCount + "    " + fileCount + Environment.NewLine);
                        }

                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}