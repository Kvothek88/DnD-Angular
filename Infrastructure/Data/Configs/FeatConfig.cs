using Core.Entities.ASI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class FeatConfig : IEntityTypeConfiguration<Feat>
{
    public void Configure(EntityTypeBuilder<Feat> builder)
    {
        builder.HasKey(f => f.Id);

        builder.OwnsMany(f => f.AbilityBonuses, ab =>
        {
            ab.WithOwner().HasForeignKey("FeatId");
            ab.Property<int>("Id");
            ab.HasKey("Id");
            ab.ToTable("FeatAbilityBonuses");
        });
    }
}
