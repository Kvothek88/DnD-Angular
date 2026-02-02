using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterFeatureConfig : IEntityTypeConfiguration<CharacterFeature>
{
    public void Configure(EntityTypeBuilder<CharacterFeature> builder)
    {
        builder.HasKey(cf => new { cf.CharacterId, cf.FeatureId });

        builder.HasOne<Character>()
               .WithMany(c => c.Features)
               .HasForeignKey(cf => cf.CharacterId);

        builder.HasOne(cf => cf.Feature)
               .WithMany()
               .HasForeignKey(cf => cf.FeatureId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(cf => cf.Source)
               .IsRequired();

        builder.ToTable("CharacterFeatures");
    }
}
