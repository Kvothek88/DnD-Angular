namespace Core.Entities;

public class CharacterProficiency : BaseEntity
{
    public int? ProficiencyId { get; set; }
    public DictionaryItem? Proficiency {  get; set; }

    public int? ProficiencyTypeId { get; set; }
    public Dictionary? ProficiencyType { get; set; }

    public int CharacterId { get; set; }
    public Character Character { get; set; }
}
