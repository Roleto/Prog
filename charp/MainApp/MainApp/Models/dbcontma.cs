using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MainApp.Models
{
    public partial class dbcontma : DbContext
    {
        public dbcontma()
        {
        }

        public dbcontma(DbContextOptions<dbcontma> options)
            : base(options)
        {
        }

        public virtual DbSet<Blacksmith> Blacksmiths { get; set; } = null!;
        public virtual DbSet<Generalstore> Generalstores { get; set; } = null!;
        public virtual DbSet<Recepie> Recepies { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database1.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blacksmith>(entity =>
            {
                entity.ToTable("Blacksmith");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Damaged)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Blacksmiths)
                    .HasForeignKey(d => d.MaterialId)
                    .HasConstraintName("FK_Blacksmith_ToWarehouse");
            });

            modelBuilder.Entity<Generalstore>(entity =>
            {
                entity.ToTable("Generalstore");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Generalstores)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Generalstore_ToWarehouse");
            });

            modelBuilder.Entity<Recepie>(entity =>
            {
                entity.ToTable("Recepie");

                entity.Property(e => e.RecepieId).ValueGeneratedNever();

                entity.Property(e => e.RecepieName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.Recepies)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recepies_ToWarehouse");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MaterialType)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
