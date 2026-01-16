using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ClassMechanics;

public class SorceryPoints
{
    public int CharacterId { get; set; }
    public int Current { get; set; }
    public int Max { get; set; }

    public SorceryPoints(int characterId, int sorcererLevel)
    {
        CharacterId = characterId;
        Max = sorcererLevel;
        Current = Max;
    }
}
