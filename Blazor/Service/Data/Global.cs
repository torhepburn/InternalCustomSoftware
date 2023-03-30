namespace Service.Data
{
    public class Global
    {
        public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";

        public string UID { get; set; }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}