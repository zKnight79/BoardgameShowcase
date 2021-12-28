using BoardgameShowcase.Repository.Extensions;
using BoardgameShowcase.Repository.GraphQL.Repository;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.Repository.GraphQL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBoardgameShowcaseRepositoryGraphQL(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IIllustratorRepository, IllustratorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IBoardgameRepository, BoardgameRepository>();

            services.AddBoardgameShowcaseRepository();

            return services;
        }
    }
}
