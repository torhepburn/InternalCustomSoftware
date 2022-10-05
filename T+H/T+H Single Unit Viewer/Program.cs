using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace T_H_Single_Unit_Viewer
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
            //Application.Run(new UnitViewer());
            Application.Run(new TucsonTest());
        }
    }
}