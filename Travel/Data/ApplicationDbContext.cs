using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel.Data.Mappers;
using Travel.Models;

namespace Travel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TravelList> TravelLists { get; set; }
        public DbSet<TravelItem> TravelItems { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TravelListConfiguration());
            modelBuilder.ApplyConfiguration(new TravelItemConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
