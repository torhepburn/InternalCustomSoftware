using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace ReformatAccessQuery
{
    public partial class ReformatQuery : Form
    {
        public ReformatQuery()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File.WriteAllText(@"c:\a\2.txt", "");

            StreamReader sr = new StreamReader("c:\\a\\1.txt");

            while (sr.Peek() >= 0)
            {
                string x = sr.ReadLine();

                x = x.Replace(",", "," + Environment.NewLine);

                File.AppendAllText(@"c:\a\2.txt", x);
            }
                        
            Process.Start("notepad.exe",@"c:\a\2.txt");

            sr.Close();

            File.WriteAllText(@"c:\a\1.txt", "");

        }
    }
}
