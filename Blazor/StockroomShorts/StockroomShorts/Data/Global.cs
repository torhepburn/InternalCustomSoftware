namespace StockroomShorts.Data
{
    //public class Global
    //{
    //    public DateTime Date { get; set; }

    //    public int TemperatureC { get; set; }

    //    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //    public string? Summary { get; set; }
    //}
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