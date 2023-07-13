namespace Shortages.Pages
{
    public class PurchaseOrder
    {
        public string? OrderNo { get; set; }
        public DateTime? OrigRqstDate { get; set; }
        public string? Supplier { get; set; }
        public double Quantity { get; set; }
        public DateTime? PlannedDate { get; set; }
        public string? PurchaserCode { get; set; }
    }
}
