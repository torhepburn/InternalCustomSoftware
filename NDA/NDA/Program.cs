using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace NDA
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
                ("Select usertype, name  from accessrights " +
                 " where userlogon = '" + user + "'", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            g.userType = table.Rows[0].ItemArray[0].ToString().Trim();
            g.user = table.Rows[0].ItemArray[1].ToString().Trim();

            if (g.userType.ToUpper() == "ADMIN")
            {
                Application.Run(new SelectNDA());
            }
            else if(g.userType.ToUpper() == "PROCUREMENT")
            {
                Application.Run(new ProcurementChoices());
            }
            else
            {
                MessageBox.Show("You do not have permission to use this program.");
            }


        }
    }
}
