using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterClassMulticlassProficiencyConfig : IEntityTypeConfiguration<CharacterClassMulticlassProficiency>
{
    public void Configure(EntityTypeBuilder<CharacterClassMulticlassProficiency> builder)
    {
        builder.HasKey(x => new { x.CharacterClassId, x.GrantedProficiencyId });

        builder.HasOne(x => x.CharacterClass)
               .WithMany(c => c.MulticlassProficiencies)
               .HasForeignKey(x => x.CharacterClassId);

        builder.HasOne(x => x.GrantedProficiency)
               .WithMany()
               .HasForeignKey(x => x.GrantedProficiencyId);
    }
}

