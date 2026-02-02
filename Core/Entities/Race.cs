using Core.Entities.ASI;
using Core.Entities.Features;
using Core.Entities.Spells;

namespace Core.Entities;

public class Race : BaseEntity
{
    public required string Name { get; set; }
    public required string Size { get; set; }
    public int Speed { get; set; }
    public List<GrantedProficiency> Proficiencies { get; set; } = [];
    public List<Feat> Feats { get; set; } = [];
    public List<Feature> Features { get; set; } = [];
    public List<Spell> Spells { get; set; } = [];
}
