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
        public DbSet<MembreCO> MembreCO { get; set; }
        public DbSet<Participant> Participant { get; set; }
        public DbSet<MembreCP> MembreCP { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Aptitude> Aptitude { get; set; }
        public DbSet<Note> Note { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>()/*.ToTable("conference")*/;
            modelBuilder.Entity<MembreCO>()/*.ToTable("membreCO")*/;
            modelBuilder.Entity<MembreCP>()/*.ToTable("membreCP")*/;
            modelBuilder.Entity<Participant>()/*.ToTable("participant")*/;
            modelBuilder.Entity<Article>()/*.ToTable("article")*/;
            modelBuilder.Entity<Aptitude>()/*.ToTable("aptitude")*/;
            modelBuilder.Entity<Note>()/*.ToTable("note")*/;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CodeFirst;MultipleActiveResultSets=True");
        }
    }
}
