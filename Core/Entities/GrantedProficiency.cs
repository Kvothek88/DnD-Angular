using Core.Entities.Classes;
using Core.Entities.Dictionaries;

namespace Core.Entities;

public class GrantedProficiency : BaseEntity
{
    public int? ProficiencyId { get; set; }
    public DictionaryItem? Proficiency {  get; set; }

    public int? ProficiencyTypeId { get; set; }
    public Dictionary? ProficiencyType { get; set; }

    public int? ProficiencyCategoryId { get; set; }
    public DictionaryCategory? ProficiencyCategory { get; set; }

    public List<CharacterClassPrimaryProficiency> ClassPrimaryProficiencies { get; set; } = [];
    public List<CharacterClassMulticlassProficiency> ClassMulticlassProficiencies { get; set; } = [];
    public List<CharacterSubclassProficiency> SubclassProficiencies { get; set; } = [];
}
