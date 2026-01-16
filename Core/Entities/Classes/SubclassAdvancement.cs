using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Classes;

public class SubclassAdvancement : Advancement
{
    public int SubclassId { get; set; }
    public CharacterSubclass Subclass { get; set; } = null!;
}
