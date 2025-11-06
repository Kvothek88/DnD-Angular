using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Classes;

public class CharacterClass : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int HitDice { get; set; }

    public List<CharacterSubclass> Subclasses { get; set; } = [];

    public List<Feature> Features { get; set; } = [];
}
