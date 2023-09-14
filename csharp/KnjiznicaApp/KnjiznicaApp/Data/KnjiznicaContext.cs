using KnjiznicaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KnjiznicaApp.Data
{
    public class KnjiznicaContext:DbContext
    {
        public KnjiznicaContext(DbContextOptions<KnjiznicaContext> options) 
            : base(options) { 
        }

        public DbSet<Clan> Clan { get; set; }
        public DbSet<Knjiga>Knjiga { get; set; }
        public DbSet<EvidencijaPosudbe> Evidencija {  get; set; }

    }
}
