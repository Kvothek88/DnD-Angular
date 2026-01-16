using Core.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Race : BaseEntity
{
    public string Name { get; set; }
    public string Size { get; set; }
    public int Speed { get; set; }
    public List<CharacterProficiency> Proficiencies { get; set; } = [];
    public List<Feature> Features { get; set; } = [];
    public List<Spell> Spells { get; set; } = [];

    public List<Feat>? Feats { get; set; } = [];
}
