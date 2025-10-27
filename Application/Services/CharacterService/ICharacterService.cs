using Application.Dtos;
using Core.Entities;

namespace Application.Services.CharacterService;

public interface ICharacterService
{
    Task<CharacterViewDto> GetCharacterAsync(int id);
    Task<List<Spell>> GetCharacterKnownSpellsAsync(int id);
}
