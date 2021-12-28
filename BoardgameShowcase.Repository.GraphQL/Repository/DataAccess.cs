using BoardgameShowcase.Common;
using BoardgameShowcase.Repository.GraphQL.Extensions;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Repository
{
    class DataAccess : Loggable<DataAccess>, IDataAccess
    {
        private readonly IGraphQLClient _graphQLClient;

        public DataAccess(ILogger<DataAccess> logger, IConfiguration configuration)
            : base(logger)
        {
            _graphQLClient = new GraphQLHttpClient(configuration.GetGraphQLEndpoint(), new SystemTextJsonSerializer());
        }

        public async Task<T> Query<T>(string gqlQuery, object? gqlVariables)
        {
            GraphQLRequest graphQLRequest = new()
            {
                Query = gqlQuery,
                Variables = gqlVariables
            };

            try
            {
                GraphQLResponse<T> response = await _graphQLClient.SendQueryAsync<T>(graphQLRequest);
                return response.Data;
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "GraphQL query error !");
                return default!;
            }
        }

        public async Task<T> Mutation<T>(string gqlMutation, object gqlVariables)
        {
            GraphQLRequest graphQLRequest = new()
            {
                Query = gqlMutation,
                Variables = gqlVariables
            };

            try
            {
                GraphQLResponse<T> response = await _graphQLClient.SendMutationAsync<T>(graphQLRequest);
                return response.Data;
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "GraphQL mutation error !");
                return default!;
            }
        }

        public IDisposable Subscription<T>(string gqlSubscription, Action<T> action, object? gqlVariables)
        {
            GraphQLRequest graphQLRequest = new()
            {
                Query = gqlSubscription,
                Variables = gqlVariables
            };

            try
            {
                IObservable<GraphQLResponse<T>> subscriptionStream = _graphQLClient.CreateSubscriptionStream<T>(graphQLRequest);
                return subscriptionStream.Subscribe(response => action(response.Data));
            }
            catch (Exception ex)
            {
                Logger.LogWarning(ex, "GraphQL subscription error !");
                return default!;
            }
        }
    }
}
