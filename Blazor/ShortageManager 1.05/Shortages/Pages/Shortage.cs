
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
        public DateTime? salesOrderDate { get; set; }
        public DateTime? shipDate { get; set; }
        public DateTime? reqDate { get; set;}
        public DateTime? iqcCompleteDate { get; set; }
        public DateTime? promisedReceiptDate { get; set; }

        public string? comments { get; set; }
        public string? buyer { get; set; }
        public bool hot { get; set; }
        public string? reason { get;set; }
        public string? status { get; set; }
        public string? lateFlagStatus { get; set; }
        public string? trackingNo { get; set; }
        public bool flagField { get; set; }
    }

}
