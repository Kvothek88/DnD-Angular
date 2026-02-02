using Core.Entities.CharacterEntities;
using Core.Entities.Prerequisites;

namespace Application.Services;

public interface IPrerequisiteEvaluator
{
    bool IsSatisfied(Character c, Prerequisite p);
    bool EvaluateAbility(Character c, Prerequisite p);
    bool EvaluateClassLevel(Character c, Prerequisite p);
    bool EvaluateSubClassLevel(Character c, Prerequisite p);
}
