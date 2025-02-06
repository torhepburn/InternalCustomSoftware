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

    }
}
