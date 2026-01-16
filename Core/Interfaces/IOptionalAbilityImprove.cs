using Core.Entities.ASI;

namespace Core.Interfaces;

public interface IOptionalAbilityImprove
{
    List<AbilityScoreBonus>? AbilityBonuses { get; }
}
