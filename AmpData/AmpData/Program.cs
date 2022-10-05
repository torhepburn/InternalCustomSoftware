using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace AmpData
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
                "Select usertype from NIFaccessrights " +
                 " where userlogon = '" + entrant + "'", cnxn);
            cnxn.Open();

            object o = cmd.ExecuteScalar();
            
            cnxn.Close();
            
            if (o != null)
            {
                SqlDataAdapter da = new SqlDataAdapter
                ("Select usertype from NIFaccessrights " +
                 " where userlogon = '" + entrant + "'", cnxn);
                DataTable table = new DataTable();
                da.Fill(table);

                g.userType = table.Rows[0].ItemArray[0].ToString().Trim();
            
            }
            
            if (g.userType == "full")
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

