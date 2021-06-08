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
    class KnowledgeInfoConfiguration : IEntityTypeConfiguration<KnowledgeInfo>
    {
        public void Configure(EntityTypeBuilder<KnowledgeInfo> builder)
        {
            builder.ToTable("KnowledgeInfo");

            builder.HasKey(nameof(KnowledgeInfo.Id));

            builder.Property(nameof(KnowledgeInfo.Id))
                .ValueGeneratedOnAdd();

            builder
                .Property(nameof(KnowledgeInfo.Title))
                .IsRequired();

            builder
                .Property(nameof(KnowledgeInfo.Score))
                .HasMaxLength(10)
                .HasDefaultValue(1)
                .IsRequired();

            builder.HasCheckConstraint("CK_Score", "Score >= 1 AND Score <= 10");
        }
    }
}
