using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterConfig : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(255);
        builder.Property(c => c.Race).HasMaxLength(255);
        builder.Property(c => c.Background).HasMaxLength(255);
        builder.Property(c => c.Religion).HasMaxLength(255);
        builder.Property(c => c.Class).HasMaxLength(255);
        builder.Property(c => c.Subclass).HasMaxLength(255);
        builder.Property(c => c.Size).HasMaxLength(255);
        builder.Property(c => c.Alignment).HasMaxLength(255);

        builder.Property(c => c.Level).IsRequired();

        // One-to-one with CharacterStats
        builder.HasOne(c => c.CharacterAbilities)
               .WithOne()
               .HasForeignKey<CharacterAbilities>(s => s.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        // One-to-one with CharacterSpellSlots
        builder.HasOne(c => c.CharacterSpellSlots)
               .WithOne()
               .HasForeignKey<CharacterSpellSlots>(s => s.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.CharacterPreparedSpells)
               .WithOne()
               .HasForeignKey(cs => cs.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.CharacterProficiencies)
            .WithOne(x => x.Character)
            .HasForeignKey(x => x.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
