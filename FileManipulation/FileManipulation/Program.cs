using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FileManipulation
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
            //Application.Run(new ProjectDataImport());
            //Application.Run(new PMdatabase());
            Application.Run(new MKLedger());
        }
    }
}