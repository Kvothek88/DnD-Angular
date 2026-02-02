using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterSubclassConfig : IEntityTypeConfiguration<CharacterSubclass>
{
    public void Configure(EntityTypeBuilder<CharacterSubclass> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.IsSpellcaster)
               .IsRequired();

        builder.HasOne(s => s.Class)
               .WithMany(c => c.Subclasses)
               .HasForeignKey(s => s.ClassId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}




