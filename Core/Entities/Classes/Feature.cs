using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Classes;

public class Feature : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int LevelRequirement { get; set; }

    // Optional relationship to Class or Subclass
    public int? ClassId { get; set; }
    public CharacterClass? Class { get; set; }

    public int? SubclassId { get; set; }
    public CharacterSubclass? Subclass { get; set; }
}
