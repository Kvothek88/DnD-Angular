using Core.Entities.ASI;
using Core.Entities.Prerequisites;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Feat : BaseEntity, IOptionalAbilityImprove
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Prerequisite> Prerequisites { get; set; } = [];


    public List<AbilityScoreBonus>? AbilityBonuses { get; set; } = [];
}
