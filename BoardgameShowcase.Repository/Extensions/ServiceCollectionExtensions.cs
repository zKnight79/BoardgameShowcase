using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Repository.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBoardgameShowcaseDbRepository(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IIllustratorService, IllustratorService>();
            services.AddSingleton<IPublisherService, PublisherService>();
            services.AddSingleton<IBoardgameService, BoardgameService>();

            return services;
        }
    }
}
