using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Spells;

public class SpellbookSpell
{
    public int SpellId { get; set; }
    public Spell Spell { get; set; }
    public int SpellbookId { get; set; }
    public Spellbook Spellbook { get; set; }
}
