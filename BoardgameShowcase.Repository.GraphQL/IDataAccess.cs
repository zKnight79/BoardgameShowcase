namespace BoardgameShowcase.Repository.GraphQL
{
    interface IDataAccess
    {
        Task<T> Query<T>(string gqlQuery, object? gqlVariables = null);
        Task<T> Mutation<T>(string gqlMutation, object gqlVariables);
        IDisposable Subscription<T>(string gqlSubscription, Action<T> action, object? gqlVariables = null);
    }
}
