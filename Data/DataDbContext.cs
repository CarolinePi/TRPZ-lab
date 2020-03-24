using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataDbContext : DbContext
    {
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<FrameModel> Frames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=FrameDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var f1 = new FrameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Standart"
            };
            var f2 = new FrameModel()
            {
                Id = Guid.NewGuid(),
                Name = "Original",
            };
            modelBuilder.Entity<FrameModel>().HasData(f1);
            modelBuilder.Entity<FrameModel>().HasData(f2);
            var m1 = new MaterialModel() { Id = Guid.NewGuid(), Name = "Wood", Quantity = 21, FrameModelId = f1.Id};
            var m2 = new MaterialModel() { Id = Guid.NewGuid(), Name = "Iron", Quantity = 18, FrameModelId = f1.Id};
            var m3 = new MaterialModel() { Id = Guid.NewGuid(), Name = "Black paint", Quantity = 14, FrameModelId = f2.Id};
            var m4 = new MaterialModel() { Id = Guid.NewGuid(), Name = "Yellow paint", Quantity = 3, FrameModelId = f2.Id};
            modelBuilder.Entity<MaterialModel>().HasData(m1);
            modelBuilder.Entity<MaterialModel>().HasData(m2);
            modelBuilder.Entity<MaterialModel>().HasData(m3);
            modelBuilder.Entity<MaterialModel>().HasData(m4);


            base.OnModelCreating(modelBuilder);
        }
    }
}
