using BoardgameShowcase.Repository.Extensions;
using BoardgameShowcase.Repository.GraphQL.Repository;
using BoardgameShowcase.Repository.GraphQL.Subscription;
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
            services.AddTransient<IAuthorSubscription, AuthorSubscription>();
            services.AddTransient<IIllustratorRepository, IllustratorRepository>();
            services.AddTransient<IIllustratorSubscription, IllustratorSubscription>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IPublisherSubscription, PublisherSubscription>();
            services.AddTransient<IBoardgameRepository, BoardgameRepository>();

            services.AddBoardgameShowcaseRepository();

            return services;
        }
    }
}
