using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DashbaordFilterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String File2Process = File.ReadAllText(@"C:\A\AC.17510143.ZMI-4K-ITS.2018-3-17_02-58-28-PM_UTC.xml");

            int notOK = File2Process.IndexOf("ZMI 24", 0);

            if (notOK < 0)
            {

                string ready;
            }
        }
    }
}
