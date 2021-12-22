using BoardgameShowcase.DbRepository.Service;
using BoardgameShowcase.Model.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.DbRepository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBoardgameShowcaseDbRepository(this IServiceCollection services)
        {
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IIllustratorService, IllustratorService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IBoardgameService, BoardgameService>();
            
            return services;
        }
    }
}
