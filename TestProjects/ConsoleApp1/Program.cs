using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SPSite site = new SPSite("http://localhost"))
            {
                using (SPWeb web = site.RootWeb)
                {
                    SPBasePermissions perms = SPBasePermissions.AddListItems
                                            | SPBasePermissions.ApproveItems
                                            | SPBasePermissions.CancelCheckout
                                            | SPBasePermissions.DeleteListItems
                                            | SPBasePermissions.DeleteVersions
                                            | SPBasePermissions.EditListItems
                                            | SPBasePermissions.Open
                                            | SPBasePermissions.OpenItems
                                            | SPBasePermissions.ViewListItems
                                            | SPBasePermissions.ViewVersions;


                    string listUrl = web.RootFolder.ServerRelativeUrl + "shared documents";
                    SPList list = web.GetList(listUrl);

                    // Be sure the current user has permission to check permissions.
                    if (web.DoesUserHavePermissions(SPBasePermissions.EnumeratePermissions))
                    {
                        foreach (SPGroup group in web.Groups)
                        {
                            foreach (SPUser user in group.Users)
                            {
                                // Check another user's permissions.
                                bool hasPermission = list.DoesUserHavePermissions(user, perms);
                                Console.WriteLine("{0, -5}  {1}", hasPermission, user.LoginName);
                            }
                        }
                    }
                }
            }
            Console.Write("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
}
