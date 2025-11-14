using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Data.Configs;

public class SpellbookConfig : IEntityTypeConfiguration<Spellbook>
{
    public void Configure(EntityTypeBuilder<Spellbook> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(x => x.SpellbookSpells)
            .WithOne(x => x.Spellbook)
            .HasForeignKey(x => x.SpellbookId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
