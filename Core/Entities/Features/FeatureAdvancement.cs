using Core.Entities.Classes;

namespace Core.Entities.Features;

public class FeatureAdvancement : Advancement
{
    public int FeatureId { get; set; }
    public Feature Feature { get; set; }
}
