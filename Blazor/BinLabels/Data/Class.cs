using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace FindPrinter.Data
{
    public class PrinterFinder
    {
        //SqlConnection cnxn = new SqlConnection(db);
        //SqlDataAdapter da;
        //DataTable table;



        //    System.Security.Principal.WindowsIdentity userBase;
        //    userBase = System.Security.Principal.WindowsIdentity.GetCurrent();

        //    string user = userBase.Name.ToUpper(); ;

        //    if (userBase.Name.IndexOf("Z") == 0)
        //    {
        //        user = userBase.Name.Replace("ZYGOMIS\\", "");
        //    }
        //    else
        //    {
        //        user = userBase.Name.Replace("AMETEK-AD\\", "");
        //    }

        //    string computername = Environment.MachineName;

        //    SqlConnection cnxn = new SqlConnection(g.db);

        //    try
        //    {
        //        da = new SqlDataAdapter(
        //         " Select permission, permissionvalue from applicationsetup " +
        //         " where application = 'shippinglabel' and " +
        //         " pcid = '" + computername + "' and " +
        //         " username = '" + user + "' order by permission desc ", cnxn);
        //        table = new DataTable();
        //        da.Fill(table);

        //        if (table.Rows.Count > 0)
        //        {
        //            /*  putting print server into table on CT-MID-SQL11  */
        //            //g.printer = "\\\\midprtsrv\\" + table.Rows[0][1].ToString().Trim();
        //            g.printer = table.Rows[0][1].ToString().Trim();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Either this user " + user + " or this computer (" + computername + ") does not have permission to use this program.");
        //            this.Close();
        //        }

        //        if (table.Rows.Count == 2 && table.Rows[1][1].ToString().Trim() == "YES")
        //        {
        //            g.editRevision = "YES";
        //        }


        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {

        //    }

    }

}
