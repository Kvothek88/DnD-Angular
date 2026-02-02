using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterClassFeatureConfig : IEntityTypeConfiguration<CharacterClassFeature>
{
    public void Configure(EntityTypeBuilder<CharacterClassFeature> builder)
    {
        builder.HasKey(ccf => new { ccf.CharacterClassId, ccf.FeatureId });

        builder.HasOne(ccf => ccf.CharacterClass)
               .WithMany(c => c.Features)
               .HasForeignKey(ccf => ccf.CharacterClassId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ccf => ccf.Feature)
               .WithMany()
               .HasForeignKey(ccf => ccf.FeatureId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
