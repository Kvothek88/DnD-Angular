using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class RaceConfig : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(r => r.Size)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(r => r.Speed)
               .IsRequired();

        builder.HasMany(r => r.Proficiencies)
               .WithMany()
               .UsingEntity(j => j.ToTable("RaceProficiencies"));

        builder.HasMany(r => r.Feats)
               .WithMany()
               .UsingEntity(j => j.ToTable("RaceFeats"));

        builder.HasMany(r => r.Features)
               .WithMany()
               .UsingEntity(j => j.ToTable("RaceFeatures"));

        builder.HasMany(r => r.Spells)
               .WithMany()
               .UsingEntity(j => j.ToTable("RaceSpells"));
    }
}
