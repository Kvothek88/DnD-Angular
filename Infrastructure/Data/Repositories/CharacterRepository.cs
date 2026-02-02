using Application.Dtos;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Entities.CharacterEntities;
using Core.Entities.Spells;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Character?> GetByIdAsync(int id)
    {
        return await _context.Characters
            .Include(c => c.Features).ThenInclude(f => f.Feature).ThenInclude(f => f.Spell)
            .Include(c => c.Feats).ThenInclude(f => f.Feat)
            .Include(c => c.Proficiencies).ThenInclude(c => c.GrantedProficiency).ThenInclude(g => g.Proficiency)
            .Include(c => c.CharacterPreparedSpells).ThenInclude(cps => cps.Spell)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<CharacterCardViewDto>> GetAllAsync()
    {
        return await _context.Characters
            .ProjectTo<CharacterCardViewDto>(_mapperConfig)
            .ToListAsync();
    }

    public async Task<List<Spell>> GetCharacterPreparedSpellsAsync(int id)
    {
        var spells = await _context.CharacterPreparedSpells
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
