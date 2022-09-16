using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models.DBModels
{
    public class BikeDbContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Extra> Extras { get; set; }

        public BikeDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                .UseInMemoryDatabase("bike")
                .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>();
            
            modelBuilder.Entity<Model>(model => model
            .HasOne<Brand>()
            .WithMany()
            .HasForeignKey(model => model.BrandId)
            .OnDelete(DeleteBehavior.Cascade));
            
            modelBuilder.Entity<Extra>(extra => extra
            .HasOne<Model>()
            .WithMany()
            .HasForeignKey(extra => extra.ModelId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("1;Suzuki"),
                new Brand("2;Bmw"),
                new Brand("3;Honda")
            });

            modelBuilder.Entity<Model>().HasData(new Model[]
            {
                new Model("1;1;Drz 450;Enduro;10000"),
                new Model("1;2;Gsxr 1000;Sport;20000"),
                new Model("1;3;Rmx 450;Enduro;10000")
            });

            modelBuilder.Entity<Extra>().HasData(new Extra[]
            {
                new Extra("1;1;Wheel;500"),
                new Extra("1;2;Exhaust;500")
            });

        }
    }
}
