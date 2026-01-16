using Core.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterFeat
{
    public required int CharacterId { get; set; }
    public required Character Character { get; set; }
    public required int FeatId { get; set; }
    public required Feat Feat { get; set; }
}
