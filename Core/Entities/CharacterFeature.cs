using Core.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterFeature
{
    public required int CharacterId { get; set; }
    public required Character Character { get; set; }
    public required int FeatureId { get; set; }
    public required Feature Feature { get; set; }
}
