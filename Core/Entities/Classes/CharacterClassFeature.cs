using Core.Entities.Features;

namespace Core.Entities.Classes;

public class CharacterClassFeature
{
    public int CharacterClassId { get; set; }
    public CharacterClass CharacterClass { get; set; } = null!;

    public int FeatureId { get; set; }
    public Feature Feature { get; set; } = null!;
}
