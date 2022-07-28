namespace AutoMappperDemo.Models
{
    public class DisplayModel
    {
        public string Id { get; set; }
        public string Kuerzel { get; set; }

        public string ParentObjektId { get; set; }
        public ObjektModel ParentObjekt { get; set; }
        public int Ebene { get; set; } = -1;
        public string Hausnummer { get; set; }
        public bool Korrekt { get; set; }
    }
}