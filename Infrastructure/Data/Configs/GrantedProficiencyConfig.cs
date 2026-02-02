using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class GrantedProficiencyConfig : IEntityTypeConfiguration<GrantedProficiency>
{
    public void Configure(EntityTypeBuilder<GrantedProficiency> builder)
    {
        builder.HasKey(cp => cp.Id);

        builder.HasOne(cp => cp.Proficiency)
            .WithMany()
            .HasForeignKey(cp => cp.ProficiencyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(cp => cp.ProficiencyType)
            .WithMany()
            .HasForeignKey(cp => cp.ProficiencyTypeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(cp => cp.ProficiencyCategory)
            .WithMany()
            .HasForeignKey(cp => cp.ProficiencyCategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(p => p.ClassPrimaryProficiencies)
               .WithOne(cp => cp.GrantedProficiency)
               .HasForeignKey(cp => cp.GrantedProficiencyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.ClassMulticlassProficiencies)
               .WithOne(cp => cp.GrantedProficiency)
               .HasForeignKey(cp => cp.GrantedProficiencyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.SubclassProficiencies)
               .WithOne(sp => sp.GrantedProficiency)
               .HasForeignKey(sp => sp.GrantedProficiencyId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(tb =>
        {
            tb.HasCheckConstraint(
                "CK_GrantedProficiency_ExactlyOneTarget",
                "(ProficiencyId IS NOT NULL AND ProficiencyTypeId IS NULL) " +
                "OR (ProficiencyId IS NULL AND ProficiencyTypeId IS NOT NULL)"
            );
        });
    }
}
