namespace Application.Dtos;

public class CharacterCardViewDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public string Subclass { get; set; } = string.Empty;
    public int Level { get; set; }
    public string? ImageFrame { get; set; }
}
