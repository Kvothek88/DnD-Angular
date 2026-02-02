using Core.Entities;
using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class ClassAdvancementConfig : IEntityTypeConfiguration<ClassAdvancement>
{
    public void Configure(EntityTypeBuilder<ClassAdvancement> builder)
    {
        builder.HasOne(a => a.Character)
            .WithMany(c => c.ClassAdvancements)
            .HasForeignKey(a => a.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Class)
            .WithMany()
            .HasForeignKey(a => a.ClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

