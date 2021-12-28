using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    public interface IGenericSubscription<T> where T : GenericEntity
    {
        IDisposable SubscribeAdded(Action<T> action);
        IDisposable SubscribeModified(Action<T> action);
        IDisposable SubscribeRemoved(Action<T> action);
    }
}