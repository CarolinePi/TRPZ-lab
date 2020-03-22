using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Frame> Frames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=master;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>().HasData(new Material() { Id = Guid.NewGuid(), Name = "Wood", Quantity = 21 });
            modelBuilder.Entity<Material>().HasData(new Material() { Id = Guid.NewGuid(), Name = "Iron", Quantity = 18 });
            modelBuilder.Entity<Material>().HasData(new Material() { Id = Guid.NewGuid(), Name = "Black paint", Quantity = 14 });
            modelBuilder.Entity<Material>().HasData(new Material() { Id = Guid.NewGuid(), Name = "Yellow paint", Quantity = 3 });

            //modelBuilder.Entity<Material>().HasData(new Frame() { Id = Guid.NewGuid(), Name = "Standart", Materials = {  } });

            base.OnModelCreating(modelBuilder);
        }
    }
}
