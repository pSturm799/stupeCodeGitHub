namespace ConsoleApp_WebserviceTest
{
    public class TokenModel
    {
        public D d { get; set; }
    }

    public class D
    {
        public Getcontextwebinformation GetContextWebInformation { get; set; }
    }

    public class Getcontextwebinformation
    {
        public __Metadata __metadata { get; set; }
        public int FormDigestTimeoutSeconds { get; set; }
        public string FormDigestValue { get; set; }
        public string LibraryVersion { get; set; }
        public string SiteFullUrl { get; set; }
        public Supportedschemaversions SupportedSchemaVersions { get; set; }
        public string WebFullUrl { get; set; }
    }

    public class __Metadata
    {
        public string type { get; set; }
    }

    public class Supportedschemaversions
    {
        public __Metadata1 __metadata { get; set; }
        public string[] results { get; set; }
    }

    public class __Metadata1
    {
        public string type { get; set; }
    }
}