using BoardgameShowcase.Common.Utility;
using BoardgameShowcase.Model.Subscription;
using BoardgameShowcase.Repository.Extensions;
using BoardgameShowcase.Repository.GraphQL.Repository;
using BoardgameShowcase.Repository.GraphQL.Subscription;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BoardgameShowcase.Repository.GraphQL.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Boardgame Showcase GraphQL Repository subscriptions to the dependency injection.
        /// </summary>
        /// <param name="services">The service collection in which to add the subscriptions.</param>
        /// <returns>The provided service collection.</returns>
        public static IServiceCollection AddBoardgameShowcaseRepositoryGraphQLSubscriptionsOnly(this IServiceCollection services)
        {
            services.AddSingleton<IDataAccess, DataAccess>();
            services.RemoveAll<IAuthorSubscription>().AddTransient<IAuthorSubscription, AuthorSubscription>();
            services.RemoveAll<IIllustratorSubscription>().AddTransient<IIllustratorSubscription, IllustratorSubscription>();
            services.RemoveAll<IPublisherSubscription>().AddTransient<IPublisherSubscription, PublisherSubscription>();
            services.RemoveAll<IBoardgameSubscription>().AddTransient<IBoardgameSubscription, BoardgameSubscription>();

            return services;
        }

        /// <summary>
        /// Add Boardgame Showcase GraphQL Repository repositories and subscriptions to the dependency injection.
        /// </summary>
        /// <param name="services">The service collection in which to add the repositories and subscriptions.</param>
        /// <returns>The provided service collection.</returns>
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
