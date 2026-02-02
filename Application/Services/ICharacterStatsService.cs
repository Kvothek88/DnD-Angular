using Application.Dtos;
using Core.Entities.CharacterEntities;
using Core.Enums;

namespace Application.Services;

public interface ICharacterStatsService
{
    CharacterAbilitiesViewDto GetTotalStats(Character character);
    int GetBaseAbilityScore(Character character, AbilityEnum ability);
    int GetAbilityScore(Character character, AbilityEnum ability);
    int GetAbilityModifier(Character character, AbilityEnum ability);
    int GetMaxHp(Character character);
    int GetInitiative(Character character);
}
