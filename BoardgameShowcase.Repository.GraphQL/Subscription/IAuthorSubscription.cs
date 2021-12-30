using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    /// <summary>
    /// The interface for author subscriptions.
    /// </summary>
    public interface IAuthorSubscription : IGenericSubscription<Author>
    {
    }
}