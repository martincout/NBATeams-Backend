using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NBATeams.Data.Models;

namespace NBATeams.Data.Data
{
    public class NBATeamsDbContext : IdentityDbContext<
        AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, 
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
        public NBATeamsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NBATeams;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Delete behaviour of Game with two Teams.
            modelBuilder.Entity<Game>()
                .HasOne(t => t.Local)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(t => t.Visit)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            modelBuilder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();


            modelBuilder.Entity<AppRole>().HasData(
                 new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMINISTRATOR" },
                 new AppRole { Id = 2, Name = "User", NormalizedName = "USER" }
                );

            var user = new AppUser()
            {
                Id = 1,
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM"
            };

            modelBuilder.Entity<AppUser>().HasData(user);

            var passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123$.");

            var userRole = new AppUserRole() { UserId = 1, RoleId = 1 };

            modelBuilder.Entity<AppUserRole>().HasData(userRole);

        }
    }
}
