using Core.Entities;
using Core.Entities.ASI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class AdvancementConfig : IEntityTypeConfiguration<Advancement>
{
    public void Configure(EntityTypeBuilder<Advancement> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasOne(a => a.Character)
           .WithMany(c => c.Advancements)
           .HasForeignKey(a => a.CharacterId)
           .OnDelete(DeleteBehavior.Cascade);

        // Discriminator column
        builder.HasDiscriminator<string>("AdvancementType")
            .HasValue<FeatAdvancement>("Feat")
            .HasValue<AbilityScoreImprovement>("ASI");
    }
}
