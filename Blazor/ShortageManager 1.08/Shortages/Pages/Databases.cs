using Microsoft.Data.SqlClient;

namespace Shortages.Pages
{
    public static class Databases
    {
        public static string dbDash = "server = CT-MID-DB01.AMETEK.com; password = views; " +
            "user = views; database = Dashboard;";
        public static string ZTEST = "server=ct-mid-sql11.AMETEK.com; user=ReadWrite; password=Read+Write!; database=ZTEST; encrypt=false";
        public static string db = "server = CT-MID-SQL11.AMETEK.com; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds; encrypt=false";
        public static string dbNAV = "server = pa-hor-as408.AMETEK.com; password = 2018#ameteK; " + "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false";
        public static string NAVprefix = "ZYGO$";
        public static string dbSQL11 = "server = CT-MID-SQL11.AMETEK.com; password = Read+Write!; " +
                            "user = readwrite; database = AccessFrontEnds; encrypt=false";
    }
}

