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
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable("Rate");

            builder.HasKey(nameof(Rate.Id));

            builder
                .Property(nameof(Rate.Id))
                .ValueGeneratedOnAdd();

            builder
                .Property(nameof(Rate.WorkDate))
                .IsRequired();

            builder
                .Property(nameof(Rate.WorkTime))
                .IsRequired();

            builder
                .Property(nameof(Rate.Prices))
                .IsRequired();
        }
    }
}
