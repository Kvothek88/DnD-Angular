using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CharacterService;

public interface ICharacterService
{
    Task<Character> GetCharacterInfoAsync(int id);
}
