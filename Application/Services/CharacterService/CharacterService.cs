using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using Core.Entities.Spells;

namespace Application.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterrepository;
    private readonly ICharacterEvaluationService _characterEvaluationService;
    private readonly ICharacterStatsService _characterStatsService;
    private readonly IMapper _mapper;

    public CharacterService(
        ICharacterRepository characterInfoRepository,
        ICharacterEvaluationService characterEvaluationService,
        ICharacterStatsService characterStatsService,
        IMapper mapper)
    {
        _characterrepository = characterInfoRepository;
        _characterEvaluationService = characterEvaluationService;
        _characterStatsService = characterStatsService;
        _mapper = mapper;
    }

    public async Task<CharacterViewDto?> GetCharacterAsync(int id)
    {
        var character = await _characterrepository.GetByIdAsync(id);
        if (character == null) return null;

        // CharacterEvaluationService & CharacterStatsService will be used during Character Creation
        // The Get Character will used the predetermined CharacterFeatures, CharacterFeats & CharacterProficiencies

        //var features = _characterEvaluationService.GetAllCharacterFeatures(character);
        //character.SetFeatures(features);

        //var feats = _characterEvaluationService.GetAllCharacterFeats(character);
        //character.SetFeats(feats);

        //var proficiencies = _characterEvaluationService.GetAllCharacterProficiencies(character);
        //character.SetProficiencies(proficiencies);

        var characterViewDto = _mapper.Map<CharacterViewDto>(character);
        characterViewDto.TotalCharacterAbilities = _characterStatsService.GetTotalStats(character);
        characterViewDto.Initiative = _characterStatsService.GetInitiative(character);

        return characterViewDto;
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

    //public async Task<CharacterViewDto> CreateCharacterAsync(CreateCharacterDto characterDto)
    //{
    //    var character = _mapper.Map<Character>(characterDto);

    //    character.InitializeDerivedValues();

    //    if (character.CharacterPreparedSpells?.Count > 0)
    //        character.CharacterSpellSlots = CharacterDefaults.CalculateSlots(character.Class, character.Level);

    //    return await _characterrepository.AddCharacterAsync(character);
    //}

    public async Task<List<SpellViewDto>?> GetKnownSpellsAsync(string characterClass, int spellLevel)
    {
        return await _characterrepository.GetKnownSpells(characterClass, spellLevel);
    }
}
