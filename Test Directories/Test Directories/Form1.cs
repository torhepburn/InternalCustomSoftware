using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test_Directories
{
    public partial class Form1 : Form
    {
        //private string look = @"\\zygocorp\departments\quality";
        private string look = @"\\midsql01";
        //private string look = @"\\zygocorp\departments\corpinfo";
        //private string look = @"\\oma-as1\shared\quality documents";
        //private string look = @"\\zygocorp\manufacturing";
        //private string look = @"\\zygocorp\manufacturing\nif" + 
          //  @"\qc inspection reports\cea\cea\archive";
        private int n = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string[] folders = Directory.GetDirectories(look);

            //foreach(string folder in folders)
            //{
            //    string[] empty = Directory.GetFiles(folder);

            //    foreach (string xx in empty)
            //    {
            //        FileInfo fi = new FileInfo(xx);
            //        string xy = fi.LastWriteTime.ToShortDateString();
            //        string xz = xx.Substring(59, (xx.Length - 59));
            //        if (fi.Exists == false)
            //        {
            //            File.AppendAllText("c:\\A\\s4 empty.txt", xz + 
            //                "     " + xy + Environment.NewLine);
            //        }
            //    }
            //}

            DirSearch(look);
        }

        private void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d, "*sqlservr.exe"))
                    //foreach (string f in Directory.GetFiles(d, "*.zip"))
                    {
                        FileInfo fi = new FileInfo(f);
                        string xy = fi.LastWriteTime.ToShortDateString();
                        File.AppendAllText(@"c:\a\SQL file list.txt", n + "  " + f +  "  " + xy + 
                            Environment.NewLine);
                        n++;
                    }
                    //File.AppendAllText(@"c:\a\filelist.txt", d +  "  " + n + Environment.NewLine);
                    
                    DirSearch(d);
                }
            }
            catch (System.Exception ec)
            {
                MessageBox.Show(ec.Message);
            }

        }
    }
}