using Core.Entities.CharacterEntities;
using Core.Entities.Prerequisites;
using Core.Enums;

namespace Application.Services;

public class PrerequisiteEvaluator(ICharacterStatsService characterStatsService) : IPrerequisiteEvaluator
{

    public bool IsSatisfied(Character c, Prerequisite p)
    {
        return p.Type switch
        {
            PrerequisiteType.Level =>
                c.Level >= int.Parse(p.Value),

            PrerequisiteType.Ability =>
                EvaluateAbility(c, p),

            PrerequisiteType.Class =>
                c.ClassAdvancements.Any(ca => ca.Class.Name == p.Value),

            PrerequisiteType.ClassLevel =>
                EvaluateClassLevel(c, p),

            PrerequisiteType.Subclass =>
                c.SubclassAdvancements.Any(ca => ca.Subclass.Name == p.Value),

            PrerequisiteType.SubclassLevel =>
                EvaluateSubClassLevel(c, p),

            PrerequisiteType.Spellcasting =>
                c.ClassAdvancements.Any(ca => ca.Class.IsSpellcaster == true),

            _ => false
        };
    }

    public bool EvaluateAbility(Character c, Prerequisite p)
    {
        var parts = p.Value.Split(':');
        var ability = Enum.Parse<AbilityEnum>(parts[0]);
        var required = int.Parse(parts[1]);

        return characterStatsService.GetAbilityScore(c,ability) >= required;
    }

    public bool EvaluateClassLevel(Character c, Prerequisite p)
    {
        var parts = p.Value.Split(':');
        var className = parts[0];
        var level = int.Parse(parts[1]);

        return c.ClassAdvancements
            .Any(ca => ca.Class.Name == className && ca.Level >= level);
    }

    public bool EvaluateSubClassLevel(Character c, Prerequisite p)
    {
        var parts = p.Value.Split(':');
        var subclassName = parts[0];
        var level = int.Parse(parts[1]);

        return c.SubclassAdvancements
            .Any(ca => ca.Subclass.Name == subclassName && ca.Level >= level);
    }
}

