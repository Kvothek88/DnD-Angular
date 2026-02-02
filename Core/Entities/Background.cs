using Core.Entities.ASI;
using Core.Entities.Features;

namespace Core.Entities;

public class Background : BaseEntity
{
    public required string Name { get; set; }
    public List<GrantedProficiency> Proficiencies { get; set; } = [];
    public List<Feat> Feats { get; set; } = [];
    public List<Feature> Features { get; set; } = [];
}
