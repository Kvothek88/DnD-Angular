using Core.Entities.Features;

namespace Core.Entities.Classes;

public class CharacterSubclassFeature
{
    public int CharacterSubclassId { get; set; }
    public CharacterSubclass CharacterSubclass { get; set; } = null!;

    public int FeatureId { get; set; }
    public Feature Feature { get; set; } = null!;
}
