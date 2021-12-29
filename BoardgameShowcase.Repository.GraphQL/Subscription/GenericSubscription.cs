using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    abstract class GenericSubscription<T> : Loggable<GenericSubscription<T>>, IGenericSubscription<T> where T : GenericEntity
    {
        protected IDataAccess DataAccess { get; }

        protected GenericSubscription(ILogger<GenericSubscription<T>> logger, IDataAccess dataAccess)
            : base(logger)
        {
            DataAccess = dataAccess;
        }

        protected abstract string GqlAddedSubscription { get; }
        protected abstract string GqlModifiedSubscription { get; }
        protected abstract string GqlRemovedSubscription { get; }

        protected abstract IDisposable Subscribe(string gqlSubscription, Action<T> action);

        public IDisposable SubscribeAdded(Action<T> action)
        {
            Logger.LogMethodCall();

            return Subscribe(GqlAddedSubscription, action);
        }

        public IDisposable SubscribeModified(Action<T> action)
        {
            Logger.LogMethodCall();

            return Subscribe(GqlModifiedSubscription, action);
        }

        public IDisposable SubscribeRemoved(Action<T> action)
        {
            Logger.LogMethodCall();

            return Subscribe(GqlRemovedSubscription, action);
        }
    }
}
