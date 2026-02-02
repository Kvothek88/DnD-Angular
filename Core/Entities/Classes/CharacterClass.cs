using Core.Entities.Features;

namespace Core.Entities.Classes;

public class CharacterClass : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int HitDice { get; set; }
    public bool IsSpellcaster { get; set; }

    public List<CharacterSubclass> Subclasses { get; set; } = [];

    public List<CharacterClassPrimaryProficiency> PrimaryProficiencies { get; set; } = [];
    public List<CharacterClassMulticlassProficiency> MulticlassProficiencies { get; set; } = [];
    public List<CharacterClassFeature> Features { get; set; } = [];
}
