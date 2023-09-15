namespace KnjiznicaApp.Models.DTO
{
    public class EvidencijaDTO
    {
        public int Id_posudbe { get; set; }
        public DateTime Datum_posudbe { get; set; }
        public DateTime Datum_vracanja { get; set; }
        public string? Clan { get; set; }
        public int BrojKnjiga { get; set; }
        public int IdClana { get; set; }
    }
}
