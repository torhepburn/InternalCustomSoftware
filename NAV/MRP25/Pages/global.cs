namespace MRP25.Pages
{
    public class global
    {
        public string db { get; set; } = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontEnds; encrypt=false;";

        public string dbNAV { get; set; } = "server = PA-HOR-AS408.ametek.com; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string dbMSDN { get; set; } = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontEnds; encrypt=false;";

    }
}
