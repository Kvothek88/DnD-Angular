using Application.Services.CharacterService;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharactersController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterInfo(int id)
    {
        var characterInfo = await _characterService.GetCharacterInfoAsync(id);

        if (characterInfo == null) return NotFound();

        return Ok(characterInfo);
    }
}
