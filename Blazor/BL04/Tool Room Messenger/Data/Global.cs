namespace Tool_Room_Messenger.Data
{
    public class Global
    {
        public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";

        public DateTime Date { get; set; }

        public string? RequestID { get; set; }

        public int CommentID { get; set; }

        public string? Comment { get; set; }
    }
}