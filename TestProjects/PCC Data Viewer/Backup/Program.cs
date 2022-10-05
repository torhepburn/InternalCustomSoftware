using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PCC_Data_Viewer
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
            Application.Run(new f1_Select_Boards());
        }
    }
}