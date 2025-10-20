using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class CharacterAbilities : BaseEntity
{
    public int CharacterId { get; set; }

    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }

    public int StrengthModifier => (int)Math.Floor((decimal)(Strength - 10) / 2);
    public int DexterityModifier => (int)Math.Floor((decimal)(Dexterity - 10) / 2);
    public int ConstitutionModifier => (int)Math.Floor((decimal)(Constitution - 10) / 2);
    public int IntelligenceModifier => (int)Math.Floor((decimal)(Intelligence - 10) / 2);
    public int WisdomModifier => (int)Math.Floor((decimal)(Wisdom - 10) / 2);
    public int CharismaModifier => (int)Math.Floor((decimal)(Charisma - 10) / 2);
}
