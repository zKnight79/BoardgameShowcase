using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    /// <summary>
    /// The interface for boardgame subscriptions.
    /// </summary>
    public interface IBoardgameSubscription : IGenericSubscription<Boardgame>
    {
    }
}
