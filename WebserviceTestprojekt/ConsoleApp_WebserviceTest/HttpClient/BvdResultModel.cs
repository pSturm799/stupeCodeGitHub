using System;

namespace ConsoleApp_WebserviceTest.HttpClient
{
    public class BvdResultModel
    {
        public Searchsummary SearchSummary { get; set; }
        public Datum[] Data { get; set; }
    }

    public class Searchsummary
    {
        public int TotalRecordsFound { get; set; }
        public int Offset { get; set; }
        public int RecordsReturned { get; set; }
        public Databaseinfo DatabaseInfo { get; set; }
        public object Sort { get; set; }
    }

    public class Databaseinfo
    {
        public string ReleaseNumber { get; set; }
        public string UpdateNumber { get; set; }
        public DateTime UpdateDate { get; set; }
        public string VersionNumber { get; set; }
        public DateTime IndexationDate { get; set; }
    }

    public class Datum
    {
        public string NAME { get; set; }
        public string[] STATUS { get; set; }
        public string BVD_ID_NUMBER { get; set; }
        public object VAT_NUMBER { get; set; }
        public object EUROPEAN_VAT_NUMBER { get; set; }
        public object COUNTRY_REGION { get; set; }
        public string COUNTRY_ISO_CODE { get; set; }
        public string CITY { get; set; }
        public string POSTCODE { get; set; }
        public string ADDRESS_LINE1 { get; set; }
        public object ADDRESS_LINE2 { get; set; }
        public object ADDRESS_LINE3 { get; set; }
        public object ADDRESS_LINE4 { get; set; }
        public object PHONE_NUMBER { get; set; }
        public object WEBSITE { get; set; }
        public object EMAIL { get; set; }
        public object NACE2_CORE_CODE { get; set; }
        public object TRADE_REGISTER_NUMBER { get; set; }
    }
}