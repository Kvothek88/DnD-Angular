using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterSpell
{
    public int CharacterId { get; set; }
    public int SpellId { get; set; }
    public Spell Spell { get; set; }
    public bool IsPrepared { get; set; }
}
