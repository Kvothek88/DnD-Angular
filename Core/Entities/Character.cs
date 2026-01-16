using Core.Constants;
using Core.Entities.ASI;
using Core.Entities.Classes;
using Core.Entities.ClassMechanics;
using Core.Entities.Features;
using Core.Enums;

namespace Core.Entities;

public class Character : BaseEntity
{
    public Character()
    {

    }

    // Character Info
    public required string Name { get; set; } = string.Empty;
    public required Race Race { get; set; }
    public required CharacterBackground Background { get; set; }
    public required string Religion { get; set; } = string.Empty;
    public required string Class { get; set; } = string.Empty;
    public required string Subclass { get; set; } = string.Empty;
    public required string Size { get; set; } = string.Empty;
    public required string Alignment { get; set; } = string.Empty;
    public required int Level { get; set; }
    public  string? ImageFrame {  get; set; }

    public CharacterAbilities CharacterAbilities { get; set; } = null!;
    public CharacterSpellSlots? CharacterSpellSlots { get; set; } = null!;
    public List<CharacterPreparedSpell>? CharacterPreparedSpells { get; set; } = [];
    public CharacterPhysicalCharacteristics PhysicalCharacteristics { get; set; } = null!;
    public List<CharacterProficiency> CharacterProficiencies { get; set; } = [];
    public List<ClassAdvancement> ClassAdvancements { get; set; } = [];
    public List<SubclassAdvancement> SubclassAdvancements { get; set; } = [];
    public List<Feat> GeneralFeats { get; set; } = [];


    // All Features
    public List<Feature> Features => [.. Background.Features
        .Concat(Race.Features)
        .Concat(Advancements.OfType<FeatureAdvancement>().Select(fa => fa.Feature))
        .Distinct()];


    // ASI
    public List<Advancement> Advancements { get; set; } = [];
    public List<Feat> Feats => Advancements.Select(a => a switch
    {
        FeatAdvancement f => f.Feat,
        _ => null
    })
    .Where(f => f != null)
    .Concat(GeneralFeats)
    .Concat(Background.Feats)
    .ToList();


    // Calculated abilities
    public int GetBaseAbilityScore(AbilityEnum ability)
    {
        return CharacterAbilities switch
        {
            _ => ability switch
            {
                AbilityEnum.Strength => CharacterAbilities.Strength,
                AbilityEnum.Dexterity => CharacterAbilities.Dexterity,
                AbilityEnum.Constitution => CharacterAbilities.Constitution,
                AbilityEnum.Intelligence => CharacterAbilities.Intelligence,
                AbilityEnum.Wisdom => CharacterAbilities.Wisdom,
                AbilityEnum.Charisma => CharacterAbilities.Charisma,
                _ => throw new ArgumentOutOfRangeException()
            }
        };
    }

    public int GetAbilityScore(AbilityEnum ability)
    {
        var baseScore = GetBaseAbilityScore(ability);

        // ASIs + level-up feat bonuses
        var advancementBonus = Advancements.Sum(a => a switch
        {
            AbilityScoreImprovement asi => asi.AbilityBonuses.Where(b => b.Ability == ability).Sum(b => b.Amount),
            FeatAdvancement feat => feat.Feat.AbilityBonuses?.Where(b => b.Ability == ability).Sum(b => b.Amount) ?? 0,
            _ => 0
        });

        var featuresBonus = Features
            .Where(f => f.AbilityBonuses != null)
            .SelectMany(f => f.AbilityBonuses)
            .Where(b => b.Ability == ability)
            .Sum(b => b.Amount);

        // Origin/race/general feats
        var generalBonus = GeneralFeats.Sum(f => f.AbilityBonuses?.Where(b => b.Ability == ability).Sum(b => b.Amount) ?? 0);

        return baseScore + advancementBonus + generalBonus;
    }

    public int Strength => GetAbilityScore(AbilityEnum.Strength);
    public int Dexterity => GetAbilityScore(AbilityEnum.Dexterity);
    public int Constitution => GetAbilityScore(AbilityEnum.Constitution);
    public int Intelligence => GetAbilityScore(AbilityEnum.Intelligence);
    public int Wisdom => GetAbilityScore(AbilityEnum.Wisdom);
    public int Charisma => GetAbilityScore(AbilityEnum.Charisma);

    public int StrengthModifier => (int)Math.Floor((decimal)(Strength - 10) / 2);
    public int DexterityModifier => (int)Math.Floor((decimal)(Dexterity - 10) / 2);
    public int ConstitutionModifier => (int)Math.Floor((decimal)(Constitution - 10) / 2);
    public int IntelligenceModifier => (int)Math.Floor((decimal)(Intelligence - 10) / 2);
    public int WisdomModifier => (int)Math.Floor((decimal)(Wisdom - 10) / 2);
    public int CharismaModifier => (int)Math.Floor((decimal)(Charisma - 10) / 2);


    // Other stats
    public int HitDice { get; set; }
    public int MaxHp => HitDice + ((Level - 1) * (HitDice / 2 + 1)) + (CharacterAbilities.ConstitutionModifier * Level) + Level;
    public int CurrentHp { get; set; }

    public int ProficiencyBonus => (int)Math.Ceiling(Level / 4.0) + 1;
    public int Initiative => CharacterAbilities.DexterityModifier;
    public int BaseSpeed => Race.Speed;
    public int Speed { get; set; }


    // Class-specific objects
    public Spellbook? Spellbook { get; set; }                  // Wizard
    public List<FightingStyleSelection>? FightingStyles { get; set; } // Fighter, Ranger
    public BardicInspiration? BardicInspiration { get; set; }  // Bard
    public KiPoints? Ki { get; set; }                          // Monk
    public SorceryPoints? Sorcery { get; set; }               // Sorcerer
    public ChannelDivinity? ChannelDivinity { get; set; }     // Cleric
    public Rage? Rage { get; set; }                            // Barbarian
    public ArcaneTradition? ArcaneTradition { get; set; }      // Wizard subclass example


    public void InitializeDerivedValues()
    {
        // Populate HitDice based on Class
        if (CharacterDefaults.ClassHitDice.TryGetValue(Class, out var hitDice))
            HitDice = hitDice;
        else
            HitDice = 8;


        // Initialize CurrentHp
        CurrentHp = MaxHp;
    }
}
