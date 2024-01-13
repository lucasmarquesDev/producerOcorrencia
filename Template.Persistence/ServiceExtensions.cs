using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Interfaces;
using Template.Persistence.ServiceBus;

namespace Template.Infraestructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                               IConfiguration configuration)
        {
            services.AddScoped<IServiceBus, ServiceBus>();
        }
    }
}
