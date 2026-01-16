using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterPhysicalCharacteristics : BaseEntity
{
    public int CharacterId { get; set; }

    public string? Hair { get; set; }
    public string? Skin { get; set; }
    public string? Eyes { get; set; }
    public int? Height { get; set; }
    public int? Weight { get; set; }
    public int? Age { get; set; }
    public GenderEnum Gender { get; set; } 
}
