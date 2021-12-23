using BoardgameShowcase.DbRepository.Extensions;
using BoardgameShowcase.DbRepository.InMemory.Repository;
using BoardgameShowcase.DbRepository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.DbRepository.InMemory.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBoardgameShowcaseDbRepositoryInMemory(this IServiceCollection services)
        {
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IIllustratorRepository, IllustratorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();

            services.AddBoardgameShowcaseDbRepository();

            return services;
        }
    }
}
