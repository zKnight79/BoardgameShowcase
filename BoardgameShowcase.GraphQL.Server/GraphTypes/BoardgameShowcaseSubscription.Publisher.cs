using BoardgameShowcase.Model.Entity;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseSubscription
    {
        private void AddPublisherAddedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Publisher)}Added",
                Description = "Fire an event when an publisher is added",
                Type = typeof(NonNullGraphType<PublisherType>),
                Resolver = new FuncFieldResolver<Publisher>(GetEntityFromContext<Publisher>),
                Subscriber = new EventStreamResolver<Publisher>(context => _publisherService.Added)
            });
        }

        private void AddPublisherModifiedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Publisher)}Modified",
                Description = "Fire an event when an publisher is modified",
                Type = typeof(NonNullGraphType<PublisherType>),
                Resolver = new FuncFieldResolver<Publisher>(GetEntityFromContext<Publisher>),
                Subscriber = new EventStreamResolver<Publisher>(context => _publisherService.Modified)
            });
        }

        private void AddPublisherRemovedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Publisher)}Removed",
                Description = "Fire an event when an publisher is removed",
                Type = typeof(NonNullGraphType<PublisherType>),
                Resolver = new FuncFieldResolver<Publisher>(GetEntityFromContext<Publisher>),
                Subscriber = new EventStreamResolver<Publisher>(context => _publisherService.Removed)
            });
        }
    }
}
