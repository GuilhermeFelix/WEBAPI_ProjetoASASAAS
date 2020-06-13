using Api.Domain.Interfaces.Services.Manager;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {

            serviceCollection.AddTransient<IManagerService, ManagerService>();
        }
    }
}
