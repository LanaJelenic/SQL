using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace KnjiznicaApp.Models
{
    public class Evidencija_posudbe
    {
        [Key]
        public int Id_posudbe { get; set; }
        public DateTime Datum_posudbe { get; set; }
        public DateTime Datum_vracanja { get; set; }

        [ForeignKey("Id_clana")]
        public Clan? Clan { get; set; }
        public List<Knjiga> Knjige { get; set; } = new();
    }
}
