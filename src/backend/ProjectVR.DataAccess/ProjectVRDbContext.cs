﻿using Microsoft.EntityFrameworkCore;
using ProjectVR.DataAccess.Models;
using ProjectVR.WebAPI.StaticData;

namespace ProjectVR.DataAccess
{
    public class ProjectVRDbContext : DbContext
    {
        public ProjectVRDbContext(DbContextOptions<ProjectVRDbContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<VrSet> VrSets { get; set; }
        public DbSet<UserInfo> Usersinfo { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<UserVrSet> UserVrSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectVRDbContext).Assembly);
            SeedingData data = new SeedingData();


            modelBuilder.Entity<Game>().HasData(data.Games);

            modelBuilder.Entity<VrSet>().HasData(data.VrSets);

            modelBuilder.Entity<UserInfo>().HasData(data.Users);

            modelBuilder.Entity<UserGame>().HasData(data.UserGames);

            modelBuilder.Entity<UserVrSet>().HasData(data.UserVrSets);


            base.OnModelCreating(modelBuilder);
        }
    }
}
