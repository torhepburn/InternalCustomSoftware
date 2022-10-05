using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PriceList
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
            Application.Run(new f1_Effective_Date());
            //Application.Run(new f6_Unwanted_Boxes());
        }
    }
}