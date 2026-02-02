using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterSpellSlotsConfig : IEntityTypeConfiguration<CharacterSpellSlots>
{
    public void Configure(EntityTypeBuilder<CharacterSpellSlots> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.MaxLevel1).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel2).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel3).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel4).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel5).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel6).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel7).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel8).HasDefaultValue(0);
        builder.Property(s => s.MaxLevel9).HasDefaultValue(0);

        builder.Property(s => s.UsedLevel1).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel2).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel3).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel4).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel5).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel6).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel7).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel8).HasDefaultValue(0);
        builder.Property(s => s.UsedLevel9).HasDefaultValue(0);

        builder.HasIndex(s => s.CharacterId).IsUnique();
    }
}
