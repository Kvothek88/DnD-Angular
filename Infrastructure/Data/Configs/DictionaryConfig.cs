using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class DictionaryConfig : IEntityTypeConfiguration<Dictionary>
{
    public void Configure(EntityTypeBuilder<Dictionary> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(di => di.Name).IsRequired();

        builder.HasMany(d => d.Items)
            .WithOne(di => di.Dictionary)
            .HasForeignKey(d => d.DictionaryId);
    }
}
