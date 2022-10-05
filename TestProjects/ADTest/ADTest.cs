using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using Microsoft.Data.SqlClient;

namespace ADTest
{
    public partial class ADTest : Form
    {
        public ADTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string DomainPath = "LDAP://OU=ct-mid,DC=AMETEK,DC=COM";
            //string DomainPath = "LDAP://OU=ca-ric,DC=AMETEK,DC=COM";
            //string DomainPath = "LDAP://OU=ca-cos-zyg,DC=AMETEK,DC=COM";
            DirectoryEntry searchRoot = new DirectoryEntry(DomainPath);
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            //search.Filter = "(&(objectClass=user)(objectCategory=person))";
            search.Filter = "(&(objectClass=user)(objectCategory=person)(employeeID=*))";
            //search.Filter = "(&(objectClass=organizationalUnit)(name=ct-mid))";
            search.PropertiesToLoad.Add("samaccountname");
            search.PropertiesToLoad.Add("EmployeeID");
            search.PropertiesToLoad.Add("Mail");
            search.PropertiesToLoad.Add("SN");
            search.PropertiesToLoad.Add("GivenName");
                        
            SearchResult result;

            SearchResultCollection resultCol = search.FindAll();

            string hhh = string.Empty;

            

            if (resultCol != null)
            {
                for (int counter = 0; counter < resultCol.Count; counter++)
                {
                    result = resultCol[counter];
                    string k = string.Empty;

                    if (result.Properties.Contains("samaccountname") 
                        & result.Properties.Contains("EmployeeID")
                        & result.Properties.Contains("SN")
                        & result.Properties.Contains("GivenName")
                        & result.Properties.Contains("Mail"))
                    {
                        //SqlParameter 

                        SqlCommand cmd = new SqlCommand();
                        string h = (String)result.Properties["samaccountname"][0];
                        string j = (String)result.Properties["SN"][0];
                        //if ((String)result.Properties["Mail"][0] is null)
                        //{ k = ""; }
                        //else
                         k = (String)result.Properties["Mail"][0]; 
                        //string l = (String)result.Properties["samaccountname"][0];
                        hhh += h + " " + j + " " +  k + Environment.NewLine;
                    }
                }
            }

            

            //LDAP
            //Entry As DirectoryEntry = Nothing
            //Dim dSearch As DirectorySearcher = Nothing
            //Dim sResultSet As SearchResult = Nothing
            //Dim username1 As String = String.Empty
            //Dim pwd As String = String.Empty

            //Dim ad As AD = New AD()

            //Try
            //    'Get username/password to access AD
            //Dim bs As ADDomain = GetADDomainByName(ActiveDirectoryDomain)
            //username1 = bs.UserName
            //pwd = bs.Password

            //DirectoryEntry dEntry = new DirectoryEntry("LDAP://AMETEK.COM,thepburn,Mynewpa$$w0rd");

            ////= New DirectoryEntry("LDAP://" & ActiveDirectoryDomain, username1, pwd)

            //DirectorySearcher dSearch = new DirectorySearcher(dEntry);

            //using (var root = new DirectoryEntry("LDAP://AMETEK.COM"))
            //{
            //    using (var searcher = new DirectorySearcher(root))
            //    {
            //        // looking for a specific user
            //        searcher.Filter = $"(&(objectCategory=person)(objectClass=user)(sAMAccountName=thepburn))";
            //        // I only care about what groups the user is a memberOf
            //        searcher.PropertiesToLoad.Add("memberOf");

            //        // FYI, non-null results means the user was found
            //        var results = searcher.FindOne();

            //        var resultsA = searcher.FindAll();

            //        var properties = results?.Properties;

            //        if (properties?.Contains("memberOf") == true)
            //        {
            //            // ... iterate over all the groups the user is a member of
            //        }


            //    }

            //    //using (var searcher = new PrincipalSearcher(new UserPrincipal(new PrincipalContext(ContextType.Domain, Environment.UserDomainName))))
            //    //{
            //    //    List<UserPrincipal> users = searcher.FindAll().Select(u => (UserPrincipal)u).ToList();
            //    //    foreach (var u in users)
            //    //    {
            //    //        DirectoryEntry d = (DirectoryEntry)u.GetUnderlyingObject();
            //    //        Console.WriteLine(d.Properties["GivenName"]?.Value?.ToString() + d.Properties["sn"]?.Value?.ToString());
            //    //    }
            //    //}
            //}

            //DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://" + Environment.MachineName);
            //string userNames = "Users: ";

            //foreach (DirectoryEntry child in directoryEntry.Children)
            //{
            //    if (child.SchemaClassName == "User")
            //    {
            //        userNames += child.Name + Environment.NewLine;
            //    }

            //}
            //MessageBox.Show(userNames);



        }
    }
}
