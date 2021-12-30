using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    /// <summary>
    /// The interface for publisher subscriptions.
    /// </summary>
    public interface IPublisherSubscription : IGenericSubscription<Publisher>
    {
    }
}
