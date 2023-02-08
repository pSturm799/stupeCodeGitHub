namespace ConsoleApp_WebserviceTest.HttpClient
{
    public class WHERE
    {
        public string[] BvDID { get; set; }
    }

    public class SELECT
    {
        public object[] SELECT3 { get; set; }
    }

    public class PHONE_NUMBER
    {
        public PN_LIMIT LIMIT { get; set; }
    }

    public class PN_LIMIT
    {
        public int LIMIT { get; set; }
    }

    public class SearchByBvdIdModelect
    {
        public WHERE WHERE { get; set; }
        public SELECT SELECT2 { get; set; }

        public object[] SELECT
        {
            get
            {
                var x = "NAME";

                return new[]
                       {
                           "NAME",

                           //           "ADDRESS_LINE1",
                           //           "COUNTRY",
                           //           "COUNTRY_ISO_CODE",
                           //           "POSTCODE",
                           //           "CITY",
                           //           "FAX",
                           //           "NACE2_CORE_CODE",
                           //           "NACE2_SECONDARY_CODE",
                           //           "COMPANY_CATEGORY",
                           //           "EMPL",
                           //           "VAT_NUMBER",
                           //           "TRADE_DESCRIPTION_EN",
                           //           "GUO_NAME",
                           //           "ISH_NAME",
                           //           "BVD_ID_NUMBER",
                           //           @"{""PHONE_NUMBER"": {""LIMIT"": 1}}",
                           //           //"{\"WEBSITE\": {\"LIMIT\": 1}}",
                           //           //"{\"EMAIL\": {\"LIMIT\": 1}}",
                           //           //"{\"TRADE_REGISTER_NUMBER\": {\"LIMIT\": 1}}",
                       };
            }
        }
    }
}