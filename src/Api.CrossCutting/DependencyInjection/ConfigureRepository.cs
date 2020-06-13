using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            IServiceCollection serviceCollections = serviceCollection.AddDbContext<MyContext>(
                options => options.UseNpgsql("Host=manager.postgres.uhserver.com ;Port=5432; Database=manager;Username=efdados;Password=Lar@nj4")

            );
        }
    }
}
