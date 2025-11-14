using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using Core.Constants;
using Core.Entities;

namespace Application.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterrepository;
    private readonly IMapper _mapper;

    public CharacterService(ICharacterRepository characterInfoRepository, IMapper mapper)
    {
        _characterrepository = characterInfoRepository;
        _mapper = mapper;
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

    public async Task<List<Spell>> GetCharacterPreparedSpellsAsync(int id)
    {
        var spells = await _characterrepository.GetCharacterPreparedSpellsAsync(id);

        return spells;
    }

    public async Task<CharacterViewDto> CreateCharacterAsync(CreateCharacterDto characterDto)
    {
        var character = _mapper.Map<Character>(characterDto);

        character.InitializeDerivedValues();
        character.CharacterSpellSlots = CharacterDefaults.CalculateSlots(character.Class, character.Level);

        return await _characterrepository.AddCharacterAsync(character);
    }

    public async Task<List<SpellViewDto>?> GetKnownSpellsAsync(string characterClass, int spellLevel)
    {
        return await _characterrepository.GetKnownSpells(characterClass, spellLevel);
    }
}
