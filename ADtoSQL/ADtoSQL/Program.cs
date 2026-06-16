using Markdig.Renderers.Html;
using System.Management.Automation;
using System.Runtime.ExceptionServices;
using System.Xml.Linq;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using Microsoft.Data.SqlClient;
using System.Drawing.Text;
using System.Web.Services.Description;

SqlCommand cmd;
SqlConnection cnxnNAV;
SqlConnection cnxn;
SqlDataReader dr;


string groupUserName;
string groupFullName;


try
{
    /* first get the active AD groups from the NAV tables */

    cnxnNAV = new SqlConnection("server=pa-hor-as408.ametek.com; user = navdb_read; password = 2018#ameteK; encrypt=false; ");

    cnxnNAV.Open();

    cmd = new SqlCommand(
        "select " +
        "REPLACE([User Name], 'AMETEK-AD\\','') UserName " +
        ", [Full Name] " +
        "from[User] " +
        "WHERE[User Name] like '%-GG-%' " +
        "AND[User Name] NOT LIKE '%BROOK%' " +
        "AND[User Name] NOT LIKE '%RICH%' " +
        "AND [State] = 0", cnxnNAV);

    dr = cmd.ExecuteReader();

    /*  then use power shell to get the member names of the AD groups    */

    while (dr.Read())
    {
        groupUserName = dr.GetString(0).Trim();
        groupFullName = dr.GetString(1).Trim();

        using (PowerShell ps = PowerShell.Create())
        {
            ps.AddCommand("Get-ADGroupMember");
            ps.AddParameter("-Identity", groupUserName);

            var results = ps.Invoke();

            foreach (var result in results)
            {
                string user;
                string name = result.BaseObject.ToString();

                /*  some employees stay in the table for a period of time labeled as Disabled even if they have left the company   */

                if (name.IndexOf("Disabled")==-1)
                {
                    user = name.Substring(3, (name.IndexOf(",") - 3));
                }
                else
                {
                    user = name.Substring(3, (name.IndexOf(",") - 3)) + " : Disabled";
                }

                /*  put the user data into a table where it can be worked on   */

                cnxn = new SqlConnection("server =ct-mid-sql11.ametek.com; user = readWrite; password = Read+Write!; encrypt=false; ");

                try
                {
                    cnxn.Open();

                    cmd = new SqlCommand("Insert into [AccessFrontEnds].[dbo].[NAV_User_Group_Mapping] " +
                                         "(" +
                                         " GroupName " +
                                         ",GroupFullName " +
                                         ",[User]" +
                                         ") values ('" +
                                           groupUserName +
                                          "','" + groupFullName +
                                            "','" + user + "')", cnxn);
                                                            

                    int nn = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
                finally
                {
                    cnxn.Close();
                }
            }
        }
    }
}
catch (SqlException ex)
{
    Console.Error.WriteLine(ex.Message);
}
finally
{
    //cnxnNAV.Close();
    Environment.Exit(1);
}


/*


*/




