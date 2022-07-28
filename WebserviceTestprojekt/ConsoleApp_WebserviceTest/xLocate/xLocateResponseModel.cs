namespace ConsoleApp_WebserviceTest.xLocate
{
    public class XLocateResponse
    {
        public int errorCode { get; set; }
        public string errorDescription { get; set; }
        public Resultlist[] resultList { get; set; }
    }

    public class Resultlist
    {
        public string type { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string postCode { get; set; }
        public string city { get; set; }
        public string city2 { get; set; }
        public string street { get; set; }
        public string houseNumber { get; set; }
        public string adminRegion { get; set; }
        public string appendix { get; set; }
        public string countryCapital { get; set; }
        public int totalScore { get; set; }
        public string detailLevelDescription { get; set; }
        public string classificationDescription { get; set; }
        public Coordinates coordinates { get; set; }
        public object[] additionalFields { get; set; }
    }

    public class Coordinates
    {
        public string type { get; set; }
        public Point point { get; set; }
    }

    public class Point
    {
        public string type { get; set; }
        public float x { get; set; }
        public float y { get; set; }
    }
}