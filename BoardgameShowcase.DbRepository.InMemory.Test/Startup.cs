using BoardgameShowcase.DbRepository.InMemory.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.DbRepository.InMemory.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddBoardgameShowcaseDbRepositoryInMemory();
        }
    }
}
