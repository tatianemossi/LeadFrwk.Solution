using LeadsFrwk.Server.Domain.Interfaces.Repositories;
using LeadsFrwk.Server.Domain.Interfaces.Services;
using LeadsFrwk.Server.Domain.Services;
using LeadsFrwk.Server.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LeadsFrwk.Server.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ILeadRepository, LeadRepository>();
            services.AddScoped<ILeadService, LeadService>();

            return services;
        }
    }
}
