using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WinZipApp
{
    public partial class WinZipApp : Form
    {
        public WinZipApp()
        {
            InitializeComponent();
        }

        private void WinZipApp_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(@"\\zygocorp\manufacturing\nif\qc inspection reports\cea\cea grating "+
                @"substrates\1 omega grating\05-0316");
            Process p = new Process();
            //p.StartInfo.FileName = @"c:\program files\winzip\wzzip.exe";
            p.StartInfo.FileName = @"c:\program files\winzip\wzunzip.exe";
            p.StartInfo.Arguments = @" -x*.txt -x*.grd -x*.jpg -x*.dsp -x*.mat " +
                @"05-0316_v01.zip c:\a\a";
            p.Start();
        }
    }
}