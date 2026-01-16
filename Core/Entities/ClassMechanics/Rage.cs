using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ClassMechanics;

public class Rage
{
    public int CharacterId { get; set; }
    public int Uses { get; set; } = 0;
    public int Max { get; private set; }

    public Rage(int characterId, int barbarianLevel)
    {
        CharacterId = characterId;
        Max = Math.Max(2, (barbarianLevel + 1) / 2);
        Uses = Max;
    }

    public void Use()
    {
        if (Uses > 0) Uses--;
    }

    public void Recharge()
    {
        Uses = Max;
    }
}
