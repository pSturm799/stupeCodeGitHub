namespace AutoMappperDemo.Models
{
    public class ObjektModel
    {
        public string Id { get; set; }
        public string Krzl { get; set; }
        public string ParId { get; set; }
        public int Hnr { get; set; }
        public bool Krkt { get; set; }
        public ObjektModel ParObjModel { get; set; }
    }
}