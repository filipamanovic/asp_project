using Domain;
using EF_DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess
{
    public class asp_projectContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<CarBody> CarBodies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarEquipment> CarEquipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CF3GPEA\SQLEXPRESS;Initial Catalog=asp_project;Integrated Security=True");
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-CF3GPEA\SQLEXPRESS;Initial Catalog=asp_project_faker;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new ModelConfiguration());
            modelBuilder.ApplyConfiguration(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration(new FuelConfiguration());
            modelBuilder.ApplyConfiguration(new CarBodyConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CarEquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new CarEquipmentAdConfiguration());
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is BaseEntity be)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            be.CreatedAt = DateTime.Now;
                            be.IsDeleted = false;
                            be.ModifiedAt = null;
                            be.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            be.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
