using Application.Dtos;
using Core.Entities;

namespace Application.Services.CharacterService;

public interface ICharacterService
{
    Task<CharacterViewDto> GetCharacterAsync(int id);
    Task<List<CharacterCardViewDto>> GetCharactersAsync();
    Task<List<Spell>> GetCharacterKnownSpellsAsync(int id);
    Task<CharacterViewDto> CreateCharacterAsync(CreateCharacterDto characterDto);
    Task<List<SpellViewDto>?> GetKnownSpellsAsync(string characterClass, int spellLevel);
}
