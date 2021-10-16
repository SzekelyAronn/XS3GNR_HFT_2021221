using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XS3GNR_HFT_2021221.Models;

namespace XS3GNR_HFT_2021221.Data
{
    class UnistudfacDBContext : DbContext
    {
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<Faculties> Faculties { get; set; }

        public virtual DbSet<Students> Students { get; set; }

        public UnistudfacDBContext()
        {
            // this.Database.EnsureDeleted();
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\UniDb.mdf;Integrated Security=True;MultipleActiveResultSets=True");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>(entity =>
            {
                entity
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Faculties>(entity =>
            {
                entity
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
}
