using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(a => a.AdName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.AdDescription).HasMaxLength(500);
            builder.Property(a => a.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.City).IsRequired().HasMaxLength(40);

            builder.HasOne(f => f.Fuel)
                .WithMany(f => f.Advertisements)
                .HasForeignKey(a => a.FuelId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(a => a.CarBody)
                .WithMany(c => c.Advertisements)
                .HasForeignKey(a => a.CarBodyId)
                .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(u => u.User)
                .WithMany(u => u.Advertisements)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(a => a.AdCarEquipments)
                .WithOne(ca => ca.Advertisement)
                .HasForeignKey(ca => ca.AdvertisementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
