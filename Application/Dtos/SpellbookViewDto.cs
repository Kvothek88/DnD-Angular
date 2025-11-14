using Core.Entities;

namespace Application.Dtos;

public class SpellbookViewDto
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public List<SpellViewDto> Spells { get; set; } = [];
}

