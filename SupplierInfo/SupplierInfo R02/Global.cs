namespace SupplierInfo_R02
{
    public class Global
    {
        public string? db { get; set; } = "server = CT-MID-SQL11.ametek.com; password = Read+Write!; " +
                                        "user = readWrite; database = AccessFrontends; encrypt=false;";

        public string? dbNAV { get; set; } = "server = PA-HOR-AS408.ametek.com; password = 2018#ameteK; " +
                                        "user = navdb_read; database = ZYGO-NAV-PROD; encrypt=false;";
        /*
                public int RequestID { get; set; }

                public string? enteredOn { get; set; }*/
        public string? vendorTitle { get; set; }
        public string? supplierName { get; set; }
        public string? supplierNo { get; set; }
        public string? supplierRating { get; set; }
        public string? qualityRating { get; set; }
        public string? otdRating { get; set; }
        public string? paymentTerms { get; set; }
        public string? paymentTermsPlan { get; set; }
        public string? annualspendActual { get; set; }
        public string? annualspendProjected { get; set; }
        public string? locationRegion { get; set; }
        public string? commodity1 { get; set; }
        public string? commodity2 { get; set; }
        public string? buyer { get; set; }
        public string? parentCompanyLocation { get; set; }
        public string? parentCompanyName { get; set; }
        public string? headquartersLocation { get; set; }
        public string? factoryLocations { get; set; }
        public string? technology { get; set; }
        public string? costSavingsPlan { get; set; }
        public string? costSavingsStatus { get; set; }
        public string? strategy { get; set; }
        public string? keyIssues { get; set; }
        public string? leadTimePlan { get; set; }
        public string? leadTimeRange { get; set; }
        public string? businessAlignment { get; set; }
        public string? notes { get; set; }
        public DateOnly? ndaExpirationDate { get; set; }
        public DateOnly? ISO9001ExpirationDate { get; set; }
        public DateOnly? ISO13485ExpirationDate { get; set; }
        public DateOnly? AS9100ExpirationDate { get; set; }
        public DateOnly? ZM0027ExpirationDate { get; set; }
        public string? alternateSuppliers { get; set; }
        public string? numberCriticalParts { get; set; }
        public string? contractsType { get; set; }
        public string? percentOfCoverage { get; set; }
        public string? typeStatus { get; set; }
        public string? lineofBusiness { get; set; }


        public string? selectedCommodity { get; set; }
        public string? selectedVendor { get; set; }
        public string? selectedVendorTitle { get; set; }
        public string? selectedBuyer { get; set; }
        public string? selectedRegion { get; set; }

    }
}
