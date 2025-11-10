using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Spell : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Level { get; set; }
    public string School { get; set; } = string.Empty;
    public bool IsConcentration { get; set; }
    public bool IsDuration { get; set; }
    public bool IsRitual { get; set; }
    public string Duration { get; set; } = string.Empty;
    public int Range { get; set; }
    public string CastingTime { get; set; } = string.Empty;
    public string Classes {  get; set; } = string.Empty;
}
