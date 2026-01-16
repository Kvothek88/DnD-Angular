using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ClassMechanics;

public class ChannelDivinity
{
    public int CharacterId { get; set; }
    public int Uses { get; set; } = 0;
    public int Max { get; private set; }

    public ChannelDivinity(int characterId, int clericLevel)
    {
        CharacterId = characterId;
        Max = (clericLevel / 2) + 1;
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

