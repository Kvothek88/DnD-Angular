using Application.Services.CharacterService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application;

public static class ServicesRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICharacterService, CharacterService>();
        return services;
    }
}
