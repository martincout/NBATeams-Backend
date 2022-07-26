using Microsoft.EntityFrameworkCore;
using NBATeams.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Data.Data
{
    public class NBATeamsDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CustomTeam> CustomTeams { get; set; }
        public DbSet<OfficialTeam> OfficialTeams { get; set; }
        public DbSet<Stat> Stats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NBATeams;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Delete behaviour of Game with two Teams.
            modelBuilder.Entity<Game>()
                .HasOne<OfficialTeam>(t => t.Local)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne<OfficialTeam>(t => t.Visit)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
