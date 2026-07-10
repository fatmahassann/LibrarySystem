using LibrarySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Data.Configurations
{
    internal class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(100);

            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Address).HasMaxLength(100);

            builder.Property(x => x.PhoneNumber).HasMaxLength(11);

            builder.Property(x => x.IsActive).HasDefaultValue(true);

            builder.Property(x => x.JoinDate).HasDefaultValueSql("GETUTCDATE()");

            builder.Property(x => x.IsDeleted).HasDefaultValue(false);


        }
    }
}
