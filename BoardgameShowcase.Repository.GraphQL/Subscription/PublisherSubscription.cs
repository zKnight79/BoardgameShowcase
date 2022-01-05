using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Subscription;
using BoardgameShowcase.Repository.GraphQL.Response;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    class PublisherSubscription : GenericSubscription<Publisher>, IPublisherSubscription
    {
        public PublisherSubscription(ILogger<PublisherSubscription> logger, IDataAccess dataAccess)
            : base(logger, dataAccess)
        {
        }

        protected override string GqlAddedSubscription => GQL.PublisherAdded;
        protected override string GqlModifiedSubscription => GQL.PublisherModified;
        protected override string GqlRemovedSubscription => GQL.PublisherRemoved;

        protected override IDisposable Subscribe(string gqlSubscription, Action<Publisher> action)
        {
            return DataAccess.Subscription(gqlSubscription, (PublisherResponse response) =>
            {
                Publisher? publisher = response.Publisher;
                if (publisher is not null)
                {
                    action(publisher);
                }
            });
        }
    }
}
