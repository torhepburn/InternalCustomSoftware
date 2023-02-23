namespace StockroomShorts.Data
{
     public class Global
    {
        public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";

        public string dbNAV { get; set; } = "server = PA-HOR-AS408; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string? WorkOrder { get; set; }

        public DateTime Date { get; set; }

        public string? ShortageID { get; set; }

        public int CommentID { get; set; }

        public string? Comment { get; set; }
    }

}