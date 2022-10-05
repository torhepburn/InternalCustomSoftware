using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DemoLab
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
            Application.Run(new F5_Users());
        }
    }

    public static class g
    {
        public static string db = "server = midsql01; password = Read+Write!; " +
                                  "user = readwrite; database = demolab;";
    }
}
