using Microsoft.Data.SqlClient;
using StockroomShorts.Pages;
using System.Data;
using System.Text;

namespace StockroomShorts.Data
{
     public class Global
    {
        public string db { get; set; } = "server = CT-MID-SQL11; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontEnds; encrypt=false;";

        public string dbNAV { get; set; } = "server = PA-HOR-AS408; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string SQLs1 { get; set; } = "WITH s1 AS " +
                                 "( " +
                                " SELECT " +
                                " ShortageID " +
                                ",MAX(CommentID) CommentID " +
                                " FROM StockroomComments " +
                                " GROUP BY ShortageID  " +
                                ") " +
                                ",s2 AS " +
                                "( " +
                                "	SELECT " +
                                "	s1.ShortageID " +
                                "	,Comment " +
                                "   ,FORMAT([EnteredOn],'MM/dd/yy') EnteredOn " +
                                "	FROM StockroomComments c " +
                                " INNER JOIN s1 ON s1.ShortageID = c.ShortageID and s1.CommentID = c.CommentID " +
                                ") " +
                                " select " +
                                " ID " +
                                ", COALESCE(FORMAT(s.[EnteredOn],'MM/dd/yy'), '') Date " +
                                ", COALESCE(WO, '') [Work Order #] " +
                                ", COALESCE(PartNo, '') [Part Number] " +
                                ", COALESCE(LEFT(PartDescription, 10), '') [Part Description] " +
                                ", COALESCE(WOLine, '') [Work Order Line] " +
                                ", COALESCE(JobDescription, '') [Job Description] " +
                                ", COALESCE(JobReference, '') [Job Reference] " +
                                ", COALESCE(Quantity, 0) [Quantity Short] " +
                                ", COALESCE(Location, '') [Location] " +
                                ", COALESCE(Stocklocation, '') [Bin Code] " +
                                ", COALESCE(CostCenter, '') [Cost Center] " +
                                ", COALESCE(StockRoomAssociate,'') [Stockroom Associate] " +
                                ", COALESCE(Planner, '') [Planner] " +
                                ", COALESCE(DueDate, '') [Due Date] " +
                                ", COALESCE(s2.Comment,'') [Most Recent Comment] " +
                                //", COALESCE(s2.EnteredOn,'') [Comment Date] " +
                                ", COALESCE(TRIM(color),'') [Status] " +
                                " from StockroomShortages s" +
                                " LEFT JOIN s2 ON s.ID = s2.ShortageID ";

        public string? archive { get; set; }

        public string? exportFile { get; set; }

        public string? location { get; set; }

        public string? duedate { get; set; }

        public string? ShortageID { get; set; }

        public int CommentID { get; set; }

        public string? Comment { get; set; }

        public string? binCode { get; set; }
        public string? storekeeper { get; set; }

        public string? costcenter { get; set; }

        public string? planner { get; set; }

        public bool isLoading = false;

        public List<Group> groups = new List<Group>();
    }

    
}