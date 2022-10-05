using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSearch
{
    public partial class Form1 : Form
    {
        private string[] DesiredDirectory = new string[5];
        private string[] Sfolders = new string[325];
        private bool skip = false;

        private string sN;
        private string sNpath;
        private string[] files = new string[10];
        private int counter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProcessDirectory(@"\\zygocorp\projects");
            
            //DesiredDirectory[0] = @"\\zygocorp\projects";



            //string[] strArray0 = Directory.GetDirectories(DesiredDirectory[0]);
            //string[] strArray0 = Directory.GetDirectories(@"\\zygocorp\projects");
            //string[] strArray0 = Directory.GetDirectories(DesiredDirectory[0], "15-0689");
            //string[] strArray2 = Directory.GetDirectories(DesiredDirectory[2], "??-????");
            //string[] strArray3 = Directory.GetDirectories(DesiredDirectory[3], "??-????");
            //string[] strArray4 = Directory.GetDirectories(DesiredDirectory[4], "??-????");

            // sourceArray, destinationArray, length
            //Array.Copy(strArray0, Sfolders, strArray0.Length + 100);
            //  sourceArray, sourceIndex, destinationArray, destinationIndex, length
            //Array.Copy(strArray1, 0, Sfolders, strArray0.Length, strArray1.Length);
            //Array.Copy(strArray2, 0, Sfolders, strArray0.Length + strArray1.Length, strArray2.Length);
            //Array.Copy(strArray3, 0, Sfolders, strArray0.Length + strArray1.Length + strArray2.Length, strArray3.Length);
            //Array.Copy(strArray4, 0, Sfolders, strArray0.Length + strArray1.Length + strArray2.Length + strArray3.Length, strArray4.Length);





            //            foreach (string sn in Sfolders)
            //foreach (string sn in strArray0)
            //{
            //    if (sn != null)
            //    {
            //        sNpath = sn;
                    

            //        //if (sN == "02-0131" | sN == "02-0130" | sN == "02-0129" | sN == "02-0124")
            //        //| sN == "09-0709" | sN == "09-0704-NEW" )
                    
                    
            //            files = Directory.GetFiles(sNpath, "*DynaFiz*");
                        
            //            if (files.Length == 0)
            //            {
            //                string[] downOneLevel = Directory.GetDirectories(sNpath);

            //                if (downOneLevel.Length > 0)
            //                {
            //                    files = Directory.GetFiles(downOneLevel[0], "*DynaFiz*");
            //                }
            //            }

            //            if (files.Length != 0)
            //            {

            //            for (int i = 0; i< files.Length; i++)
            //            {
            //                File.AppendAllText(@"C:\A\Dsearch.txt", files[i].ToString() + Environment.NewLine);
            //            }
                        

                         
            //                // I don't know why I put in these if clauses as they don't do anything.
            //                //System.Threading.Thread.Sleep(5000);
                         
            //            }
                    
            //    }   //end is sn null loop
            //}   // end foreach loop
            //Close();
        }

        public void ProcessDirectory(string targetDirectory)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*DynaFiz*");
            foreach(string filename in fileEntries)
            {
                File.AppendAllText(@"C:\A\Filesearch.txt", filename + Environment.NewLine);
            }

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);

            foreach (string subdirectory in subdirectoryEntries)
            {
                
                ProcessDirectory(subdirectory);
            }
                   
        }
    }
}