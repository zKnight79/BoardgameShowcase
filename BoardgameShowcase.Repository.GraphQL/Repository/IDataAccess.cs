using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Repository
{
    public interface IDataAccess
    {
        Task<T> Query<T>(string gqlQuery, object? gqlVariables = null);
        Task<T> Mutation<T>(string gqlMutation, object gqlVariables);
    }
}
