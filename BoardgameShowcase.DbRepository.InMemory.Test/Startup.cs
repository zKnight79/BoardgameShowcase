using BoardgameShowcase.DbRepository.InMemory.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.DbRepository.InMemory.Test
{
    public class Startup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Startup.ConfigureServices shouldn't be static")]
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true
                )
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddBoardgameShowcaseDbRepositoryInMemory();
        }
    }
}
