using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterProficiencyConfig : IEntityTypeConfiguration<CharacterProficiency>
{
    public void Configure(EntityTypeBuilder<CharacterProficiency> builder)
    {
        builder.HasKey(cp => cp.Id);

        builder.HasOne(cp => cp.Character)
            .WithMany(c => c.CharacterProficiencies)
            .HasForeignKey(cp => cp.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cp => cp.Proficiency)
            .WithMany()
            .HasForeignKey(cp => cp.ProficiencyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(cp => cp.ProficiencyType)
            .WithMany()
            .HasForeignKey(cp => cp.ProficiencyTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable(cp => cp.HasCheckConstraint(
           "CK_CharacterProficiency_OneOrTheOther",
            @"(ProficiencyId IS NOT NULL AND ProficiencyTypeId IS NULL)
                OR
                (ProficiencyId IS NULL AND ProficiencyTypeId IS NOT NULL)"
            ));
    }
}
