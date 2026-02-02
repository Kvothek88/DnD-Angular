using Core.Entities.CharacterEntities;
using Core.Interfaces;

namespace Core.Entities.ASI;

public class AbilityScoreImprovement : Advancement, IAbilityImprove
{
    public List<AbilityScoreBonus> AbilityBonuses { get; set; } = [];
}
