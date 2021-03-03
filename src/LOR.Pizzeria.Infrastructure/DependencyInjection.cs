using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Infrastructure.Persistence;

using Microsoft.Extensions.DependencyInjection;

namespace LOR.Pizzeria.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, DefaultDbContext>();
            return services;
        }
    }
}