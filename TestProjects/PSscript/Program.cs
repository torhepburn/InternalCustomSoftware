using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace PSscript
{
    class Program
    {
        static void Main(string[] args)
        {
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                //need using block because PowerShell class implements IDisposable

                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript("param($param1) $d = get-date; $s = 'test string value'; " +
                        "$d; $s; $param1; get-service");

                //PowerShellInstance.AddScript("$text = 'hello test string value'; " +
                  //  "$text | add-content c:\a\testB.txt");

                // use "AddParameter" to add a single parameter to the last command/script on the pipeline.
                //PowerShellInstance.AddParameter("param1", "parameter 1 value!");

                // invoke execution on the pipeline (ignore output)
                //PowerShellInstance.Invoke();

                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                // loop through each output object item
                foreach (PSObject outputItem in PSOutput)
                {
                    // if null object was dumped to the pipeline during the script then a null
                    // object may be present here. check for null to prevent potential NRE.
                    if (outputItem != null)
                    {
                        //TODO: do something with the output item 
                        // outputItem.BaseOBject
                        //TODO: do something with the output item 
                        Console.WriteLine(outputItem.BaseObject.GetType().FullName);
                        Console.WriteLine(outputItem.BaseObject.ToString() + "\n");
                    }
                }

            }
        }
    }
}
