using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class SubclassAdvancementConfig : IEntityTypeConfiguration<SubclassAdvancement>
{
    public void Configure(EntityTypeBuilder<SubclassAdvancement> builder)
    {
        builder.HasOne(a => a.Character)
            .WithMany(c => c.SubclassAdvancements)
            .HasForeignKey(a => a.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Subclass)
            .WithMany()
            .HasForeignKey(a => a.SubclassId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

