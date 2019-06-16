using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(pc => pc.CommentDesc).IsRequired();
            builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETDATE()");


            builder.HasOne(u => u.User)
                  .WithMany(o => o.Comments)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Product)
                  .WithMany(o => o.Comments)
                  .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
