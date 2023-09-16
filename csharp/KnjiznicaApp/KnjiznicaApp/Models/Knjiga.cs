using System.ComponentModel.DataAnnotations;

namespace KnjiznicaApp.Models
{
    public class Knjiga

    {
        [Key]
        public int Id_knjige { get; set; }
        public string Naslov { get; set; }
        public string Ime_Autora { get; set; }
        public string Prezime_Autora { get; set; }
        public string? Sazetak { get; set; }
        public int? Br_stranica { get; set; }
        public ICollection<Evidencija_posudbe> Evidencija_posudba { get; } = new List<Evidencija_posudbe>();


    }
}
