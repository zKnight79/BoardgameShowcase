using Microsoft.Extensions.Configuration;

namespace BoardgameShowcase.Repository.GraphQL.Extensions
{
    public static class ConfigurationExtensions
    {
        private const string GRAPHQL_SECTION_NAME = "GraphQL";
        private const string GRAPHQL_ENDPOINT_KEY = $"{GRAPHQL_SECTION_NAME}:Endpoint";

        public static string GetGraphQLEndpoint(this IConfiguration configuration)
        {
            return configuration[GRAPHQL_ENDPOINT_KEY];
        }
    }
}
