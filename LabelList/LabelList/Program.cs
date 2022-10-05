using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LabelList
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

            //System.Windows.Forms.Application.EnableVisualStyles();
            //System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            //System.Security.Principal.WindowsIdentity user;
            //user = System.Security.Principal.WindowsIdentity.GetCurrent();

            //string entrant = user.Name.Replace("ZYGOMIS\\", "");

            

            //SqlConnection cnxn = new SqlConnection(g.db);

            //try
            //{
            //    SqlDataAdapter da = new SqlDataAdapter
            //    ("Select printer, type  from labelsusersetup " +
            //     " where userlogon = '" + entrant + "'", cnxn);
            //    System.Data.DataTable tableA = new System.Data.DataTable();
            //    da.Fill(tableA);

            //    //if blank error will ensue

            //    g.printer = tableA.Rows[0].ItemArray[0].ToString().Trim();
            //    g.printertype = tableA.Rows[0].ItemArray[1].ToString().Trim();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
                        
            Application.Run(new PackinglistLabels());

            
        }
    }
}
