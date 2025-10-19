using Core.Entities;
using Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterInforepository; 
    
    public CharacterService(ICharacterRepository characterInfoRepository)
    {
        _characterInforepository = characterInfoRepository;
    }

    public async Task<Character> GetCharacterInfoAsync(int id)
    {
        var characterInfo = await _characterInforepository.GetByIdAsync(id);

        return characterInfo;
    }
}
