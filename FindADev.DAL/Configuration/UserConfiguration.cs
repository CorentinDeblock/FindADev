using FindADev.DAL.Entities;
using FindADev.DAL.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(nameof(User.Id));

            builder.Property(nameof(User.Id))
                .ValueGeneratedOnAdd();

            builder.Property(nameof(User.Email))
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(nameof(User.Password))
                .IsRequired();

            builder.Property(nameof(User.Role))
                .HasDefaultValue(Role.User);
        }
    }
}
