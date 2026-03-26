
namespace Shortages.Pages
{
    using System.ComponentModel.DataAnnotations;
    public class Shortage
    {
        public string? ID { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string? prodLine { get; set; }

        public string? group { get; set; }
        public bool stockOut { get; set; }

        /* this is for adding or removing from the war room list  */
        public bool add2WarRoomList { get; set; }

        /*  this is for keeping track of what is on the war room list for the review  */
        public bool onWarRoomList { get; set; }

        [Required(ErrorMessage = "*")]
        public int? quantityReq { get; set; }
        
        [Required(ErrorMessage = "*")]
        public string? code { get; set; }

        public bool customItem { get; set; }

        [Required(ErrorMessage = "*")]
        public string? description { get; set; }

        public string? project { get; set; }
        public string? projectDesc { get; set; }
        
        public PurchaseOrder PurchaseOrder = new PurchaseOrder();
        public bool addLinesPO { get; set; }


        public string? productionOrder { get; set; }
        public string? salesOrder { get; set; }
        public int? SOLineNum { get; set; }
        public DateTime? shipDate { get; set; }
        public DateTime? salesOrderDate { get; set; }
        public string? buyer { get; set; }
        public string? vendor { get; set; }

        public DateTime? reqDate { get; set;}
        public DateTime? iqcCompleteDate { get; set; }
        public DateTime? promisedReceiptDate { get; set; }

        public string? comments { get; set; }

        [Required(ErrorMessage = "*")]
        public string? reason { get;set; }
        
        public string? status { get; set; }

        public string? lateFlagStatus { get; set; }

        [Required(ErrorMessage = "*")]
        public string? priority { get; set; }
        

        public string? trackingNo { get; set; }
        public bool flagField { get; set; }
        public bool impactsRevenue { get; set; }

    }

}
