using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Certs
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
            Application.Run(new F1_MainMenu());
            //Application.Run(new TESTForm325B());
            //Application.Run(new F0281_03_Page_2());
            //Application.Run(new SelectCert());
            //Application.Run(new _00_What());
        }
    }
}
