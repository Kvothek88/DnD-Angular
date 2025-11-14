using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public class CreateCharacterDto
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
    public string? ImageFrame { get; set; }

    public CreateCharacterAbilitiesDto CharacterAbilities { get; set; } = null!;

    public List<Spell> CharacterPreparedSpells { get; set; } = [];
    public SpellbookAddDto? Spellbook { get; set; }

    public int HitDice { get; set; }
    public int CurrentHp { get; set; }
    public int Speed { get; set; }

    // Saving Throws
    public bool StrengthSaveApplyProf { get; set; }
    public bool DexteritySaveApplyProf { get; set; }
    public bool ConstitutionSaveApplyProf { get; set; }
    public bool IntelligenceSaveApplyProf { get; set; }
    public bool WisdomSaveApplyProf { get; set; }
    public bool CharismaSaveApplyProf { get; set; }

    // Skills
    public bool AcrobaticsApplyProf { get; set; }
    public bool AnimalHandlingApplyProf { get; set; }
    public bool ArcanaApplyProf { get; set; }
    public bool AthleticsApplyProf { get; set; }
    public bool DeceptionApplyProf { get; set; }
    public bool HistoryApplyProf { get; set; }
    public bool InsightApplyProf { get; set; }
    public bool IntimidationApplyProf { get; set; }
    public bool InvestigationApplyProf { get; set; }
    public bool MedicineApplyProf { get; set; }
    public bool NatureApplyProf { get; set; }
    public bool PerceptionApplyProf { get; set; }
    public bool PerformanceApplyProf { get; set; }
    public bool PersuasionApplyProf { get; set; }
    public bool ReligionApplyProf { get; set; }
    public bool SleightOfHandApplyProf { get; set; }
    public bool StealthApplyProf { get; set; }
    public bool SurvivalApplyProf { get; set; }
}

