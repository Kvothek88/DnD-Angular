using Application.Dtos;
using Core.Entities.CharacterEntities;
using Core.Entities.Spells;

namespace Application.Interfaces.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetByIdAsync(int id);
    Task<List<CharacterCardViewDto>> GetAllAsync();
    Task<List<Spell>> GetCharacterPreparedSpellsAsync(int id);
    Task<CharacterViewDto> AddCharacterAsync(Character character);
    Task<List<SpellViewDto>?> GetKnownSpells(string characterClass, int spellLevel);
}
