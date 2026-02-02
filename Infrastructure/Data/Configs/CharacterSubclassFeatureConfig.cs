using Core.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configs;

public class CharacterSubclassFeatureConfig : IEntityTypeConfiguration<CharacterSubclassFeature>
{
    public void Configure(EntityTypeBuilder<CharacterSubclassFeature> builder)
    {
        builder.HasKey(x => new { x.CharacterSubclassId, x.FeatureId });

        builder.HasOne(x => x.CharacterSubclass)
               .WithMany(s => s.Features)
               .HasForeignKey(x => x.CharacterSubclassId);

        builder.HasOne(x => x.Feature)
               .WithMany()
               .HasForeignKey(x => x.FeatureId);
    }
}
