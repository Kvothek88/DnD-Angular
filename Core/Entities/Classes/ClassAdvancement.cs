using Core.Entities.CharacterEntities;

namespace Core.Entities.Classes;

public class ClassAdvancement : BaseEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;

    public int? ClassId { get; set; }
    public CharacterClass? Class { get; set; } = null!;

    public int Level { get; set; }
    public ClassEntryType? EntryType { get; set; }
}
