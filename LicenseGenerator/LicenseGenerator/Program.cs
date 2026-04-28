using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace LicenseGenerator
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



            SqlConnection cnxn = new SqlConnection(g.dbAFE);

            try
            {
                SqlCommand cmd = new SqlCommand(
                 " Select permission, permissionvalue from applicationsetup " +
                 " where application = 'LicenseGenerator.exe' and " +
//                 " where application = 'LicenseManager.exe' and " +
                 " userName = '" + user + "' " +
                 " order by permission desc ", cnxn);
                DataTable table = new DataTable();

                cnxn.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();
                table.Load(dr);


                if (table.Rows.Count > 0)
                {

                    if (table.Rows[0][0].ToString().Trim().ToUpper() == "QUALITY" & table.Rows[0][1].ToString().Trim().ToUpper() == "TRUE")
                    {
                        g.role = "QC";
                        g.productLine = "MX";
                        g.activeDemo = "A";
                        g.task = "Change SO";
                        Application.Run(new f7ViewDetails());
                    }
                    else if (table.Rows[0][0].ToString().Trim().ToUpper() == "TAIWAN" & table.Rows[0][1].ToString().Trim().ToUpper() == "TRUE")
                    {
                        g.role = "TAIWAN";
                        g.productLine = "MX";
                        g.activeDemo = "A";
                        Application.Run(new f5Assembly());
                    }
                    else
                    {
                        Application.Run(new f1SelectProduct());
                    }
                }
                else
                {
                    Application.Run(new f1SelectProduct());
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cnxn.Close();
            }
            
           // Application.Run(new F62_SoftwareAgreement()); 
            //Application.Run(new Test());
        }
    }
}