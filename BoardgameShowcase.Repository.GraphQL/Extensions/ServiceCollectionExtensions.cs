using BoardgameShowcase.Repository.Extensions;
using BoardgameShowcase.Repository.GraphQL.Repository;
using BoardgameShowcase.Repository.GraphQL.Subscription;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.Repository.GraphQL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBoardgameShowcaseRepositoryGraphQLSubscriptionsOnly(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.AddTransient<IAuthorSubscription, AuthorSubscription>();
            services.AddTransient<IIllustratorSubscription, IllustratorSubscription>();
            services.AddTransient<IPublisherSubscription, PublisherSubscription>();
            services.AddTransient<IBoardgameSubscription, BoardgameSubscription>();

            return services;
        }


        public static IServiceCollection AddBoardgameShowcaseRepositoryGraphQL(this IServiceCollection services)
        {
            services.AddBoardgameShowcaseRepository();

            services.AddBoardgameShowcaseRepositoryGraphQLSubscriptionsOnly();

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IIllustratorRepository, IllustratorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IBoardgameRepository, BoardgameRepository>();

            return services;
        }
    }
}
