namespace LowBin.Data
{
    public class FormModel
    {

        public string item { get; set; }

        public string FullQty { get; set; }

        public string db = "server = CT-MID-SQL11; password = Read+Write!; " +
                           "user = readWrite; database = AccessFrontEnds; encrypt=false;";

        public string dbNAV = "server = pa-hor-as408; password = 2018#ameteK; " +
                           "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";
    }
}
