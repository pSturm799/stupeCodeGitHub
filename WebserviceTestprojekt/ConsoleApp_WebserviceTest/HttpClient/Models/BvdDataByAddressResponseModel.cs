using System;

namespace ConsoleApp_WebserviceTest.HttpClient.Models
{
    public class BvdDataByAddressResponseModel
    {
        public SearchsummaryAddress SearchSummary { get; set; }
        public GetAddressData[] Data { get; set; }
    }

    public class SearchsummaryAddress
    {
        public int TotalRecordsFound { get; set; }
        public int Offset { get; set; }
        public int RecordsReturned { get; set; }
        public DatabaseinfoAddress DatabaseInfo { get; set; }
        public object Sort { get; set; }
    }

    public class DatabaseinfoAddress
    {
        public string ReleaseNumber { get; set; }
        public string UpdateNumber { get; set; }
        public DateTime UpdateDate { get; set; }
        public string VersionNumber { get; set; }
        public DateTime IndexationDate { get; set; }
    }

    public class Sort
    {
        public string DESC { get; set; }
    }

    public class GetAddressData
    {
        public MATCH MATCH { get; set; }
    }

    public class MATCH
    {
        public AdressData AdressData { get; set; }
    }

    public class AdressData
    {
        public string Hint { get; set; }
        public float Score { get; set; }
        public string Name { get; set; }
        public object Name_Local { get; set; }
        public string MatchedName { get; set; }
        public string MatchedName_Type { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address_Type { get; set; }
        public string PhoneOrFax { get; set; }
        public string EmailOrWebsite { get; set; }
        public string National_Id { get; set; }
        public string NationalIdLabel { get; set; }
        public object State { get; set; }
        public string Region { get; set; }
        public string LegalForm { get; set; }
        public string ConsolidationCode { get; set; }
        public string Status { get; set; }
        public object Ticker { get; set; }
        public object CustomRule { get; set; }
        public object Isin { get; set; }
        public string BvDId { get; set; }
    }
}