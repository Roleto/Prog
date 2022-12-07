using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MainApp.Models.DBModels
{
    public class StrongholdDbContext : DbContext
    {
        public DbSet<Warehouse> Warehouse { get; set; }

        public DbSet<Blacksmith> Blacksmith { get; set; }

        public DbSet<Generalstore> Generalstore { get; set; }

        public DbSet<Recepie> Recepies { get; set; }

        public StrongholdDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                .UseInMemoryDatabase("stronghold")
                .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>();

            modelBuilder.Entity<Blacksmith>(bl => bl
            .HasOne<Blacksmith>()
            .WithMany()
            .HasForeignKey(warehouese => warehouese.MaterialId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Generalstore>(gs => gs
            .HasOne<Blacksmith>()
            .WithMany()
            .HasForeignKey(warehouese => warehouese.MaterialId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Recepie>(recepie => recepie
            .HasOne<Blacksmith>()
            .WithMany()
            .HasForeignKey(warehouse => warehouse.MaterialId)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Warehouse>().HasData(new Warehouse[]
            {
                // Id;Name;MaterialType;Price;Quantity
                new Warehouse("1;Wheet;Food;10;1000"),
                new Warehouse("2;Iron;Ore;1000;10"),
                new Warehouse("3;Wood;Resource;100;100"),
                new Warehouse("4;Stone;Resource;10;100"),
                new Warehouse("5;Bronze;Ore;1100;80"),
                new Warehouse("6;Silver;Ore;1500;50"),
                new Warehouse("7;Gold;Ore;2000;25"),
                new Warehouse("8;Apple;Food;15;100"),
                new Warehouse("9;Meat;Food;15;100"),
            });
            modelBuilder.Entity<Blacksmith>().HasData(new Blacksmith[]
            {
                // Id;MaterialId;Name;IsDamaged;Price;Quality;
                new Blacksmith("1;2;Iron Sword;False;1000;7"),
                new Blacksmith("2;5;Bronze Sword;False;1300;5"),
                new Blacksmith("3;6;Silver Necklace;False;2000;4"),
                new Blacksmith("4;7;Golden Ring;False;1500;7"),
                new Blacksmith("5;2;Iron Sword;True;1000;9"),
                new Blacksmith("6;2;Iron Sword;True;1000;3"),
                new Blacksmith("7;5;Bronze Sword;True;1300;2"),
                new Blacksmith("8;5;Bronze Sword;True;1300;6"),
                new Blacksmith("9;5;Bronze Sword;True;1300;8"),

            });
            modelBuilder.Entity<Generalstore>().HasData(new Generalstore[]
            {
                // Id;MaterialId;Name;Price;Quality;ExpiringDate
                new Generalstore("1;1;Bread;100;3;14"),
                new Generalstore("2;3;Barel;200;5;null"),
                new Generalstore("3;4;Wall;250;6;null"),
                new Generalstore("4;8;ApplePie;50;5;7"),
                new Generalstore("5;9;Beef Jerky;60;5;20"),
                new Generalstore("6;9;Beef Stew;100;3;5"),
                new Generalstore("7;1;Bread;100;7;10"),
                new Generalstore("8;8;ApplePie;50;6;3"),
                new Generalstore("9;9;Beef Stew;100;8;2"),
                new Generalstore("10;9;Beef Jerky;60;9;10")
            });
            modelBuilder.Entity<Recepie>().HasData(new Recepie[]
            {
                // RecepieId;RecepieName;MaterialId;MaterialQuatity
                new Recepie("1;Bread;1;3"),
                new Recepie("2;Barrel;3;5"),
                new Recepie("3;Wall;4;6"),
                new Recepie("4;ApplePie;8;5"),
                new Recepie("5;Beef Jerky;9;1"),
                new Recepie("6;Beef Stew;9;5"),
                new Recepie("7;Ham;9;5"),
                new Recepie("8;Iron Sword;2;2"),
                new Recepie("9;Bronze Sword;5;3"),
                new Recepie("10;Silver Necklace;6;3"),
                new Recepie("11;Silver Ring;6;1"),
                new Recepie("12;Golden Necklance;7;3"),
                new Recepie("13;Golden Ring;7;1"),
            });
        }
    }
}
