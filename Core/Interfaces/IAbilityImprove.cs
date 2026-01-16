using Core.Entities.ASI;

namespace Core.Interfaces;

public interface IAbilityImprove
{
    List<AbilityScoreBonus> AbilityBonuses { get; }
}
