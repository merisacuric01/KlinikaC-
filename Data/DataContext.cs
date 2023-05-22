using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using klinika.models;
using Microsoft.EntityFrameworkCore;

namespace klinika.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base(options) { }
        public DbSet<Doktor> Doktori { get; set; }
        public DbSet<Odeljenje> Odeljenja { get; set; }
        public DbSet<Pacijent> Pacijenti { get; set; }
        public DbSet<Pregled> Pregledi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Odeljenje>().HasData(
                new Odeljenje()
                {
                    OdeljenjeID = 1,
                    Naziv = "Hirurg"
                },
                new Odeljenje()
                {
                    OdeljenjeID = 2,
                    Naziv = "Decije"
                }
            );
            modelBuilder.Entity<Doktor>().HasData(
                new Doktor()
                {
                    DoktorID = 1,
                    Ime = "Jasmina",
                    Prezime = "Zupic",
                    Kontact = "0641458792",
                    OdeljenjeID = 1
                },
                new Doktor()
                {
                    DoktorID = 2,
                    Ime = "Kimeta",
                    Prezime = "Lukic",
                    Kontact = "0641665892",
                    OdeljenjeID = 2
                }
            );
        }
    }
}