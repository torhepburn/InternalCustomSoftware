using System.ComponentModel.DataAnnotations;

namespace TRReview.Data
{
    /* there may be some unused variables due to copying text from other programs  */
    public class Global
    {


        public string db { get; set; } = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";

        public string dbNAV { get; set; } = "server = PA-HOR-AS408.ametek.com; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";

        public string? Requestor_phone { get; set; }

        public string? Requestor_email { get; set; }

        public string? Requestor { get; set; }

        public string? Request_date { get; set; }

        public string? Request_need_date { get; set; }

        public string? Request_type { get; set; }

        public string? Typesubcategory { get; set; }

        public string? Request_reason { get; set; }

        public bool Request_completed { get; set; }

        public DateTime? Completion_date { get; set; }

        public bool Savings { get; set; }


        public int RequestID { get; set; }

        public int EIndex { get; set; }

        public string? Priority { get; set; }

        public string? Request_text { get; set; }

        public string Request_comments { get; set; }

        public string? Costcenter { get; set; }
                
        public string? Quantity { get; set; }

        public string? Project { get; set; }

        public string? Pdf { get; set; }

        public string? Dxf { get; set; }
        public string? Rework_order_number { get; set; }

        public string? Partnumber { get; set; }

        public string FastNumber { get; set; }
                
        public string ProductionNumber { get; set; }

        public string filetypeSelected { get; set; }

        public string TimeSavings { get; set; }

        public string CostSavings { get; set; }

        public string RevenueSavings { get; set; }

        public string Comments { get; set; }
    }

    public class ValidationComponents
    {
        public string Request_text { get; set; }

        
        public string CostCenter { get; set; }

        
        public string Employee { get; set; }

                
        public int Quantity { get; set; }

        
        public string Priority { get; set; }

        
        public string Request_Reason { get; set; }

        
        public string Request_Type { get; set; }

        
        public string TypeSubcategory { get; set; }

        
        public string partnumber { get; set; }

        
        public string FastNumber { get; set; }

        
        public string ProductionNumber { get; set; }

        
        public int TimeSavings { get; set; }

        
        public int CostSavings { get; set; }

        
        public int RevenueSavings { get; set; }

        public string? Requestor_phone { get; set; }

        public string? Requestor_email { get; set; }
                
        public DateTime Request_need_date { get; set; }

        public string? Project { get; set; }

        public string? Rework_order_number { get; set; }

        public string? Request_comments { get; set; }
    }

    public class ValidationComplete
    {
        [Required]
        [Range(.1, 10000)]
        public decimal ActualHours { get; set; }

        [Required]
        [ValidYear(ErrorMessage="Must select valid date.")]
        public DateTime Date_Completed { get; set; }


    }

    public class ValidYear : ValidationAttribute
    {
        private readonly DateTime _minValue = DateTime.UtcNow.AddDays(-14);
        private readonly DateTime _maxValue = DateTime.UtcNow.AddYears(60);

        public override bool IsValid(object value)
        {
            DateTime val = (DateTime)value;
            return val >= _minValue && val <= _maxValue;
        }

        public override string FormatErrorMessage(string name)
        {
            //return string.Format(ErrorMessage);
            return string.Format(ErrorMessage, _minValue, _maxValue);
        }

    }

}
