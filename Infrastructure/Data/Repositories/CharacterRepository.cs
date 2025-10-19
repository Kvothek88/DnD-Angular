using Core.Entities;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly CharacterDbContext _context;

    public CharacterRepository(CharacterDbContext context)
    {
        _context = context;
    }

    public async Task<Character?> GetByIdAsync(int id)
    {
        var characterInfo = await _context.Characters
            .Include(c => c.CharacterSpellSlots)
            .Include(c => c.Spells)
            .FirstOrDefaultAsync(c => c.Id == id);

        return characterInfo;
    }
}
