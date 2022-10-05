using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterScheduleCalcium
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
            //Application.Run(new MasterScheduleCalcium());
            Application.Run(new CalciumSingles());
            //Application.Run(new TEstForm1());
            //Application.Run(CustomerDates());
        }
    }
}
