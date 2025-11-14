using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class SpellbookSpellConfig : IEntityTypeConfiguration<SpellbookSpell>
{
    public void Configure(EntityTypeBuilder<SpellbookSpell> builder)
    {
        builder.HasKey(x => new { x.SpellId, x.SpellbookId });
    }
}
