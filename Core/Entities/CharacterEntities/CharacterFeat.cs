using Core.Entities.ASI;

namespace Core.Entities.CharacterEntities;

public class CharacterFeat : BaseEntity
{
    public int CharacterId { get; set; }

    public int FeatId { get; set; }
    public Feat Feat { get; set; } = null!;
}

