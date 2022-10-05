using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CEA_Monthly_Report_Amp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AmpSlabs());
        }
    }
}