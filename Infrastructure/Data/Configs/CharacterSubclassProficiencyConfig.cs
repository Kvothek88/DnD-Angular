using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterSubclassProficiencyConfig : IEntityTypeConfiguration<CharacterSubclassProficiency>
{
    public void Configure(EntityTypeBuilder<CharacterSubclassProficiency> builder)
    {
        builder.HasKey(x => new { x.CharacterSubclassId, x.GrantedProficiencyId });

        builder.HasOne(x => x.CharacterSubclass)
               .WithMany(s => s.Proficiencies)
               .HasForeignKey(x => x.CharacterSubclassId);

        builder.HasOne(x => x.GrantedProficiency)
               .WithMany()
               .HasForeignKey(x => x.GrantedProficiencyId);
    }
}


