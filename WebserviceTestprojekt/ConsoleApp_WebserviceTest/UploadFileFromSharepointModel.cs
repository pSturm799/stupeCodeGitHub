using System;

namespace ConsoleApp_WebserviceTest
{
    public class UploadFileFromSharepointModel
    {
        public UploadFileFromSharepointModel_D d { get; set; }
    }

    public class UploadFileFromSharepointModel_D
    {
        public UploadFileFromSharepointModel_Result[] results { get; set; }
    }

    public class UploadFileFromSharepointModel_Result
    {
        public UploadFileFromSharepointModel__Metadata __metadata { get; set; }
        public Author Author { get; set; }
        public Checkedoutbyuser CheckedOutByUser { get; set; }
        public Listitemallfields ListItemAllFields { get; set; }
        public Lockedbyuser LockedByUser { get; set; }
        public Modifiedby ModifiedBy { get; set; }
        public Versions Versions { get; set; }
        public string CheckInComment { get; set; }
        public int CheckOutType { get; set; }
        public string ContentTag { get; set; }
        public int CustomizedPageStatus { get; set; }
        public string ETag { get; set; }
        public bool Exists { get; set; }
        public string Length { get; set; }
        public int Level { get; set; }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public string Name { get; set; }
        public string ServerRelativeUrl { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeLastModified { get; set; }
        public object Title { get; set; }
        public int UIVersion { get; set; }
        public string UIVersionLabel { get; set; }
    }

    public class UploadFileFromSharepointModel__Metadata
    {
        public string id { get; set; }
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class Author
    {
        public __Deferred __deferred { get; set; }
    }

    public class __Deferred
    {
        public string uri { get; set; }
    }

    public class Checkedoutbyuser
    {
        public __Deferred1 __deferred { get; set; }
    }

    public class __Deferred1
    {
        public string uri { get; set; }
    }

    public class Listitemallfields
    {
        public __Deferred2 __deferred { get; set; }
    }

    public class __Deferred2
    {
        public string uri { get; set; }
    }

    public class Lockedbyuser
    {
        public __Deferred3 __deferred { get; set; }
    }

    public class __Deferred3
    {
        public string uri { get; set; }
    }

    public class Modifiedby
    {
        public __Deferred4 __deferred { get; set; }
    }

    public class __Deferred4
    {
        public string uri { get; set; }
    }

    public class Versions
    {
        public __Deferred5 __deferred { get; set; }
    }

    public class __Deferred5
    {
        public string uri { get; set; }
    }
}