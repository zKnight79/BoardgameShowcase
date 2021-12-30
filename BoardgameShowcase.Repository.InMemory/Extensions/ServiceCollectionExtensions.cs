using BoardgameShowcase.Repository.Extensions;
using BoardgameShowcase.Repository.InMemory.Repository;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BoardgameShowcase.Repository.InMemory.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add Boardgame Showcase InMemory Repository repositories to the dependency injection.
        /// </summary>
        /// <param name="services">The service collection in which to add the repositories.</param>
        /// <returns>The provided service collection.</returns>
        public static IServiceCollection AddBoardgameShowcaseRepositoryInMemory(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IDataAccess<>), typeof(DataAccess<>));
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IIllustratorRepository, IllustratorRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<IBoardgameRepository, BoardgameRepository>();

            services.AddBoardgameShowcaseRepository();

            return services;
        }
    }
}
