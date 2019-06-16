using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(u => u.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(u => u.Username)
                .HasMaxLength(15)
                .IsRequired();

            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u=>u.Password).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.Comments)
                    .WithOne(u => u.User)
                    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(u => u.Group).WithMany(g => g.Users);

        }
    }


}