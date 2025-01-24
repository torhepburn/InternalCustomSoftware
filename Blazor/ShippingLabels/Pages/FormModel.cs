using System.ComponentModel.DataAnnotations;

namespace ShippingLabels.Pages
{
    public class FormModel
    {
        [Required]
        public string workOrder { get; set; }
        
        public string part { get; set; }

        public string description { get; set; }

        public string serialNumber { get; set; }

        public string db = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                           "user = readWrite; database = Optics; encrypt=false;";

        public string dbNAV = "server = pa-hor-as408.ametek.com; password = 2018#ameteK; " +
                           "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";
    }
}
