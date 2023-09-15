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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //implementacija 1:n
            modelBuilder.Entity<EvidencijaPosudbe>().HasOne(e => e.Clan);

            //implementacija n:n
            modelBuilder.Entity<EvidencijaPosudbe>()
                .HasMany(e => e.Knjige)
                .WithMany(k => k.Evidencija)
                .UsingEntity<Dictionary<string, object>>("knjiga_posudba",
                k => k.HasOne<Knjiga>().WithMany().HasForeignKey("Id_knjige"),
                k => k.HasOne<EvidencijaPosudbe>().WithMany().HasForeignKey("Id_posudbe"),
                k => k.ToTable("knjiga_posudba"));
        }



    }
}
