using Application.Dtos;
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
    public async Task<ActionResult<CharacterViewDto>> GetCharacterInfo(int id)
    {
        var character = await _characterService.GetCharacterAsync(id);

        if (character == null) return NotFound();

        return Ok(character);
    }

    [HttpGet("known-spells/{id}")]
    public async Task<ActionResult<List<Spell>>> GetCharacterKnownSpells(int id)
    {
        var spells = await _characterService.GetCharacterKnownSpellsAsync(id);

        return Ok(spells);
    }
}
