using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ClassMechanics;

public class KiPoints
{
    public int CharacterId { get; set; }
    public int Current { get; set; }
    public int Max { get; set; }

    public KiPoints(int characterId, int monkLevel)
    {
        CharacterId = characterId;
        Max = (monkLevel / 2) + 1;
        Current = Max;
    }
}
