using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public class SpellViewDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public string School { get; set; }
    public bool IsConcentration { get; set; }
    public bool IsDuration { get; set; }
    public bool IsRitual { get; set; }
    public string Duration { get; set; }
    public int Range { get; set; }
    public string CastingTime { get; set; }
    public string Classes { get; set; }
}
