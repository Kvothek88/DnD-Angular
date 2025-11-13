namespace Core.Entities;

public class CharacterPreparedSpell
{
    public int CharacterId { get; set; }
    public int SpellId { get; set; }
    public Spell Spell { get; set; }
    public bool IsPrepared { get; set; }
}
