using System;
using System.ComponentModel.DataAnnotations;

namespace OpticsTracker.Data
{
    public class FormModel
    {
        //[Required]
        public string location { get; set; }

        [Required]
        public string workOrder { get; set; }

        public string part { get; set; }

        public string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                           "user = readWrite; database = Optics; encrypt=false;";

        public string dbNAV = "server = pa-hor-as408; password = 2018#ameteK; " +
                           "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";
    }
}
