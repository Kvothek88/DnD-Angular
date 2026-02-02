using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterPhysicalCharacteristicsConfig
    : IEntityTypeConfiguration<CharacterPhysicalCharacteristics>
{
    public void Configure(EntityTypeBuilder<CharacterPhysicalCharacteristics> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(pc => pc.Character)
           .WithOne(c => c.PhysicalCharacteristics)
           .HasForeignKey<CharacterPhysicalCharacteristics>(pc => pc.CharacterId);

        builder.HasIndex(c => c.CharacterId).IsUnique();

        builder.Property(c => c.Hair).HasMaxLength(255);
        builder.Property(c => c.Skin).HasMaxLength(255);
        builder.Property(c => c.Eyes).HasMaxLength(255);

        builder.ToTable("CharacterPhysicalCharacteristics");
    }
}

