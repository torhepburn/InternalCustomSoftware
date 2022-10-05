using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace RMAX_TAB_A
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

            System.Security.Principal.WindowsIdentity user;
            user = System.Security.Principal.WindowsIdentity.GetCurrent();

            string entrant = user.Name.Replace("ZYGOMIS\\", "");

            SqlConnection cnxn = new SqlConnection(g.db);

            SqlCommand cmd = new SqlCommand(
                "Select permissionvalue from ApplicationSetup " +
                 " where username = '" + entrant + "' " +
                 " and application = 'RMAX_MIRROR_TAB_A' " + 
                 " and permission = 'usertype' ", cnxn);
            cnxn.Open();

            object o = cmd.ExecuteScalar();

            cnxn.Close();

            string userType = "";

            if (o != null)
            {
                SqlDataAdapter da = new SqlDataAdapter
                ("Select permissionvalue from ApplicationSetup " +
                 " where username = '" + entrant + "' " +
                 " and application = 'RMAX_MIRROR_TAB_A' " +
                 " and permission = 'usertype' ", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);

                //g.userType = table.Rows[0][0].ToString().Trim();
                userType = table.Rows[0][0].ToString().Trim();
            }

            if (userType.ToUpper() == "FULL")
            {
                Application.Run(new F0_Admin());
            }
            else
            {
                Application.Run(new F1_SelectSerialNumber());
            }
        }
    }
}
