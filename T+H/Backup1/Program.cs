using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _14_Viewer
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
            //Application.Run(new DataViewer214());
            Application.Run(new Bacon_Viewer());
        }
    }
}