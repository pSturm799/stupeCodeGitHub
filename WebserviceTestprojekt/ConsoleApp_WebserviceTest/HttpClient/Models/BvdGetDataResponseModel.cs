using System;

namespace ConsoleApp_WebserviceTest.HttpClient.Models
{
    public class BvdGetDataResponseModel
    {
        public Searchsummary SearchSummary { get; set; }
        public BvdGetData[] Data { get; set; }
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

    public class BvdGetData
    {
        public string NAME { get; set; }
        public string ADDRESS_LINE1 { get; set; }
        public string COUNTRY { get; set; }
        public string COUNTRY_ISO_CODE { get; set; }
        public string POSTCODE { get; set; }
        public string CITY { get; set; }
        public string[] FAX { get; set; }
        public string[] PHONE_NUMBER { get; set; }
        public string[] WEBSITE { get; set; }
        public string[] EMAIL { get; set; }
        public object OPRE { get; set; }
        public string NACE2_CORE_CODE { get; set; }
        public string[] NACE2_SECONDARY_CODE { get; set; }
        public string COMPANY_CATEGORY { get; set; }
        public float? EMPL { get; set; }
        public string[] VAT_NUMBER { get; set; }
        public object TRADE_DESCRIPTION_EN { get; set; }
        public string[] GUO_NAME { get; set; }
        public string[] ISH_NAME { get; set; }
        public string[] TRADE_REGISTER_NUMBER { get; set; }
        public string BVD_ID_NUMBER { get; set; }
    }
}