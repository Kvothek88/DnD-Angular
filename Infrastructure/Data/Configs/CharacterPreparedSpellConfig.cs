using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterPreparedSpellConfig : IEntityTypeConfiguration<CharacterPreparedSpell>
{
    public void Configure(EntityTypeBuilder<CharacterPreparedSpell> builder)
    {
        // Composite Primary Key
        builder.HasKey(cs => new { cs.CharacterId, cs.SpellId });

        // Relationships
        builder.HasOne<Character>()
               .WithMany(c => c.CharacterPreparedSpells)
               .HasForeignKey(cs => cs.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.Spell)
               .WithMany()
               .HasForeignKey(cs => cs.SpellId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.CharacterClass)
               .WithMany()
               .HasForeignKey(cs => cs.CharacterClassId);

        builder.ToTable("CharacterPreparedSpells");
    }
}
