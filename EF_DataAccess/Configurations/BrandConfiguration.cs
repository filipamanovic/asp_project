using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(30);
            builder.HasIndex(b => b.Name).IsUnique();
            builder.Property(b => b.State).IsRequired().HasMaxLength(30);
            builder.Property(b => b.City).IsRequired().HasMaxLength(30);
            builder.Property(b => b.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
