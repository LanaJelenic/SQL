namespace KnjiznicaApp.Models.DTO
{
    public class KnjigaDTO
    {
        public int Id_knjige { get; set; }
        public string Naslov { get; set; }
        public string Ime_Autora { get; set; }
        public string Prezime_Autora { get; set; }
        public string? Sazetak { get; set; }
        public int? Br_stranica { get; set; }
        public string? Slika { get; set; }
    }
}
