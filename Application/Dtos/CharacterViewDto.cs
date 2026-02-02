using Core.Entities;
using Core.Entities.ASI;
using Core.Entities.CharacterEntities;
using Core.Entities.Features;

namespace Application.Dtos;

public class CharacterViewDto
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required ReferenceViewDto Race { get; set; }
    public required ReferenceViewDto Background { get; set; }
    public required string Religion { get; set; } = string.Empty;
    public required string Class { get; set; } = string.Empty;
    public required string Subclass { get; set; } = string.Empty;
    public required string Size { get; set; } = string.Empty;
    public required string Alignment { get; set; } = string.Empty;
    public required int Level { get; set; }
    public string? ImageFrame { get; set; }

    public CharacterAbilitiesViewDto TotalCharacterAbilities { get; set; } = null!;
    public CharacterSpellSlots? CharacterSpellSlots { get; set; } = null!;
    public List<SpellViewDto>? CharacterPreparedSpells { get; set; }
    public CharacterPhysicalCharacteristics PhysicalCharacteristics { get; set; } = null!;
    public List<Feature> Features { get; set; } = [];
    public List<Feat> Feats { get; set; } = [];
    public List<GrantedProficiency> Proficiencies { get; set; } = [];

    public int MaxHp { get; set; }
    public int NegativeHp { get; set; }
    public int CurrentHp { get; set; }
    public int TempHp { get; set; }
    public int Initiative { get; set; }
    public int ProficiencyBonus { get; set; }

    // Class-specific properties
    //public Spellbook? Spellbook { get; set; }                  // Wizard
    //public List<FightingStyleSelection>? FightingStyles { get; set; } // Fighter, Ranger
    //public BardicInspiration? BardicInspiration { get; set; }  // Bard
    //public KiPoints? Ki { get; set; }                          // Monk
    //public SorceryPoints? Sorcery { get; set; }               // Sorcerer
    //public ChannelDivinity? ChannelDivinity { get; set; }     // Cleric
    //public Rage? Rage { get; set; }                            // Barbarian
    //public ArcaneTradition? ArcaneTradition { get; set; }      // Wizard subclass example
}
