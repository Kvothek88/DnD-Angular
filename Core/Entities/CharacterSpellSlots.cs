using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterSpellSlots : BaseEntity
{
    public int MaxLevel1 { get; set; }
    public int MaxLevel2 { get; set; }
    public int MaxLevel3 { get; set; }
    public int MaxLevel4 { get; set; }
    public int MaxLevel5 { get; set; }
    public int MaxLevel6 { get; set; }
    public int MaxLevel7 { get; set; }
    public int MaxLevel8 { get; set; }
    public int MaxLevel9 { get; set; }

    public int UsedLevel1 { get; set; }
    public int UsedLevel2 { get; set; }
    public int UsedLevel3 { get; set; }
    public int UsedLevel4 { get; set; }
    public int UsedLevel5 { get; set; }
    public int UsedLevel6 { get; set; }
    public int UsedLevel7 { get; set; }
    public int UsedLevel8 { get; set; }
    public int UsedLevel9 { get; set; }

    public int CharacterId { get; set; }
}
