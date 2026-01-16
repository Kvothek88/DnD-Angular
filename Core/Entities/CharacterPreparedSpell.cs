using Core.Entities.Classes;

namespace Core.Entities;

public class CharacterPreparedSpell
{
    public int CharacterId { get; set; }
    public required int SpellId { get; set; }
    public required Spell Spell { get; set; }
    public required int CharacterClassId { get; set; }
    public required CharacterClass CharacterClass { get; set; }
    public bool IsPrepared { get; set; }
}
