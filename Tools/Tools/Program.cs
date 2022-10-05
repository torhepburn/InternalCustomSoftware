using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Tools
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Application.Run(new F01_Setup_Sheet());
            //Application.Run(new F44_Copy_Setup_Machine2Machine());
            //Application.Run(new F42_Edit_Setup_Sheet_Tools());
            //Application.Run(new F40_Add_Tool_SN());
            //Application.Run(new F0_Choose_Type());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            System.Security.Principal.WindowsIdentity userBase;
            userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

            string user = userBase.Name.ToUpper();

            if (userBase.Name.IndexOf("Z") == 0)
            {
                user = userBase.Name.Replace("ZYGOMIS\\", "");
            }
            else
            {
                user = userBase.Name.Replace("AMETEK-AD\\", "");
            }

            /*  accessrights is on ct-mid-sql11.Optics    */

            SqlConnection cnxn = new SqlConnection(g.db);

            SqlDataAdapter da = new SqlDataAdapter
                ("Select usertype, facility, program from accessrights " +
                 " where userlogon = '" + user + "'", cnxn);

            DataTable table = new DataTable();
            da.Fill(table);

            if (user == "LFOCNC")
            {
                g.program = "LFO";
                g.facility = "zams";
            }

            if (user == "OPTCNC")
            {
                g.program = "OPT";
                g.facility = "zams";
            }

            if (table.Rows.Count > 0)
            {
                g.userType = table.Rows[0].ItemArray[0].ToString().Trim();
                g.facility = table.Rows[0].ItemArray[1].ToString().Trim(); ;
                g.program = table.Rows[0].ItemArray[2].ToString().Trim(); ;

                if (g.userType == "full" | (g.userType == "facility" && g.facility != "zams"))
                {
                    Application.Run(new F1_Start());
                }
                else if (g.userType == "facility" && g.facility == "zams")
                {
                    Application.Run(new F0_Choose_Type());
                    //Application.Run(new A2());
                }
                else
                {
                    Application.Run(new F31_Find_Tools());

                }
            }
            else
            {
                //if the user has no rights
                g.program = "CNC";
                Application.Run(new F31_Find_Tools());
            }
        }


    }
}