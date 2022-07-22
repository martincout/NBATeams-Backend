using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NBATeams.Data.Models;

namespace NBATeams.Data.Data
{
    public class NBATeamsDbContext : IdentityDbContext<
        User, AppRole, int,
        IdentityUserClaim<int>, AppRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IConfiguration _configuration;
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<CustomTeam> CustomTeam { get; set; }
        public DbSet<Stat> Stats { get; set; }

        public NBATeamsDbContext(DbContextOptions<NBATeamsDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NBATeams;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Delete behaviour of Game with two Teams.
            modelBuilder.Entity<Game>()
                .HasOne(t => t.Local)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(t => t.Visit)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
