using System.ComponentModel.DataAnnotations;

namespace RichmondDesignRequest.Data
{
    public class FormModel
    {
        [Required]

        //public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
        //                                "user = readWrite; database = AccessFrontends; encrypt=false;";

        //public string dbNAV { get; set; } = "server = PA-HOR-AS408; password = 2018#ameteK; " +
        //                                "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string? priority { get; set; }

        //public string? requestor { get; set; }

        //public string? requestorEmail { get; set; }

        //public int CommentID { get; set; }

        //public string? Comment { get; set; }

        //public string? binCode { get; set; }
        //public string? storekeeper { get; set; }

        //public string? costcenter { get; set; }

        //public string? planner { get; set; }
    }
}