using Core.Entities.Prerequisites;
using Core.Interfaces;

namespace Core.Entities.ASI;

public class Feat : BaseEntity, IOptionalAbilityImprove
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Prerequisite> Prerequisites { get; set; } = [];
    public List<AbilityScoreBonus>? AbilityBonuses { get; set; } = [];
}
