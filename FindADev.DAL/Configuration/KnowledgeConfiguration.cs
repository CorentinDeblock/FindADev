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
    public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.ToTable("Knowledge");

            builder.HasKey(nameof(Knowledge.Id));

            builder.Property(nameof(Knowledge.Id))
                .ValueGeneratedOnAdd();

            builder
                .Property(nameof(Knowledge.Type))
                .IsRequired();

            builder
                .HasMany(k => k.Titles)
                .WithOne(k => k.Knowledge)
                .HasForeignKey(k => k.KnowledgeId);
        }
    }
}
