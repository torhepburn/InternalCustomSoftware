using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TnH
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
            Application.Run(new ViewReadings());
            //Application.Run(new View_Readings_CM());
        }
    }
}