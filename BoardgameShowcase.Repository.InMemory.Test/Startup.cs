using BoardgameShowcase.Repository.InMemory.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.Repository.InMemory.Test
{
    public class Startup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Startup.ConfigureServices shouldn't be static")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBoardgameShowcaseRepositoryInMemory();
        }
    }
}
