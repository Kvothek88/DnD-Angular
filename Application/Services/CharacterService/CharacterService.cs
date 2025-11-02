using Application.Dtos;
using Application.Interfaces.Repositories;
using Core.Entities;

namespace Application.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterrepository; 
    
    public CharacterService(ICharacterRepository characterInfoRepository)
    {
        _characterrepository = characterInfoRepository;
    }

    public async Task<CharacterViewDto> GetCharacterAsync(int id)
    {
        var character = await _characterrepository.GetByIdAsync(id);

        return character;
    }

    public async Task<List<CharacterCardViewDto>> GetCharactersAsync()
    {
        return await _characterrepository.GetAllAsync();
    }

    public async Task<List<Spell>> GetCharacterKnownSpellsAsync(int id)
    {
        var spells = await _characterrepository.GetCharacterKnownSpellsAsync(id);

        return spells;
    }
}
