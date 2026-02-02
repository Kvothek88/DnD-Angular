using Core.Entities.ASI;
using Core.Entities.Classes;
using Core.Entities.ClassMechanics;
using Core.Entities.Spells;

namespace Core.Entities.CharacterEntities;

public class Character : BaseEntity
{
    // Character Info
    public required string Name { get; set; } = string.Empty;
    public required Race Race { get; set; }
    public int RaceId { get; set; }
    public required Background Background { get; set; }
    public int BackgroundId { get; set; }
    public required string Religion { get; set; } = string.Empty;
    public string Size => Race.Size;
    public required string Alignment { get; set; } = string.Empty;
    public required int Level { get; set; }
    public  string? ImageFrame {  get; set; }

    public CharacterAbilities CharacterAbilities { get; set; } = null!;
    public CharacterConditions CharacterConditions { get; set; } = null!;
    public CharacterSpellSlots? CharacterSpellSlots { get; set; } = null!;
    public CharacterPhysicalCharacteristics PhysicalCharacteristics { get; set; } = null!;
    public List<ClassAdvancement> ClassAdvancements { get; set; } = [];
    public List<SubclassAdvancement> SubclassAdvancements { get; set; } = [];
    public List<Advancement> Advancements { get; set; } = [];
    public List<FeatAdvancement> FeatAdvancements =>
        Advancements.OfType<FeatAdvancement>().ToList();
    public List<AbilityScoreImprovement> ASIAdvancements =>
        Advancements.OfType<AbilityScoreImprovement>().ToList();


    // All features
    public List<CharacterFeature> Features { get; set; } = [];

    // All feats
    public List<CharacterFeat> Feats { get; set; } = [];

    // All Proficiencies
    public List<CharacterProficiency> Proficiencies { get; set; } = [];

    // All Prepared Spells
    public List<CharacterPreparedSpell> CharacterPreparedSpells { get; set; } = [];


    // Other stats
    public int MaxHp { get; set; }
    public int NegativeHp { get; set; }
    public int CurrentHp { get; set; }
    public int TempHp { get; set; }

    public int ProficiencyBonus => (int)Math.Ceiling(Level / 4.0) + 1;

    public int BaseSpeed => Race.Speed;
    public int Speed { get; set; }


    // Class-specific state features
    public Spellbook? Spellbook { get; set; }                  // Wizard
    public List<FightingStyleSelection>? FightingStyles { get; set; } // Fighter, Ranger
    public BardicInspiration? BardicInspiration { get; set; }  // Bard
    public KiPoints? Ki { get; set; }                          // Monk
    public SorceryPoints? Sorcery { get; set; }               // Sorcerer
    public ChannelDivinity? ChannelDivinity { get; set; }     // Cleric
    public Rage? Rage { get; set; }                            // Barbarian
    public ArcaneTradition? ArcaneTradition { get; set; }      // Wizard subclass
}
