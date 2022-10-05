using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Get_Date_for_PCC
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
            //Application.Run(new fGetDate());
            Application.Run(new Null_out_Zeros());
        }
    }
}