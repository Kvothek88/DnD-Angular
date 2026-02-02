using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterAbilitiesConfig : IEntityTypeConfiguration<CharacterAbilities>
{
    public void Configure(EntityTypeBuilder<CharacterAbilities> builder)
    {
        builder.HasKey(ca => ca.Id);

        builder.HasOne(ca => ca.Character)
           .WithOne(c => c.CharacterAbilities)
           .HasForeignKey<CharacterAbilities>(ca => ca.CharacterId)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Property(ca => ca.Strength).IsRequired();
        builder.Property(ca => ca.Dexterity).IsRequired();
        builder.Property(ca => ca.Constitution).IsRequired();
        builder.Property(ca => ca.Intelligence).IsRequired();
        builder.Property(ca => ca.Wisdom).IsRequired();
        builder.Property(ca => ca.Charisma).IsRequired();

        builder.HasIndex(ca => ca.CharacterId).IsUnique();
    }
}
