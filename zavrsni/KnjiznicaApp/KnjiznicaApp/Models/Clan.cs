using System.ComponentModel.DataAnnotations;

namespace KnjiznicaApp.Models
{
    public class Clan
    {
        [Key]
        public int? Id_clana { get; set; }
        [Required]
        public string? Ime { get; set; }
        [Required]
        public string? Prezime { get; set; }
        public int? Br_Iskaznice { get; set; }
        public bool Status { get; set; }

        
    }
}
