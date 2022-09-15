using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MainApp.Models.DBModels
{
    public partial class BikeDbContext : DbContext
    {
        public BikeDbContext()
        {
        }

        public BikeDbContext(DbContextOptions<BikeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Extra> Extras { get; set; } = null!;
        public virtual DbSet<Model> Models { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\BikeshopDB.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.BrandName)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Extra>(entity =>
            {
                entity.Property(e => e.ExtraId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Price)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Extras)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_Extras_ToModel");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Model");

                entity.Property(e => e.ModelId).ValueGeneratedNever();

                entity.Property(e => e.ModelName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("Models_Brand_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
