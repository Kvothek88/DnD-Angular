using Application.Dtos;
using Application.Services.CharacterService;
using Core.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServicesRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICharacterService, CharacterService>();
        return services;
    }

    public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.CreateMap<CharacterAbilities, CharacterAbilitiesViewDto>();
            cfg.CreateMap<CharacterSpellSlots, CharacterSpellSlotsViewDto>();
            cfg.CreateMap<Character, CharacterCardViewDto>();
            cfg.CreateMap<Spell, SpellViewDto>();
            cfg.CreateMap<Character, CharacterViewDto>()
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
        });

        return services;
    }

}
