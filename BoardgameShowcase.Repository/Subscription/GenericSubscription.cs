using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Model.Subscription;

namespace BoardgameShowcase.Repository.Subscription
{
    class GenericSubscription<T> : IGenericSubscription<T> where T : GenericEntity
    {
        private readonly IGenericService<T> _genericService;

        public GenericSubscription(IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public IDisposable SubscribeAdded(Action<T> action) => _genericService.Added.Subscribe(action);
        public IDisposable SubscribeModified(Action<T> action) => _genericService.Modified.Subscribe(action);
        public IDisposable SubscribeRemoved(Action<T> action) => _genericService.Removed.Subscribe(action);
    }
}
