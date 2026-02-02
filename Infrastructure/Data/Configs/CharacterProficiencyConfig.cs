using Core.Entities.CharacterEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configs;

public class CharacterProficiencyConfig : IEntityTypeConfiguration<CharacterProficiency>
{
    public void Configure(EntityTypeBuilder<CharacterProficiency> builder)
    {
        builder.HasKey(cp => cp.Id);

        builder.HasIndex(cp => new { cp.CharacterId, cp.GrantedProficiencyId })
               .IsUnique();

        builder.HasOne<Character>()
               .WithMany(c => c.Proficiencies)
               .HasForeignKey(cp => cp.CharacterId);

        builder.HasOne(cp => cp.GrantedProficiency)
               .WithMany()
               .HasForeignKey(cp => cp.GrantedProficiencyId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("CharacterProficiencies");
    }
}

