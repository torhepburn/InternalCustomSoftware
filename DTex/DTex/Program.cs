using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace DTex
{
    class Program
    {
        static Process p = new Process();

        static void Main(string[] args)
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.FileName = "dtexec";
            p.StartInfo.Arguments = @"/f ""\""c:\a_websites\mktitles.dtsx\"""" /de ""password"" /checkpointing DateTimeOffset /reporting ewcdi";

            p.Start();

        }
    }
}
