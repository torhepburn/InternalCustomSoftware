using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace T2Lib
{
    public class Class1
    {
        public static string T2a()
        {
            //string xtract = @"\\zygocorp\manufacturing\softwaredistribution\xtracted.txt";
            //File.WriteAllText(xtract, "This test works " + DateTime.Now.ToString());

            string xtra = @"C:\A\xtracted.txt";
            File.WriteAllText(xtra, "This text works " + DateTime.Now.ToString());

            return "This test works. " + DateTime.Now.ToString();
        }
    }
}
