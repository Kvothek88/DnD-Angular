using Application.Dtos;
using Core.Entities;
using System.Runtime.CompilerServices;

namespace Application.Interfaces.Repositories;

public interface ICharacterRepository
{
    Task<CharacterViewDto> GetByIdAsync(int id);
    Task<List<CharacterCardViewDto>> GetAllAsync();
    Task<List<Spell>> GetCharacterKnownSpellsAsync(int id);
}
