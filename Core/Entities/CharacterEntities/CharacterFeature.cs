using Core.Entities.Features;
using Core.Enums;

namespace Core.Entities.CharacterEntities;

public class CharacterFeature
{
    public int CharacterId { get; set; }

    public int FeatureId { get; set; }
    public Feature Feature { get; set; } = null!;

    public bool? UsesSpellSlots { get; set; }
    public int? MaxUses { get; set; }
    public int? RemainingUses { get; set; }

    public RestType? RestType { get; set; }
    public FeatureSource Source { get; set; }
}
