using Core.Entities;
using Core.Entities.ASI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class AbilityScoreImprovementConfig : IEntityTypeConfiguration<AbilityScoreImprovement>
{
    public void Configure(EntityTypeBuilder<AbilityScoreImprovement> builder)
    {
        builder.OwnsMany(a => a.AbilityBonuses, ab =>
        {
            ab.WithOwner().HasForeignKey("AbilityScoreImprovementId");
            ab.Property<int>("Id");
            ab.HasKey("Id");
            ab.ToTable("ASIAbilityBonuses");
        });
    }
}
