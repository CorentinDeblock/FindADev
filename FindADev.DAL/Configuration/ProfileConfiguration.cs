using FindADev.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.DAL.Configuration
{
    class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");

            builder.HasKey(nameof(Profile.Id));

            builder.Property(nameof(Profile.Id))
                .ValueGeneratedOnAdd();

            builder.Property(nameof(Profile.Image));

            builder.Property(nameof(Profile.ImageMimeType))
                .HasMaxLength(50);

            builder
                .HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId);

            builder
                .HasOne(p => p.Rate)
                .WithOne(p => p.Profile)
                .HasForeignKey<Rate>(r => r.ProfileId);

            builder
                .HasMany(p => p.Knowledges)
                .WithOne(p => p.Profile)
                .HasForeignKey(p => p.ProfileId);
        }
    }
}
