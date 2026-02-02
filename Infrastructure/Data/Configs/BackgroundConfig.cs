using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class BackgroundConfig : IEntityTypeConfiguration<Background>
{
    public void Configure(EntityTypeBuilder<Background> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
               .IsRequired()
               .HasMaxLength(100);

        // Proficiencies
        builder.HasMany(b => b.Proficiencies)
               .WithMany()
               .UsingEntity(j => j.ToTable("BackgroundProficiencies"));

        // Feats granted by background
        builder.HasMany(b => b.Feats)
               .WithMany()
               .UsingEntity(j => j.ToTable("BackgroundFeats"));

        // Features granted by background
        builder.HasMany(b => b.Features)
               .WithMany()
               .UsingEntity(j => j.ToTable("BackgroundFeatures"));
    }
}

