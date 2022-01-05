using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Subscription
{
    /// <summary>
    /// The generic interface for entity subscriptions.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IGenericSubscription<T> where T : GenericEntity
    {
        /// <summary>
        /// Subscribe to execute an action when an entity is added.
        /// </summary>
        /// <param name="action">The action to execute when an entity is added.</param>
        /// <returns>An <see cref="IDisposable"/> to dispose to cancel the subscription.</returns>
        IDisposable SubscribeAdded(Action<T> action);
        /// <summary>
        /// Subscribe to execute an action when an entity is modified.
        /// </summary>
        /// <param name="action">The action to execute when an entity is modified.</param>
        /// <returns>An <see cref="IDisposable"/> to dispose to cancel the subscription.</returns>
        IDisposable SubscribeModified(Action<T> action);
        /// <summary>
        /// Subscribe to execute an action when an entity is removed.
        /// </summary>
        /// <param name="action">The action to execute when an entity is removed.</param>
        /// <returns>An <see cref="IDisposable"/> to dispose to cancel the subscription.</returns>
        IDisposable SubscribeRemoved(Action<T> action);
    }
}