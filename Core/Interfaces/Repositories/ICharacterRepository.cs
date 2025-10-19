using Core.Entities;
using System.Runtime.CompilerServices;

namespace Core.Interfaces.Repositories;

public interface ICharacterRepository
{
    Task<Character> GetByIdAsync(int id);
}
