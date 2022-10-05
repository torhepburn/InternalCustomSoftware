using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TnDunits
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
            //Application.Run(new HTML_Agility());
            //Application.Run(new XXHttpWebRequest());
            Application.Run(new A_webclient());
        }
    }
}
