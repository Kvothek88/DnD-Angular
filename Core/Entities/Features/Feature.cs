using Core.Entities.ASI;
using Core.Entities.Classes;
using Core.Entities.Prerequisites;
using Core.Entities.Spells;
using Core.Enums;
using Core.Interfaces;

namespace Core.Entities.Features;

public class Feature : BaseEntity, IAbilityImprove
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Prerequisite> Prerequisites { get; set; } = [];
    public List<AbilityScoreBonus> AbilityBonuses { get; set; } = [];
    public Spell? Spell { get; set; } = null!;
    public int? SpellId { get; set; }
    public ActionType? ActionType { get; set; }
    public FeatureKind FeatureKind { get; set; }
}
