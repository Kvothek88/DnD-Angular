using Core.Entities.CharacterEntities;

namespace Core.Entities.ASI;

public class FeatAdvancement : Advancement
{
    public int? FeatId { get; set; }
    public Feat? Feat { get; set; }
}
