using Core.Constants;
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
    public string Subclass { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public string Alignment { get; set; } = string.Empty;
    public int Level { get; set; }
    public string? ImageFrame {  get; set; }

    public CharacterAbilities CharacterAbilities { get; set; } = null!;
    public CharacterSpellSlots? CharacterSpellSlots { get; set; } = null!;
    public List<CharacterSpell>? CharacterSpells { get; set; } = [];


    public int HitDice { get; set; }
    public int MaxHp => HitDice + ((Level - 1) * (HitDice / 2 + 1)) + (CharacterAbilities.ConstitutionModifier * Level) + Level;
    public int CurrentHp { get; set; }

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

    // Skills Proficiency Bonus
    public bool AcrobaticsApplyProf { get; set; }      // Dex
    public bool AnimalHandlingApplyProf { get; set; }  // Wis
    public bool ArcanaApplyProf { get; set; }          // Int
    public bool AthleticsApplyProf { get; set; }       // Str
    public bool DeceptionApplyProf { get; set; }       // Cha
    public bool HistoryApplyProf { get; set; }         // Int
    public bool InsightApplyProf { get; set; }         // Wis
    public bool IntimidationApplyProf { get; set; }    // Cha
    public bool InvestigationApplyProf { get; set; }   // Int
    public bool MedicineApplyProf { get; set; }        // Wis
    public bool NatureApplyProf { get; set; }          // Int
    public bool PerceptionApplyProf { get; set; }      // Wis
    public bool PerformanceApplyProf { get; set; }     // Cha
    public bool PersuasionApplyProf { get; set; }      // Cha
    public bool ReligionApplyProf { get; set; }        // Int
    public bool SleightOfHandApplyProf { get; set; }   // Dex
    public bool StealthApplyProf { get; set; }         // Dex
    public bool SurvivalApplyProf { get; set; }        // Wis

    public void InitializeDerivedValues()
    {
        // Populate HitDice based on Class
        if (CharacterDefaults.ClassHitDice.TryGetValue(Class, out var hitDice))
            HitDice = hitDice;
        else
            HitDice = 8; // default if class not found

        // Populate Speed based on Race
        if (CharacterDefaults.RaceSpeed.TryGetValue(Race, out var speed))
            Speed = speed;
        else
            Speed = 30; // default if race not found

        // Initialize CurrentHp
        CurrentHp = MaxHp;
    }
}
