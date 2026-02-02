using Core.Entities.Spells;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Data.Configs;

public class SpellConfig : IEntityTypeConfiguration<Spell>
{
    public void Configure(EntityTypeBuilder<Spell> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
        builder.Property(s => s.Description).IsRequired();
        builder.Property(s => s.School).HasMaxLength(100);
        builder.Property(s => s.Level).IsRequired();
        builder.Property(s => s.Range).IsRequired();
        builder.Property(s => s.IsConcentration).IsRequired();
        builder.Property(s => s.IsDuration).IsRequired();
        builder.Property(s => s.IsRitual).IsRequired();

        builder.HasMany(x => x.SpellbookSpells)
            .WithOne(x => x.Spell)
            .HasForeignKey(x => x.SpellId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
