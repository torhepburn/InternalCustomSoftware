using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace CalibrationManager
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

            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper(); ;

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            
            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter
                ("Select usertype, facility from accessrights " +
                 " where userlogon = '" + user + "'", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            g.userType = table.Rows[0].ItemArray[0].ToString().Trim();
            g.facility = table.Rows[0].ItemArray[1].ToString().Trim();

            if (g.userType.ToUpper() == "FULL" | g.userType.ToUpper() == "VIEW+DATA" | g.userType.ToUpper() == "LIMITED")
            {
                Application.Run(new f00_Start());
            }
            else if (g.userType.ToUpper() == "SYSTEM" | g.userType.ToUpper() == "SYSTEMAC")
            {
                Application.Run(new Entrance());

            }
            else
            {
                Application.Run(new LogOn());
            }
            /*
            Application.Run(new Special_BarcodeLabels());
            */
        }
    }
}