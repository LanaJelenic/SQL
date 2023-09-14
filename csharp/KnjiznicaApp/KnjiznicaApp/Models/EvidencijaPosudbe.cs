using System.ComponentModel.DataAnnotations;

namespace KnjiznicaApp.Models
{
    public class EvidencijaPosudbe
    {
        [Key]
        public int Id_posudbe { get; set; }
        public DateTime Datum_posudbe { get; set; }
        public DateTime Datum_vracanja { get; set; }
    }
}
