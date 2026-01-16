using Core.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterBackground : BaseEntity
{
    public int CharacterId { get; set; }
    public List<CharacterProficiency> Proficiencies { get; set; } = [];
    public List<Feat> Feats { get; set; } = [];
    public List<Feature> Features { get; set; } = [];
}
