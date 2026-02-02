using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterFeatConfig : IEntityTypeConfiguration<CharacterFeat>
{
    public void Configure(EntityTypeBuilder<CharacterFeat> builder)
    {
        builder.HasKey(cf => cf.Id);

        builder.HasIndex(cf => new { cf.CharacterId, cf.FeatId })
               .IsUnique();

        builder.HasOne<Character>()
               .WithMany(c => c.Feats)
               .HasForeignKey(cf => cf.CharacterId);

        builder.HasOne(cf => cf.Feat)
               .WithMany()
               .HasForeignKey(cf => cf.FeatId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("CharacterFeats");
    }
}

