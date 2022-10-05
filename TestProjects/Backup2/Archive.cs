using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace CEA_Archive
{
    public partial class Archive : Form
    {
        private string[] folders;
        private int chosen;
        private string path = @"\\zygocorp\manufacturing\nif\" +
                @"qc inspection reports\cea";
        private string archiveThis;
        private string f1;
        private string f2;
 
        public Archive()
        {
            InitializeComponent();
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            bArchive.Hide();

            folderList(path);
        }

        private void LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosen = LB.SelectedIndex;

            bArchive.Visible = true;
            bArchive.Text = "Archive " +
                folders[chosen].Substring(folders[chosen].LastIndexOf(@"\") + 1);
            archiveThis = folders[chosen];

            folderList(archiveThis);
        }

        private void bArchive_Click(object sender, EventArgs e)
        {
            if (archiveThis.Substring(archiveThis.LastIndexOf(@"\") + 1).Length == 7)
            {
                // winzip doesn't like "\\" in path so use C# to get to the right folder
                // prior to starting 
                Directory.SetCurrentDirectory(archiveThis);

                // give the the zip file a name
                string zippedFolder = archiveThis.Substring(archiveThis.LastIndexOf(@"\") + 1);
                string zippedfile = zippedFolder + "_v01.zip";

                // create the ZYGO zip file in the current folder using wzzip.  Save the folder 
                // structure, go into sub folders, delete the files and sub folders after 
                // zipping.
                Process p = new Process();
                p.StartInfo.FileName = @"c:\program files\winzip\wzzip.exe";
                p.StartInfo.Arguments = @" -P -r -m ZYGO_" + zippedfile + " *.*";
                p.Start();
                p.WaitForExit();
                p.Dispose();

                // use unzip to create flat file structure and filter out unwanted files
                // unzip to c:\ceaarchive - convenient temp location
                p = new Process();
                p.StartInfo.FileName = @"c:\program files\winzip\wzunzip.exe";
                p.StartInfo.Arguments = @" -o- -x*.txt -x*.grd -x*.jpg -x*.dsp -x*.mat " +
                "ZYGO_" + zippedfile + @" c:\CEAarchive";
                p.Start();
                p.WaitForExit();
                p.Dispose();

                Directory.SetCurrentDirectory(@"C:\CEAarchive");

                //get rid of all pdfs except for FAST and NCMR
                string[] files = Directory.GetFiles(@"c:\ceaarchive\", "*.pdf");
                foreach (string file in files)
                {
                    if (file.Substring(14, 4) != "NCMR" & file.Substring(14, 4) != "FAST")
                    {
                        File.Delete(file);
                    }
                }
                // create CEA_RCI zip file
                p = new Process();
                p.StartInfo.FileName = @"c:\program files\winzip\wzzip.exe";
                p.StartInfo.Arguments = @" -x*.zip -m CEA_RCI_" + zippedfile + " *.*";
                p.Start();
                p.WaitForExit();
                p.Dispose();

                string zFrom = archiveThis + @"\ZYGO_" + zippedfile;

                // create pn folder in archive under parent directory
                string parent = archiveThis.Remove(archiveThis.LastIndexOf(@"\"));
                if (!Directory.Exists(parent + @"\Archive\" + zippedFolder));
                {
                    Directory.CreateDirectory(parent + @"\Archive\" + zippedFolder);
                }
                // move zipped Zygo file to pn archive folder
                string Zto = parent + @"\Archive\" + zippedFolder + @"\ZYGO_" + zippedfile;
                File.Move(zFrom, Zto);
                // delete original pn folder
                Directory.Delete(archiveThis, true);

                // move CEA_RCI zipped file to pn archive
                string cFrom = "C:\\CEAarchive\\CEA_RCI_" + zippedfile;
                string Cto = parent + @"\Archive\" + zippedFolder + @"\CEA_RCI_" + zippedfile;
                File.Move(cFrom,Cto);

                folderList(archiveThis.Remove(archiveThis.LastIndexOf(@"\")));
            }
            else
            {
                MessageBox.Show("Can only archive data folders of the XX-XXXX format.");
                return;
            }

            bArchive.Visible = false;
        }
        
        private void bBack_Click(object sender, EventArgs e)
        {
            folderList(path);

            bArchive.Text = "Archive";
            bArchive.Hide();
        }

        private void folderList(string select)
        {
            LB.Items.Clear();
            
            folders = Directory.GetDirectories(select);
            // zero based array
            int qtyFolders = folders.Length;

            for (int i = 0; i < qtyFolders; i++)
            {
                LB.Items.Add(folders[i].Substring(folders[i].LastIndexOf(@"\") + 1));
                // add items to list box
            }
        }
    }
}