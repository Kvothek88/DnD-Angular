using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class Character : BaseEntity
{
    // Character Info
    public string Name { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;
    public string Background { get; set; } = string.Empty;
    public string Religion { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Alignment { get; set; } = string.Empty;
    public int Level { get; set; }

    public CharacterAbilities CharacterAbilities { get; set; } = null!;
    public CharacterSpellSlots CharacterSpellSlots { get; set; } = null!;
    public List<Spell>? CharacterSpells { get; set; }


    public int HitDice { get; set; }
    public int MaxHp => HitDice + ((Level - 1) * (HitDice / 2 + 1)) + (CharacterAbilities.ConstitutionModifier * Level) + Level;
    public int CurrentHp {  get; set; }

    public int ProficiencyBonus => (int)Math.Ceiling(Level / 4.0) + 1;
    public int Initiative => CharacterAbilities.DexterityModifier;
    public int Speed {  get; set; }

    // Saves Proficiency Bonus
    public bool StrengthSaveApplyProf {  get; set; }
    public bool DexteritySaveApplyProf { get; set; }
    public bool ConstitutionSaveApplyProf { get; set; }
    public bool IntelligenceSaveApplyProf { get; set; }
    public bool WisdomSaveApplyProf { get; set; }
    public bool CharismaSaveApplyProf { get; set; }
}
