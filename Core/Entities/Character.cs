using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Character : BaseEntity
{
    // Character Info
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string Background { get; set; } = string.Empty;
    public string Religion { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Alignment { get; set; } = string.Empty;
    public int Level { get; set; }

    public CharacterStats Stats { get; set; } = null!;
    public CharacterSpellSlots CharacterSpellSlots { get; set; } = null!;
    public List<Spell>? Spells { get; set; }
}
