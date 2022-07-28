﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NBATeams.Data.Data;

#nullable disable

namespace NBATeams.Data.Migrations
{
    [DbContext(typeof(NBATeamsDbContext))]
    partial class NBATeamsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomTeamPlayer", b =>
                {
                    b.Property<int>("CustomTeamsId")
                        .HasColumnType("int");

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.HasKey("CustomTeamsId", "PlayersId");

                    b.HasIndex("PlayersId");

                    b.ToTable("CustomTeamPlayer");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Award");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Court", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Court");
                });

            modelBuilder.Entity("NBATeams.Data.Models.CustomTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Lost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CustomTeam");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateGame")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalId")
                        .HasColumnType("int");

                    b.Property<int>("ScoreLocal")
                        .HasColumnType("int");

                    b.Property<int>("ScoreVisit")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalId")
                        .IsUnique();

                    b.HasIndex("VisitId")
                        .IsUnique();

                    b.ToTable("Games");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("ImageProfilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatsId")
                        .HasColumnType("int");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("StatsId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("APG")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<decimal>("PIE")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PPG")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<decimal>("RPG")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourtId")
                        .HasColumnType("int");

                    b.Property<string>("LogoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Lost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("NBATeams.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CustomTeamPlayer", b =>
                {
                    b.HasOne("NBATeams.Data.Models.CustomTeam", null)
                        .WithMany()
                        .HasForeignKey("CustomTeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBATeams.Data.Models.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NBATeams.Data.Models.Award", b =>
                {
                    b.HasOne("NBATeams.Data.Models.Team", "Team")
                        .WithMany("Awards")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Court", b =>
                {
                    b.HasOne("NBATeams.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("NBATeams.Data.Models.CustomTeam", b =>
                {
                    b.HasOne("NBATeams.Data.Models.User", "User")
                        .WithMany("CustomTeams")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Game", b =>
                {
                    b.HasOne("NBATeams.Data.Models.Team", "Local")
                        .WithOne()
                        .HasForeignKey("NBATeams.Data.Models.Game", "LocalId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("NBATeams.Data.Models.Team", "Visit")
                        .WithOne()
                        .HasForeignKey("NBATeams.Data.Models.Game", "VisitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Local");

                    b.Navigation("Visit");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Player", b =>
                {
                    b.HasOne("NBATeams.Data.Models.Stat", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NBATeams.Data.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.Navigation("Stats");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Team", b =>
                {
                    b.HasOne("NBATeams.Data.Models.Court", "Court")
                        .WithMany()
                        .HasForeignKey("CourtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Court");
                });

            modelBuilder.Entity("NBATeams.Data.Models.Team", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("NBATeams.Data.Models.User", b =>
                {
                    b.Navigation("CustomTeams");
                });
#pragma warning restore 612, 618
        }
    }
}
