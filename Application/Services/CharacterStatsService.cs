using Application.Dtos;
using Core.Entities.CharacterEntities;
using Core.Entities.Classes;
using Core.Enums;

namespace Application.Services;

public class CharacterStatsService : ICharacterStatsService
{
    public int GetBaseAbilityScore(Character character, AbilityEnum ability)
    {
        return character.CharacterAbilities switch
        {
            _ => ability switch
            {
                AbilityEnum.Strength => character.CharacterAbilities.Strength,
                AbilityEnum.Dexterity => character.CharacterAbilities.Dexterity,
                AbilityEnum.Constitution => character.CharacterAbilities.Constitution,
                AbilityEnum.Intelligence => character.CharacterAbilities.Intelligence,
                AbilityEnum.Wisdom => character.CharacterAbilities.Wisdom,
                AbilityEnum.Charisma => character.CharacterAbilities.Charisma,
                _ => throw new ArgumentOutOfRangeException()
            }
        };
    }

    public int GetAbilityScore(Character character, AbilityEnum ability)
    {
        var baseScore = GetBaseAbilityScore(character, ability);

        // ASIs only
        var asiBonus = character.ASIAdvancements
            .SelectMany(a => a.AbilityBonuses)
            .Where(b => b.Ability == ability)
            .Sum(b => b.Amount);

        // Feats (race, background, chosen)
        var featBonus = character.Feats
            .SelectMany(cf => cf.Feat.AbilityBonuses ?? [])
            .Where(b => b.Ability == ability)
            .Sum(b => b.Amount);

        // Features
        var featureBonus = character.Features
            .SelectMany(cf => cf.Feature.AbilityBonuses ?? [])
            .Where(b => b.Ability == ability)
            .Sum(b => b.Amount);

        return baseScore + asiBonus + featBonus + featureBonus;
    }


    public int GetAbilityModifier(Character character, AbilityEnum ability)
    {
        return (int)Math.Floor((decimal)(GetAbilityScore(character, ability) - 10) / 2);
    }

    public CharacterAbilitiesViewDto GetTotalStats(Character character)
    {
        var stats = new CharacterAbilitiesViewDto
        {
            Strength = GetAbilityScore(character, AbilityEnum.Strength),
            StrengthModifier = GetAbilityModifier(character, AbilityEnum.Strength),

            Dexterity = GetAbilityScore(character, AbilityEnum.Dexterity),
            DexterityModifier = GetAbilityModifier(character, AbilityEnum.Dexterity),

            Constitution = GetAbilityScore(character, AbilityEnum.Constitution),
            ConstitutionModifier = GetAbilityModifier(character, AbilityEnum.Constitution),

            Intelligence = GetAbilityScore(character, AbilityEnum.Intelligence),
            IntelligenceModifier = GetAbilityModifier(character, AbilityEnum.Intelligence),

            Wisdom = GetAbilityScore(character, AbilityEnum.Wisdom),
            WisdomModifier = GetAbilityModifier(character, AbilityEnum.Wisdom),

            Charisma = GetAbilityScore(character, AbilityEnum.Charisma),
            CharismaModifier = GetAbilityModifier(character, AbilityEnum.Charisma)
        };

        return stats;
    }

    public int GetMaxHp(Character character)
    {
        var primaryHitDie = character.ClassAdvancements
            .First(ca => ca.EntryType == ClassEntryType.Primary)
            .Class.HitDice;

        var averageHp = character.ClassAdvancements.Sum(ca =>
            ca.Level * (ca.Class.HitDice / 2 + 1)
        );

        var correctedHp = averageHp - (primaryHitDie / 2 + 1) + primaryHitDie;

        return correctedHp + GetAbilityModifier(character, AbilityEnum.Constitution) * character.Level;
    }

    public int GetInitiative(Character character)
    {
        var dexMod = GetAbilityModifier(character, AbilityEnum.Dexterity);

        return dexMod;
    }
}
