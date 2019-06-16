using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(40).IsRequired();
            builder.HasIndex(p => p.Name).IsUnique();

            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.CategoryProducts)
                .WithOne(cp => cp.Category)
                .HasForeignKey(cp => cp.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
