using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaintainSchedules
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
            Application.Run(new f1_SelectJob());
            //Application.Run(new MaintainSchedules());
        }
    }
}
