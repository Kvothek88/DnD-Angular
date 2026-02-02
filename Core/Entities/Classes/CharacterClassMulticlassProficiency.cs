namespace Core.Entities.Classes;

public class CharacterClassMulticlassProficiency
{
    public int CharacterClassId { get; set; }
    public CharacterClass CharacterClass { get; set; } = null!;

    public int GrantedProficiencyId { get; set; }
    public GrantedProficiency GrantedProficiency { get; set; } = null!;
}
