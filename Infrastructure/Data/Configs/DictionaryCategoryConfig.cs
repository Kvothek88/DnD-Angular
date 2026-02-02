using Core.Entities.Dictionaries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configs;

public class DictionaryCategoryConfig : IEntityTypeConfiguration<DictionaryCategory>
{
    public void Configure(EntityTypeBuilder<DictionaryCategory> builder)
    {
        builder.HasKey(dc => dc.Id);

        builder.Property(di => di.Name).IsRequired();

        builder.HasMany(dc => dc.Dictionaries)
            .WithOne(d => d.Category)
            .HasForeignKey(d => d.CategoryId);
    }
}
