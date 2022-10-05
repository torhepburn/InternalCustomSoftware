using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LicenseDllTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(MetroProXLicense.GenerateMetroproLicenseKey("1234", "MetroProX5.3.2", DateTime.Now, DateTime.Now.AddMonths(3)));
		}
	}
}
