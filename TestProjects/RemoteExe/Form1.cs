using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management.Instrumentation;
using System.Management;

namespace RemoteExe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object[] PTR = { "calibrationmanager.exe" };
            ConnectionOptions cnxn = new ConnectionOptions();
            cnxn.Username = "";
            cnxn.Password = "";
            ManagementScope scope = new ManagementScope(@"\\midws0154\root\cimv2", cnxn);
            scope.Connect();
            ManagementObjectSearcher searcher;
            ManagementClass theclass = new ManagementClass
                (scope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
            theclass.InvokeMethod("Create", PTR);

        }
    }
}