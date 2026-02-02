using Core.Entities.ASI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class FeatAdvancementConfig : IEntityTypeConfiguration<FeatAdvancement>
{
    public void Configure(EntityTypeBuilder<FeatAdvancement> builder)
    {
        builder.HasOne(a => a.Feat)
               .WithMany()
               .HasForeignKey(a => a.FeatId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
