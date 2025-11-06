using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Classes;

public class CharacterSubclass : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int ClassId { get; set; }
    public CharacterClass Class { get; set; } = null!;

    public List<Feature> Features { get; set; } = [];
}
