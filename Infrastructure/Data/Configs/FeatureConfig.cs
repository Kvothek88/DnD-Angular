using Core.Entities.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class FeatureConfig : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.HasKey(f => f.Id);

        builder.OwnsMany(f => f.AbilityBonuses, ab =>
        {
            ab.WithOwner().HasForeignKey("FeatureId");
            ab.Property<int>("Id");
            ab.HasKey("Id");
            ab.ToTable("FeatureAbilityBonuses");
        });
    }
}
