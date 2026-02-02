using Application.Dtos;
using Application.Services;
using Application.Services.CharacterService;
using Core.Entities;
using Core.Entities.CharacterEntities;
using Core.Entities.Dictionaries;
using Core.Entities.Spells;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServicesRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<ICharacterEvaluationService, CharacterEvaluationService>();
        services.AddScoped<ICharacterStatsService, CharacterStatsService>();
        services.AddScoped<IPrerequisiteEvaluator, PrerequisiteEvaluator>();
        return services;
    }

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.CreateMap<CharacterAbilities, CharacterAbilitiesViewDto>();
            cfg.CreateMap<CharacterSpellSlots, CharacterSpellSlotsViewDto>();
            cfg.CreateMap<Character, CharacterCardViewDto>();
            cfg.CreateMap<GrantedProficiency, CharacterProficiencyViewDto>();
            cfg.CreateMap<Dictionary, ReferenceViewDto>();
            cfg.CreateMap<DictionaryItem, ReferenceViewDto>();
            cfg.CreateMap<Spell, SpellViewDto>();
            //cfg.CreateMap<CreateCharacterDto, Character>()
            //    .ForMember(dest => dest.CharacterPreparedSpells,
            //               opt => opt.MapFrom(src => src.CharacterPreparedSpells
            //                   .Select(spell => new CharacterPreparedSpell { SpellId = spell.Id, IsPrepared = true })
            //               ));
            cfg.CreateMap<CreateCharacterAbilitiesDto, CharacterAbilities>();
            cfg.CreateMap<Character, CharacterViewDto>()
                .ForMember(
                    dest => dest.CharacterPreparedSpells,
                    opt => opt.MapFrom(src => src.CharacterPreparedSpells
                        .Select(cs => cs.Spell)
                    )
                );
                //.ForMember(dest => dest.MaxHp, opt => opt.MapFrom(src => src.MaxHp))
                //.ForMember(dest => dest.ProficiencyBonus, opt => opt.MapFrom(src => src.ProficiencyBonus));
            cfg.CreateMap<Spellbook, SpellbookViewDto>()
                .ForMember(dest => dest.Spells, opt => opt.MapFrom(src =>
                    src.SpellbookSpells != null
                        ? src.SpellbookSpells.Select(sbs => sbs.Spell).ToList()
                        : new List<Spell>()
                ));
            cfg.CreateMap<SpellbookAddDto, Spellbook>();
            cfg.CreateMap<SpellbookSpellAddDto, SpellbookSpell>();
            cfg.CreateMap<Race, ReferenceViewDto>();
            cfg.CreateMap<Background, ReferenceViewDto>();
        });

        return services;
    }

}
