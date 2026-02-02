using Core.Entities.Classes;
using Core.Entities.Spells;

namespace Core.Entities.CharacterEntities;

public class CharacterPreparedSpell : BaseEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; }
    public int SpellId { get; set; }
    public Spell Spell { get; set; }
    public int CharacterClassId { get; set; }
    public CharacterClass CharacterClass { get; set; }
}
