using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace ProcessTestPlatform
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo.FileName = "notepad.exe";
            //p.StartInfo.Arguments = "Notepad.exe";
            p.Start();
            p.WaitForExit(1000);
            if (p.HasExited == true)
            {
                    Console.WriteLine("Process exit code: {0}", p.ExitCode);
            }

            
            Console.WriteLine();
            

            Console.ReadLine();
        }
    }
}
