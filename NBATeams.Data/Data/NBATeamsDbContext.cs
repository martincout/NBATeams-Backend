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
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CustomTeam> CustomTeam { get; set; }
        public DbSet<Stat> Stats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FBL8M17\SQLEXPRESS;Initial Catalog=nbaProjectTests;Integrated Security=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Delete behaviour of Game with two Teams.
            modelBuilder.Entity<Game>()
                .HasOne<Team>(t => t.Local)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne<Team>(t => t.Visit)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
