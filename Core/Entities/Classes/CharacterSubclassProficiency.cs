namespace Core.Entities.Classes;

public class CharacterSubclassProficiency
{
    public int CharacterSubclassId { get; set; }
    public CharacterSubclass CharacterSubclass { get; set; } = null!;

    public int GrantedProficiencyId { get; set; }
    public GrantedProficiency GrantedProficiency { get; set; } = null!;
}

