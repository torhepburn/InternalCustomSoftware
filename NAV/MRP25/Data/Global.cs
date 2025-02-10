namespace MRP25.Data
{
    public class Global
    {
        public string db { get; set; } = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontEnds; encrypt=false;";

        public string dbNAV { get; set; } = "server = PA-HOR-AS408.ametek.com; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string dbMSDB { get; set; } = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                                        "user = readWrite; database = msdb; encrypt=false;";

        public string SQLselection { get; set; }
        
        public string server { get; set; }

        public string rptName { get; set; }
        public bool messageCancel { get; set; }

        public string messageChoice { get; set; }

        public string ReportSelection { get; set; }

        public string sReplenishment { get; set; }

        public string LTAbucket { get; set; }

        public string buyer { get; set; } = " ";
        
        public string dateAndAction { get; set; } =
                                  " AND r.[Starting Date] <= (GETDATE() + 14) "; /*1217mod*/
        /*" AND r.[Starting Date] <= (GETDATE() + 21) " +
                 " AND r.[Action Message] = 1 /* purchase new */
        
        public string Main { get; set; } = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code]  NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB') ";

        public string Irvine { get; set; } = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code] IN ('IRV', 'IRV MRB') ";

        public string MinMax { get; set; } = "AND ((i.[Selection Code] = 'MMX' " +
                             "AND [Reference Component] <> 1) " +
                             "OR ([Reference Component] = 1 AND ([Item Group Code] = 'CNT' OR [Selection Code] = 'SIC'))) " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 ";

        public string X { get; set; } = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Location Code] NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB', 'RIC SVC') " +
                            "AND i.[Selection Code] not like 'K%' " +
                            "AND i.[Selection Code] <> 'LTA' " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public string KBP { get; set; } = "AND i.[Selection Code] = 'KBP' " +
                            "AND [Reference Component] <> 1 " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public string LTA { get; set; } = "AND i.[Selection Code] = 'LTA' " +
                           "AND [Reference Component] <> 1 " +
                           "AND i.[Item Group Code] <> 'VMI'  ";

        public string Richmond { get; set; } = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Location Code] IN ('RIC', 'RIC MRB', 'RIC SVC') ";

        public string XRichmond { get; set; } = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Location Code] IN ('RIC', 'RIC MRB', 'RIC SVC') " +
                            "AND i.[Selection Code] not like 'K%' " +
                            "AND i.[Selection Code] <> 'LTA' " +
                            "AND i.[Item Group Code] <> 'VMI'  ";


        public string sMRP { get; set; } = "SELECT " +
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

        public string sMRPLTA { get; set; } = "SELECT " +
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

        public string Reschedule { get; set; } = " AND r.[Starting Date] <= (GETDATE() + 14) " +

                    /*" AND r.[Starting Date] <= (GETDATE() + 21) " +*/  /* 1217mod*/
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
        public string Main = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND r.[Location Code]  NOT IN ('IRV', 'IRV MRB', 'RIC', 'RIC MRB') ";

        public string Irvine = "AND i.[Selection Code] <> 'MMX' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND i.[Item Group Code] <> 'VMI'  " +
                             "AND [Reference Component] <> 1 " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND r.[Location Code] IN ('IRV', 'IRV MRB') ";

        public string MinMax = "AND ((i.[Selection Code] = 'MMX' " +
                             "AND [Reference Component] <> 1) " +
                             "OR ([Reference Component] = 1 AND ([Item Group Code] = 'CNT' OR [Selection Code] = 'SIC'))) " +
                             "AND i.[Vetted] <> '1' " +
                             "AND i.[Item Group Code] <> 'VMI' " +
                             "AND i.[Selection Code] not like 'K%' " +
                             "AND i.[Selection Code] <> 'LTA' " +
                             "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                             "AND CHARINDEX('X', r.No_, 1) <> 1 ";

        public string X = "AND (CHARINDEX('X', r.No_, 1) = 1 OR i.[Vetted] = '1') " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                            "AND r.[Location Code] NOT IN ('IRV', 'IRV MRB') " +
                            "AND i.[Selection Code] not like 'K%' " +
                            "AND i.[Selection Code] <> 'LTA' " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public string KBP = "AND i.[Selection Code] = 'KBP' " +
                            "AND [Reference Component] <> 1 " +
                            "AND r.[Buyer Planner Code] = 'ANGIE W' " +
                             "AND r.[Starting Date] <= (GETDATE() + 42) " +
                            "AND i.[Item Group Code] <> 'VMI'  ";

        public string LTA = "AND i.[Selection Code] = 'LTA' " +
                           "AND [Reference Component] <> 1 " +
                           "AND i.[Item Group Code] <> 'VMI'  ";

        public string Richmond = "AND i.[Selection Code] <> 'MMX' " +
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
