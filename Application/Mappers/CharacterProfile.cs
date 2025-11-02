using Application.Dtos;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        // Abilities
        CreateMap<CharacterAbilities, CharacterAbilitiesViewDto>();

        // Spell Slots
        CreateMap<CharacterSpellSlots, CharacterSpellSlotsViewDto>();

        // Spells
        CreateMap<Spell, SpellViewDto>();

        // Character → CharacterViewDto
        CreateMap<Character, CharacterViewDto>()
            .ForMember(
                dest => dest.CharacterSpells,
                opt => opt.MapFrom(src => src.CharacterSpells
                    .Where(cs => cs.IsPrepared)
                    .Select(cs => cs.Spell)
                )
            )
            .ForMember(dest => dest.MaxHp, opt => opt.MapFrom(src => src.MaxHp))
            .ForMember(dest => dest.ProficiencyBonus, opt => opt.MapFrom(src => src.ProficiencyBonus))
            .ForMember(dest => dest.Initiative, opt => opt.MapFrom(src => src.Initiative));

        CreateMap<Character, CharacterCardViewDto>();
    }
}

