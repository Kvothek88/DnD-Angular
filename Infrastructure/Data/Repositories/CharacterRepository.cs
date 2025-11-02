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

    public async Task<List<ReferenceViewDto>> GetAllAsync()
    {
        return await _context.Characters
            .ProjectTo<ReferenceViewDto>(_mapperConfig)
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
}
