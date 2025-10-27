using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configs;

public class CharacterSpellConfig : IEntityTypeConfiguration<CharacterSpell>
{
    public void Configure(EntityTypeBuilder<CharacterSpell> builder)
    {
        // Composite Primary Key
        builder.HasKey(cs => new { cs.CharacterId, cs.SpellId });

        // Relationships
        builder.HasOne<Character>()
               .WithMany(c => c.CharacterSpells)
               .HasForeignKey(cs => cs.CharacterId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.Spell)
               .WithMany()
               .HasForeignKey(cs => cs.SpellId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("CharacterSpells");
    }
}
