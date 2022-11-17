namespace Tool_Room_Messenger.Data
{
    public class Global
    {
        public string db { get; set; } = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD;";

        public DateTime Date { get; set; }

        public int RequestID { get; set; }

        public int CommentID { get; set; }

        public string? Comment { get; set; }
    }
}