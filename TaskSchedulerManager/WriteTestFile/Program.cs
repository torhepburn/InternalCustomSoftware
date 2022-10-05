using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WriteTestFile
{
    class Program
    {
        static void Main(string[] args)
        {
            File.AppendAllText("C:\\TEMP\\testfile.txt", DateTime.Now.ToString()
                + " Here is the local C test text." + Environment.NewLine);

            //File.AppendAllText(@"\\MIDSQL01\c$\TEMP\testfile.txt", DateTime.Now.ToString()
            //    File.AppendAllText(@"\\MIDHYP-ess\c$\TEMP\testfile.txt", DateTime.Now.ToString()
            //+ " Here is the test text." + Environment.NewLine);
        }
    }
}
