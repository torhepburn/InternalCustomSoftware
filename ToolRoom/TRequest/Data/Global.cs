namespace TRequest.Data
{
    public class Global
    {

        public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";

        public string dbNAV { get; set; } = "server = PA-HOR-AS408; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string? requestorPhone { get; set; }

        public string? requestor { get; set; }

        public string? requestType { get; set; }

        public int requestID { get; set; }

        public int eIndex { get; set; }

        public string priority { get; set; }

        public string? request_text { get; set; }
               
        public string? costcenter { get; set; }

        public string? project { get; set; }

        public bool persist { get; set; }

        public bool Ftwofiles { get; set; }

        public bool Ftwofiles2BUploaded { get; set; }

        public string filetypeSelected { get; set; }

        public string requestResponse { get; set; }

        public string subjectLine { get; set; }

        public string requestReport { get; set; }

        public string contactEmail { get; set; }
    }
}
