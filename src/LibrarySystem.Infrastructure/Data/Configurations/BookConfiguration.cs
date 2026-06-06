using LibrarySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);

            builder.Property(x => x.Author).IsRequired().HasMaxLength(150);

            builder.Property(x => x.ISBN).IsRequired().HasMaxLength(20);

            builder.HasIndex(x => x.ISBN).IsUnique();

            builder.Property(x => x.Price).HasPrecision(18, 2);

            builder.Property(x => x.Genre).IsRequired().HasMaxLength(100);

            builder.Property(x => x.IsAvailable).HasDefaultValue(true);

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");








        }
    }
}
