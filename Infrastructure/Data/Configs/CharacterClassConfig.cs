using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterClassConfig : IEntityTypeConfiguration<CharacterClass>
{
    public void Configure(EntityTypeBuilder<CharacterClass> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(c => c.HitDice)
               .IsRequired();

        builder.Property(c => c.IsSpellcaster)
               .IsRequired();

        builder.HasMany(c => c.Subclasses)
               .WithOne(s => s.Class)
               .HasForeignKey(s => s.ClassId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.PrimaryProficiencies)
               .WithOne(p => p.CharacterClass)
               .HasForeignKey(p => p.CharacterClassId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.MulticlassProficiencies)
               .WithOne(p => p.CharacterClass)
               .HasForeignKey(p => p.CharacterClassId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}


