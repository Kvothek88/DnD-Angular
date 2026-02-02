using Core.Entities.Features;

namespace Core.Entities.Classes;

public class CharacterSubclass : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsSpellcaster { get; set; }
    public int ClassId { get; set; }
    public CharacterClass Class { get; set; } = null!;

    public List<CharacterSubclassProficiency> Proficiencies { get; set; } = [];
    public List<CharacterSubclassFeature> Features { get; set; } = [];
}
