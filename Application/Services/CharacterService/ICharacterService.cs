using Application.Dtos;
using Core.Entities;

namespace Application.Services.CharacterService;

public interface ICharacterService
{
    Task<CharacterViewDto> GetCharacterAsync(int id);
    Task<List<ReferenceViewDto>> GetCharacters();
    Task<List<Spell>> GetCharacterKnownSpellsAsync(int id);
}
