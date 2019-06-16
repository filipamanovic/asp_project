using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(m => m.Name).IsUnique();
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasOne(b => b.Brand)
                .WithMany(m => m.Models)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
