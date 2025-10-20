using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterStatsConfig : IEntityTypeConfiguration<CharacterAbilities>
{
    public void Configure(EntityTypeBuilder<CharacterAbilities> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Strength).IsRequired();
        builder.Property(s => s.Dexterity).IsRequired();
        builder.Property(s => s.Constitution).IsRequired();
        builder.Property(s => s.Intelligence).IsRequired();
        builder.Property(s => s.Wisdom).IsRequired();
        builder.Property(s => s.Charisma).IsRequired();
    }
}
