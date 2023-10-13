using KnjiznicaApp.Validations;
using System.ComponentModel.DataAnnotations;

namespace KnjiznicaApp.Models
{
    public class Clan
    {
        [Key]
        public int? Id_clana { get; set; }
        [Required(ErrorMessage ="Ime obavezno")]
        [ImeNeMozeBitiBroj]
        public string? Ime { get; set; }
        [Required(ErrorMessage ="Prezime je obavezno")]
        [PrezimeNeMozeBitiBrojcs]
        public string? Prezime { get; set; }
        public int? Br_Iskaznice { get; set; }
        public bool Status { get; set; }

        
    }
}
