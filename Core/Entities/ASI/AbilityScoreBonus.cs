using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.ASI;

public class AbilityScoreBonus
{
    public AbilityEnum Ability { get; set; }
    public int Amount { get; set; }
}
