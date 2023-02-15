namespace ServiceRequests.Data
{
    public class Global
    {
        public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";
    }
}