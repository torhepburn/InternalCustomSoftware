using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace LicenseDllTest
{
	public static class MetroProXLicense
	{
		[DllImport("MetroproXLicense.dll", CharSet=CharSet.Ansi)]
		[return: MarshalAs(UnmanagedType.BStr)]
		private static extern string GenerateMetroproLicenseKey(
			[MarshalAs(UnmanagedType.LPStr)] string MachineIdName,
			[MarshalAs(UnmanagedType.LPStr)] string OptionName,
			[MarshalAs(UnmanagedType.LPStr)] string StartDate,
			[MarshalAs(UnmanagedType.LPStr)] string EndDate);

		public static string GenerateMetroproLicenseKey(string hardwareId, string optionName, DateTime start, DateTime end)
		{
			return GenerateMetroproLicenseKey(
				hardwareId,
				optionName,
				start.ToString("MM/dd/yyyy").ToUpper(),
				end.ToString("MM/dd/yyyy").ToUpper());
		}
	}
}
