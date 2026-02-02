using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterConditionsConfig : IEntityTypeConfiguration<CharacterConditions>
{
    public void Configure(EntityTypeBuilder<CharacterConditions> builder)
    {
        builder.HasKey(ca => ca.Id);

        builder.HasOne(ca => ca.Character)
           .WithOne(c => c.CharacterConditions)
           .HasForeignKey<CharacterConditions>(ca => ca.CharacterId)
           .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(ca => ca.CharacterId).IsUnique();
    }
}
