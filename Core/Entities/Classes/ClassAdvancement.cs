namespace Core.Entities.Classes;

public class ClassAdvancement : Advancement
{
    public int ClassId { get; set; }
    public CharacterClass Class { get; set; } = null!;
}
