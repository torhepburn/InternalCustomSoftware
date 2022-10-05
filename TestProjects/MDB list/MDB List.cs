using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MDB_list
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"c:\a\manufacturing filelist 9-26-11.txt");
            foreach (string line in lines)
            {
                int start = line.LastIndexOf(@"\");

                int end = line.LastIndexOf("mdb", StringComparison.InvariantCultureIgnoreCase);
                
                //if (end == -1) end = line.LastIndexOf("MDB");
                string number = line.Substring((end + 5), (line.Length - (end + 5)));
                string db = line.Substring((start + 1), ((end + 2) - start));
                string path = line.Substring(0, start + 1);
                File.AppendAllText(@"c:\a\access.txt", number + "," + db + "," + path + Environment.NewLine);
            }

        }
    }
}