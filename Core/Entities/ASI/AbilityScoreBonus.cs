using Core.Enums;

namespace Core.Entities.ASI;

public class AbilityScoreBonus : BaseEntity
{
    public AbilityEnum Ability { get; set; }
    public int Amount { get; set; }
}
