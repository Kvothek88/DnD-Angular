using Core.Entities.ASI;
using Core.Entities.Features;
using Core.Entities.Prerequisites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class PrerequisiteConfig : IEntityTypeConfiguration<Prerequisite>
{
    public void Configure(EntityTypeBuilder<Prerequisite> builder)
    {
        builder.HasKey(p => new { p.OwnerType, p.OwnerId, p.GroupId, p.Type });

        builder.HasOne<Feat>()
            .WithMany(f => f.Prerequisites)
            .HasForeignKey(p => p.OwnerId)
            .HasConstraintName("FK_Feat_Prerequisites_OwnerId")
            .IsRequired(false); // Only required when OwnerType = Feat

        builder.HasOne<Feature>()
            .WithMany(f => f.Prerequisites)
            .HasForeignKey(p => p.OwnerId)
            .HasConstraintName("FK_Feature_Prerequisites_OwnerId")
            .IsRequired(false); // Only required when OwnerType = Feature
    }
}
