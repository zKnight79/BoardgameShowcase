using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.GraphQL.Response;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Subscription
{
    class IllustratorSubscription : GenericSubscription<Illustrator>, IIllustratorSubscription
    {
        public IllustratorSubscription(ILogger<IllustratorSubscription> logger, IDataAccess dataAccess)
            : base(logger, dataAccess)
        {
        }

        protected override string GqlAddedSubscription => GQL.IllustratorAdded;
        protected override string GqlModifiedSubscription => GQL.IllustratorModified;
        protected override string GqlRemovedSubscription => GQL.IllustratorRemoved;

        protected override IDisposable Subscribe(string gqlSubscription, Action<Illustrator> action)
        {
            return DataAccess.Subscription(gqlSubscription, (IllustratorResponse response) =>
            {
                Illustrator? illustrator = response.Illustrator;
                if (illustrator is not null)
                {
                    action(illustrator);
                }
            });
        }
    }
}
