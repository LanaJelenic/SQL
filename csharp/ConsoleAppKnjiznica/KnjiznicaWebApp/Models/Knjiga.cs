namespace KnjiznicaWebApp.Models
{
    public class Knjiga:ID
    {
        public string? Naziv { get; set; }
        public string ImeAutora { get; set; }
        public string PrezimeAutora { get; set; }
        public string? Sazetak { get; set; }
        public int BrStranica { get; set; }
    }
}
