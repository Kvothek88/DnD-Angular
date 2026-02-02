using Application.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.CharacterEntities;
using Core.Entities.Spells;

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
                dest => dest.CharacterPreparedSpells,
                opt => opt.MapFrom(src => src.CharacterPreparedSpells
                    .Select(cs => cs.Spell)
                )
            );

        CreateMap<Character, CharacterCardViewDto>();

        CreateMap<Race, ReferenceViewDto>();
        CreateMap<Background, ReferenceViewDto>();
    }
}

