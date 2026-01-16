using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Prerequisites;

public static class PrerequisiteEvaluator
{
    public static bool IsSatisfied(Character c, Prerequisite p)
    {
        return p.Type switch
        {
            PrerequisiteType.Race =>
                c.Race.Name == p.Value,

            PrerequisiteType.Level =>
                c.Level >= int.Parse(p.Value),

            PrerequisiteType.Ability =>
                EvaluateAbility(c, p),

            PrerequisiteType.Class =>
                c.ClassAdvancements.Any(ca => ca.Class.Name == p.Value),

            PrerequisiteType.Spellcasting =>
                c.ClassAdvancements.Any(ca => ca.Class.IsSpellcaster == true),

            _ => false
        };
    }

    private static bool EvaluateAbility(Character c, Prerequisite p)
    {
        var parts = p.Value.Split(':');
        var ability = Enum.Parse<AbilityEnum>(parts[0]);
        var required = int.Parse(parts[1]);

        return c.GetAbilityScore(ability) >= required;
    }
}

