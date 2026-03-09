using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRP2026
{
    public partial class F0_SelectSource : Form
    {
        public F0_SelectSource()
        {
            InitializeComponent();
        }

        private void BProd_Click(object sender, EventArgs e)
        {
            g.server = "server=PA-HOR-AS408.ametek.com; password=2018#ameteK; " +
                            "user=navdb_read; database=ZYGO-NAV-PROD; encrypt=false;";
            g.rptName = g.buyer + "PROD ";
            Nexxt();
        }

        private void Nexxt()
        {
            F1_MessageType n = new F1_MessageType();
            n.ShowDialog();

            this.Close();
        }
    }

    public static class g
    {
        public static string SQLselection;
        public static string server;
        public static string rptName;
        public static bool messageCancel;
        public static string messageChoice;
        public static string ReportSelection;
        public static string sReplenishment;
        public static string LTAbucket;
        public static string buyer = " ";

        public static string dateAndAction = " AND r.[Starting Date] <= (GETDATE() + 14) " +
                                          " AND r.[Action Message] = 1 /* purchase new */ ";

        public static string ReportFilter = "MRP_s1p";


        public static string Main =
                             "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code]  NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB') ";

        public static string gMain =
                             "AND [SelectionCode] <> 'MMX  Min/Max' " +
                             "AND [SelectionCode] not like 'K%' " +
                             "AND [SelectionCode] NOT LIKE 'LTA%' " +
                             "AND [Vetted] <> '1' " +
                             "AND [ItemGroupCode] <> 'VMI'  " +
                             "AND CHARINDEX('X', Item, 1) <> 1 " +
                             "AND [ReferenceComponent] <> 1 " +
                             "AND [Location Code] NOT IN ('IRV', 'IRV MRB', 'Richmond', 'Richmond MRB') ";


        public static string Irvine = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND [Reference Component] <> 1 " +
                             //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                             "AND r.[Location Code] IN ('IRV', 'IRV MRB') ";

        public static string MinMax = "AND ((i.[Selection Code] = 'MMX' " +
                             "AND [Reference Component] <> 1) " +
                             "OR ([Reference Component] = 1 AND ([Item Group Code] = 'CNT' OR [Selection Code] = 'SIC'))) " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 ";

        public static string gMinMax = "AND (([SelectionCode] = 'MMX  Min/Max' " +
                             "AND [ReferenceComponent] <> 1) " +
                             "OR ([ReferenceComponent] = 1 AND ([ItemGroupCode] = 'CNT' OR [SelectionCode] = 'SIC  Statistical Inv Control'))) " +
                             "AND [Vetted] <> '1' " +
                             "AND [ItemGroupCode] <> 'VMI' " +
                             "AND [SelectionCode] not like 'K%' " +
                             "AND [SelectionCode] not like 'LTA%' " +
                             //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                             "AND CHARINDEX('X', Item, 1) <> 1 ";

        public static string X = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                            "AND r.[Location Code] NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB', 'RIC SVC') " +
                            "AND i.[Selection Code] not like 'K%' " +
                            "AND i.[Selection Code] <> 'LTA' " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public static string gX = "AND (CHARINDEX('X', Item, 1) = 1 OR [Vetted] = '1') " +
                            "AND [ReferenceComponent] <> 1 " +
                            "AND [Location Code] NOT IN ('IRV', 'IRV MRB', 'Richmond', 'Richmond MRB', 'Richmond SVC') " +
                            "AND [SelectionCode] not like 'K%' " +
                            "AND [SelectionCode] not like 'LTA%' " +
                            "AND [ItemGroupCode] <> 'VMI'  ";

        public static string KBP = "AND i.[Selection Code] = 'KBP' " +
                            "AND [Reference Component] <> 1 " +
                            //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public static string gKBP = "AND [SelectionCode] like 'KBP%' " +
                            "AND [ReferenceComponent] <> 1 " +
                            "AND [ItemGroupCode] <> 'VMI'  ";

        public static string LTA = "AND i.[Selection Code] = 'LTA' " +
                           "AND [Reference Component] <> 1 " +
                           "AND i.[Item Group Code] <> 'VMI'  ";

        public static string gLTA = "AND [SelectionCode] like 'LTA%' " +
                           "AND [ReferenceComponent] <> 1 " +
                           "AND [ItemGroupCode] <> 'VMI'  ";

        public static string Richmond = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code] IN ('RIC', 'RIC MRB', 'RIC SVC') ";

        public static string gRichmond = "AND [SelectionCode] <> 'MMX' " +
                             "AND [SelectionCode] not like 'K%' " +
                             "AND [Vetted] <> '1' " +
                             "AND [ItemGroupCode] <> 'VMI'  " +
                             "AND CHARINDEX('X', Item, 1) <> 1 " +
                             "AND [ReferenceComponent] <> 1 " +
                             "AND [Location Code] IN ('Richmond', 'Richmond MRB', 'Richmond SVC') ";

        public static string XRichmond = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            //"AND r.[Starting Date] <= (GETDATE() + 14) " +
                            "AND r.[Location Code] IN ('RIC', 'RIC MRB', 'RIC SVC')   " +
                            "AND i.[Selection Code] not like 'K%' " +
                            "AND i.[Selection Code] <> 'LTA' " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public static string gXRichmond = "AND (CHARINDEX('X', No_, 1) = 1 OR [Vetted] = '1') " +
                            "AND [ReferenceComponent] <> 1 " +
                            "AND [Location Code] IN ('Richmond', 'Richmond MRB', 'Richmond SVC') " +
                            "AND [SelectionCode] not like 'K%' " +
                            "AND [SelectionCode] <> 'LTA' " +
                            "AND [ItemGroupCode] <> 'VMI'  ";

        public static string sMRP = "SELECT " +
                        "CONVERT(varchar(10),[Starting Date], 1) " +
                        ",CONVERT(varchar(10),l.[Due Date], 1) " +
                        ",FORMAT([Remaining Quantity],'N0', 'en-us') " +
                        ",FORMAT([Cost Amount],'C', 'en-us') " +
                        ",l.[Location Code] " +
                        ",l.[Bin Code] " +
                         ",CASE[Action Message] " +
                        "     WHEN 1 THEN 'New' " +
                        "     WHEN 2 THEN CASE " +
                                "WHEN l.Quantity<l.[Original Quantity] THEN '-Qty' " +
                                 "WHEN l.Quantity > l.[Original Quantity] THEN '+Qty' " +
                             "END " +
                        "     WHEN 3 THEN 'Resched' " +
                        "     WHEN 4 THEN CASE " +
                                 "WHEN l.Quantity<l.[Original Quantity] THEN '-Qty:Date' " +
                                 "WHEN l.Quantity > l.[Original Quantity] THEN '+Qty:Date' " +
                             "END " +
                             "WHEN 5 THEN 'Cancel' " +
                        " END " +
                        ",CONVERT(varchar(10),l.[Original Due Date], 1) " +
                        ",CASE COALESCE(pl.[Best Delivery],0) " +
                        "   WHEN 0 THEN '' " +
                        "   WHEN 1 THEN 'YES' " +
                        "END " +
                        "from [ZYGO$Requisition Line] l " +
                        "LEFT JOIN [ZYGO$Purchase Line] pl  " +
                        "ON l.[Ref_ Order No_] = pl.[Document No_] " +
                        "AND l.[Ref_ Line No_] = pl.[Line No_] " +
                        "WHERE " +
                        "[Ref_ Order Type] = 1 " +
                        "AND l.Type = 2 " +                                   // type 2 = item
                        "AND [Worksheet Template Name] = 'PLANNING' " +
                        "AND [Journal Batch Name] = 'DEFAULT' " +
                        "AND  l.[No_] = '";

        public static string sMRPLTA = "SELECT " +
                        "CONVERT(varchar(10),[Starting Date], 1) " +
                        ",CONVERT(varchar(10),l.[Due Date], 1) " +
                        ",FORMAT([Remaining Quantity],'N0', 'en-us') " +
                        ",FORMAT([Cost Amount]," +
                        " 'C', 'en-us') " +
                        ",l.[Location Code] " +
                        ",l.[Bin Code] " +
                         ",CASE[Action Message] " +
                        "     WHEN 1 THEN 'New' " +
                        "     WHEN 2 THEN CASE " +
                                "WHEN l.Quantity<l.[Original Quantity] THEN '-Qty' " +
                                 "WHEN l.Quantity > l.[Original Quantity] THEN '+Qty' " +
                             "END " +
                        "     WHEN 3 THEN 'Resched' " +
                        "     WHEN 4 THEN CASE " +
                                 "WHEN l.Quantity<l.[Original Quantity] THEN '-Qty:Date' " +
                                 "WHEN l.Quantity > l.[Original Quantity] THEN '+Qty:Date' " +
                             "END " +
                             "WHEN 5 THEN 'Cancel' " +
                        " END " +
                        ",CONVERT(varchar(10),l.[Original Due Date], 1) " +
                        ",CASE COALESCE(pl.[Best Delivery],0) " +
                        "   WHEN 0 THEN '' " +
                        "   WHEN 1 THEN 'YES' " +
                        "END " +
                        "from [ZYGO$Requisition Line] l " +
                        "LEFT JOIN [ZYGO$Purchase Line] pl  " +
                        "ON l.[Ref_ Order No_] = pl.[Document No_] " +
                        "AND l.[Ref_ Line No_] = pl.[Line No_] " +
                        "WHERE " +
                        "[Ref_ Order Type] = 1 " +
                        "AND l.Type = 2 " +                                   // type 2 = item
                        "AND [Worksheet Template Name] = 'PLANNING' " +
                        "AND [Journal Batch Name] = 'DEFAULT' " +
                        "AND [Action Message] = 1 " +
                        "AND  l.[No_] = '";

        public static string Reschedule =
                    " AND r.[Starting Date] <= (GETDATE() + 14) " +
                    " AND r.[Action Message] = 3 " +
                    "AND r.No_ NOT IN ( select distinct rr.No_ from [ZYGO$Requisition Line] rr " +
                    "left join ZYGO$Item ii on rr.No_ = ii.No_ " +
                    "WHERE " +
                    "rr.[Ref_ Order Type] = 1    /*  1=purchase  */ " +
                    "AND rr.Type = 2 /* 2 = item   */ " +
                    "AND ii.[Selection Code] not like 'CFM%' " +
                    "AND rr.[Worksheet Template Name] = 'PLANNING' " +
                    "AND rr.[Journal Batch Name] = 'DEFAULT' " +
                    "AND ii.[Replenishment System] = 0     /* 0 = purchase   */ " +
                    "AND ii.No_ NOT IN  ('SERVICE ITEM','9999') ";


        /*   special for Angie    */
        /*
        public static string Main = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND r.[Location Code]  NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB') ";

        public static string Irvine = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND r.[Location Code] IN ('IRV', 'IRV MRB') ";

        public static string MinMax = "AND ((i.[Selection Code] = 'MMX' " +
                             "AND [Reference Component] <> 1) " +
                             "OR ([Reference Component] = 1 AND ([Item Group Code] = 'CNT' OR [Selection Code] = 'SIC'))) " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 ";

        public static string X = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                            "AND r.[Location Code] NOT IN ('IRV', 'IRV MRB') " +
                            "AND i.[Selection Code] not like 'K%' " +
                            "AND i.[Selection Code] <> 'LTA' " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public static string KBP = "AND i.[Selection Code] = 'KBP' " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public static string LTA = "AND i.[Selection Code] = 'LTA' " +
                           "AND [Reference Component] <> 1 " +
                           "AND i.[Item Group Code] <> 'VMI'  ";

        public static string Richmond = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code] IN ('RIC', 'RIC MRB', 'RIC SVC') ";
        */
    }

}
