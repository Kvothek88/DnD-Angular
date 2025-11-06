using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Classes;

public class CharacterClassLevel : BaseEntity
{
    public int CharacterId { get; set; }
    public Character Character { get; set; } = null!;

    public int ClassId { get; set; }
    public CharacterClass Class { get; set; } = null!;

    public int? SubclassId { get; set; }
    public CharacterSubclass? Subclass { get; set; }

    public int Level { get; set; }
}
