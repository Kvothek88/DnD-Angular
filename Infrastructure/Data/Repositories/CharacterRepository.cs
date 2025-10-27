using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;
    private readonly IMapper _mapper;

    public CharacterRepository(CharacterDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
