using Core.Entities;
using Core.Entities.ASI;
using Core.Entities.CharacterEntities;
using Core.Entities.Classes;
using Core.Entities.Dictionaries;
using Core.Entities.Features;
using Core.Entities.Prerequisites;
using Core.Entities.Spells;
using Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CharacterDbContext : DbContext
{
    public CharacterDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterAbilities> CharacterAbilities { get; set; }
    public DbSet<CharacterConditions> CharacterConditions { get; set; }
    public DbSet<CharacterSpellSlots> CharacterSpellSlots { get; set; }
    public DbSet<CharacterPhysicalCharacteristics> CharacterPhysicalCharacteristics { get; set; }
    public DbSet<CharacterPreparedSpell> CharacterPreparedSpells { get; set; }
    public DbSet<Spell> Spells { get; set; }
    public DbSet<Spellbook> Spellbooks { get; set; }
    public DbSet<SpellbookSpell> SpellbookSpells { get; set; }

    public DbSet<Race> Races { get; set; }
    public DbSet<Background> Backgrounds { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Feat> Feats { get; set; }
    public DbSet<GrantedProficiency> GrantedProficiencies { get; set; }

    public DbSet<Dictionary> Dictionaries { get; set; }
    public DbSet<DictionaryItem> DictionaryItems { get; set; }
    public DbSet<DictionaryCategory> DictionaryCategories { get; set; }

    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<CharacterSubclass> CharacterSubclasses { get; set; }

    public DbSet<Advancement> Advancements { get; set; }
    public DbSet<ClassAdvancement> ClassAdvancements { get; set; }
    public DbSet<SubclassAdvancement> SubclassAdvancements { get; set; }

    public DbSet<Prerequisite> Prerequisites { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CharacterConfig).Assembly);

        base.OnModelCreating(modelBuilder);

    }
}
