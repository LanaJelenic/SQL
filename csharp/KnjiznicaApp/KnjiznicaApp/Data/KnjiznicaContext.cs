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
        public DbSet<Evidencija_posudbe> Evidencija {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //implementacija 1:n
            modelBuilder.Entity<Evidencija_posudbe>().HasOne(e => e.Clan);

            //implementacija n:n
            modelBuilder.Entity<Evidencija_posudbe>()
                .HasMany(e => e.Knjige)
                .WithMany(k => k.Evidencija)
                .UsingEntity<Dictionary<string, object>>("knjiga_posudba",
                k => k.HasOne<Knjiga>().WithMany().HasForeignKey("Id_knjige"),
                k => k.HasOne<Evidencija_posudbe>().WithMany().HasForeignKey("Id_posudbe"),
                k => k.ToTable("knjiga_posudba"));
        }



    }
}
