using Core.Entities.CharacterEntities;

namespace Core.Entities.Classes;

public class SubclassAdvancement : BaseEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;

    public int? SubclassId { get; set; }
    public CharacterSubclass? Subclass { get; set; } = null!;

    public int Level { get; set; }
}
