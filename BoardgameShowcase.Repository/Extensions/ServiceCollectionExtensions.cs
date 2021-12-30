using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Repository.Service;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.Repository.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Boardgame Showcase Model services, based on repositories, to the dependency injection.
        /// </summary>
        /// <param name="services">The service collection in which to add the services implementation.</param>
        /// <returns>The provided service collection.</returns>
        public static IServiceCollection AddBoardgameShowcaseRepository(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddSingleton<IIllustratorService, IllustratorService>();
            services.AddSingleton<IPublisherService, PublisherService>();
            services.AddSingleton<IBoardgameService, BoardgameService>();

            return services;
        }
    }
}
