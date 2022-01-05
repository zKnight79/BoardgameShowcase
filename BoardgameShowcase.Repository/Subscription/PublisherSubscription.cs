using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Model.Subscription;

namespace BoardgameShowcase.Repository.Subscription
{
    class PublisherSubscription : GenericSubscription<Publisher>, IPublisherSubscription
    {
        public PublisherSubscription(IPublisherService publisherService)
            : base(publisherService)
        {
        }
    }
}
