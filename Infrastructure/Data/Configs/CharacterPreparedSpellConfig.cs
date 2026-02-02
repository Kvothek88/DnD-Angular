using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterPreparedSpellConfig : IEntityTypeConfiguration<CharacterPreparedSpell>
{
    public void Configure(EntityTypeBuilder<CharacterPreparedSpell> builder)
    {
        builder.HasKey(cps => cps.Id);

        builder.HasIndex(cps => new
        {
            cps.CharacterId,
            cps.SpellId,
            cps.CharacterClassId
        })
        .IsUnique();

        // Relationships
        builder.HasOne(ca => ca.Character)
               .WithMany(c => c.CharacterPreparedSpells)
               .HasForeignKey(cs => cs.CharacterId);

        builder.HasOne(cs => cs.Spell)
               .WithMany()
               .HasForeignKey(cs => cs.SpellId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cs => cs.CharacterClass)
               .WithMany()
               .HasForeignKey(cs => cs.CharacterClassId);

        builder.ToTable("CharacterPreparedSpells");
    }
}
