using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Infrastructure.Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfigurationProvider _mapperConfig;

    public CharacterRepository(
        CharacterDbContext context, 
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _mapperConfig = _mapper.ConfigurationProvider;
    }

    public async Task<CharacterViewDto?> GetByIdAsync(int id)
    {
        var character = await _context.Characters
            .Include(c => c.CharacterAbilities)
            .Include(c => c.CharacterSpellSlots)
            .Include(c => c.CharacterSpells).ThenInclude(cs => cs.Spell)
            .FirstOrDefaultAsync(c => c.Id == id);

        return _mapper.Map<CharacterViewDto>(character);
    }

    public async Task<List<CharacterCardViewDto>> GetAllAsync()
    {
        return await _context.Characters
            .ProjectTo<CharacterCardViewDto>(_mapperConfig)
            .ToListAsync();
    }

    public async Task<List<Spell>> GetCharacterKnownSpellsAsync(int id)
    {
        var spells = await _context.CharacterSpells
            .Where(cs => cs.CharacterId == id)
            .Include(cs => cs.Spell)
            .Select(cs => cs.Spell)
            .ToListAsync();

        return spells;
    }

    public async Task<CharacterViewDto> AddCharacterAsync(Character character)
    {
        await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();
        return _mapper.Map<CharacterViewDto>(character);
    }

    public async Task<List<SpellViewDto>?> GetKnownSpells(string characterClass, int spellLevel)
    {
        return await _context.Spells
            .ProjectTo<SpellViewDto>(_mapperConfig)
            .Where(s => s.Classes.Contains(characterClass) && s.Level <= spellLevel)
            .ToListAsync();
    }
}
