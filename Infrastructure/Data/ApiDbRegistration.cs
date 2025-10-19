using Core.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data;

public static class ApiDbRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<CharacterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<ICharacterRepository, CharacterRepository>();

        return services;
    }
}
