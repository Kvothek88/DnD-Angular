using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public class CharacterProficiencyViewDto
{
    public int CharacterId { get; set; }
    public ReferenceViewDto? Proficiency { get; set; }
    public ReferenceViewDto? ProficiencyType { get; set; }
}
