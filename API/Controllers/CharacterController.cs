using Application.Dtos;
using Application.Services.CharacterService;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Net;

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

    [HttpGet]
    public async Task<ActionResult<List<CharacterCardViewDto>?>> GetCharacters()
    {
        var characters = await _characterService.GetCharactersAsync();

        if (characters is null) return NotFound();

        return Ok(characters);
    }

    [HttpGet("known-spells/{id}")]
    public async Task<ActionResult<List<Spell>>> GetCharacterKnownSpells(int id)
    {
        var spells = await _characterService.GetCharacterKnownSpellsAsync(id);

        return Ok(spells);
    }

    [HttpPost]
    public async Task<ActionResult<CharacterViewDto>> CreateCharacter(CreateCharacterDto input)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdCharacter = await _characterService.CreateCharacterAsync(input);

        return CreatedAtAction(
            nameof(GetCharacterInfo),
            new { id = createdCharacter.Id },
            createdCharacter
        );
    }

    [HttpPost("upload-avatar")]
    public async Task<IActionResult> UploadAvatar([FromForm] IFormFile avatar, [FromForm] int characterId)
    {
        if (avatar == null || avatar.Length == 0)
            return BadRequest("No file uploaded");

        var extension = Path.GetExtension(avatar.FileName);
        var fileName = $"p{characterId}{extension}";


        var angularAssetsPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",
            "client",
            "src",
            "assets",
            "images",
            fileName
        );

        // Ensure directory exists
        var directory = Path.GetDirectoryName(angularAssetsPath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        using (var stream = new FileStream(angularAssetsPath, FileMode.Create))
        {
            await avatar.CopyToAsync(stream);
        }

        return Ok(new { fileName, characterId });
    }
}
