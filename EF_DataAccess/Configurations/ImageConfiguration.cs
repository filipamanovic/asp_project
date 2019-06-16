using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF_DataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.Src).IsRequired().HasMaxLength(100);
            builder.HasIndex(i => i.Src).IsUnique();
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
