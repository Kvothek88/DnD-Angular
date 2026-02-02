namespace Core.Entities.Spells;

public class Spellbook : BaseEntity
{
    public int CharacterId { get; set; }
    public List<SpellbookSpell>? SpellbookSpells {  get; set; }
}
