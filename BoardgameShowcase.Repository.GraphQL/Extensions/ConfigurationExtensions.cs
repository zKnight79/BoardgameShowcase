using Microsoft.Extensions.Configuration;

namespace BoardgameShowcase.Repository.GraphQL.Extensions
{
    /// <summary>
    /// Provides extension methods for <see cref="IConfiguration"/>.
    /// </summary>
    public static class ConfigurationExtensions
    {
        private const string GRAPHQL_SECTION_NAME = "GraphQL";
        private const string GRAPHQL_ENDPOINT_KEY = $"{GRAPHQL_SECTION_NAME}:Endpoint";

        /// <summary>
        /// Get GraphQL server endpoint from configuration.
        /// </summary>
        /// <param name="configuration">The configuration where to get the GraphQL endpoint.</param>
        /// <returns>The configured GraphQL server endpoint.</returns>
        public static string GetGraphQLEndpoint(this IConfiguration configuration)
        {
            return configuration[GRAPHQL_ENDPOINT_KEY];
        }
    }
}
