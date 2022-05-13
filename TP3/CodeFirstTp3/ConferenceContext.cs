using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTp3
{
    public sealed class ConferenceContext: DbContext
    {
        public DbSet<Conference> Conference { get; set; }
        public DbSet<MembreComite> MembreComite { get; set; }
        public DbSet<Participant> Participant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>().ToTable("conference");
            modelBuilder.Entity<MembreComite>().ToTable("membreComite");
            modelBuilder.Entity<Participant>().ToTable("participant");

            //modelBuilder.Entity<MembreComite>()
            //    .HasKey(m => m.MembreID);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst;MultipleActiveResultSets=True");
        }
    }
}
