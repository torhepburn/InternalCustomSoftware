using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aLibComments
{
    public class CommentManager
    {
        
        public static int Input(int ShortageID)
        {
            g.ShortageLocator = ShortageID;

            dllForm f1 = new dllForm();
            f1.ShowDialog();

            return 10;
        }
    }

    public static class g
    {
        //public static string tbSearchCustomer;
        //public static string tbSearchProject;
        //public static string tbSearchElement;
        //public static string tbSearchPlanner;
        public static string itemCode;
        public static int ShortageLocator;
        //public static string element;
        public static string db = "server = CT-MID-SQL01; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds;";
        //public static string basicselect = "select " +
        //        "PlannerInitials as Planner, " +
        //        "from PlannerCurrentStatus ";
        //public static string basicsort = "order by planner, customer, " +
        //    "project, elementname, dbo.sc_sortableversionstring(partsn)";

        //public static string basicsort = "order by planner, deptcode, " +
        //    "project, elementname, dbo.sc_sortableversionstring(partsn)";


    }
}
