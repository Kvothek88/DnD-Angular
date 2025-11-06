using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
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

    public async Task<List<Spell>> GetCharacterKnownSpellsAsync(int id)
    {
        var spells = await _characterrepository.GetCharacterKnownSpellsAsync(id);

        return spells;
    }

    public async Task<CharacterViewDto> CreateCharacterAsync(CreateCharacterDto characterDto)
    {
        var character = _mapper.Map<Character>(characterDto);
        return await _characterrepository.AddCharacterAsync(character);
    }

}
