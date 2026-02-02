using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterConfig : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).HasMaxLength(255);
        builder.Property(c => c.Religion).HasMaxLength(255);
        builder.Property(c => c.Alignment).HasMaxLength(255);
        builder.Property(c => c.Level).IsRequired();
        builder.Property(c => c.ImageFrame).HasMaxLength(255);

        builder.Property(c => c.MaxHp).IsRequired();
        builder.Property(c => c.CurrentHp).IsRequired();
        builder.Property(c => c.TempHp).IsRequired();
        builder.Property(c => c.NegativeHp).IsRequired();
        builder.Property(c => c.Speed).IsRequired();

        // One-to-one
        builder.HasOne(c => c.CharacterSpellSlots)
               .WithOne()
               .HasForeignKey<CharacterSpellSlots>(cs => cs.CharacterId);

        // One to many
        builder.HasOne(c => c.Race)
               .WithMany()
               .HasForeignKey(c => c.RaceId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Background)
               .WithMany()
               .HasForeignKey(c => c.BackgroundId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.ClassAdvancements)
               .WithOne(ca => ca.Character)
               .HasForeignKey(ca => ca.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.SubclassAdvancements)
               .WithOne(sa => sa.Character)
               .HasForeignKey(sa => sa.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Features)
               .WithOne()
               .HasForeignKey(cf => cf.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Feats)
               .WithOne()
               .HasForeignKey(cf => cf.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Proficiencies)
               .WithOne()
               .HasForeignKey(cp => cp.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.CharacterPreparedSpells)
               .WithOne()
               .HasForeignKey(ps => ps.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(c => c.Spellbook);
        builder.Ignore(c => c.FightingStyles);
        builder.Ignore(c => c.BardicInspiration);
        builder.Ignore(c => c.Ki);
        builder.Ignore(c => c.Sorcery);
        builder.Ignore(c => c.ChannelDivinity);
        builder.Ignore(c => c.Rage);
        builder.Ignore(c => c.ArcaneTradition);
    }
}
