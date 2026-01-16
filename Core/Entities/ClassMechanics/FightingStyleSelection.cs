using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ClassMechanics;

public class FightingStyleSelection
{
    public int CharacterId { get; set; }
    public List<string> ChosenStyles { get; set; } = [];
}
