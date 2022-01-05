using BoardgameShowcase.Model.Entity;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseSubscription
    {
        private void AddBoardgameAddedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Boardgame)}Added",
                Description = "Fire an event when an boardgame is added",
                Type = typeof(NonNullGraphType<BoardgameType>),
                Resolver = new FuncFieldResolver<Boardgame>(GetEntityFromContext<Boardgame>),
                Subscriber = new EventStreamResolver<Boardgame>(context => _boardgameService.Added)
            });
        }

        private void AddBoardgameModifiedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Boardgame)}Modified",
                Description = "Fire an event when an boardgame is modified",
                Type = typeof(NonNullGraphType<BoardgameType>),
                Resolver = new FuncFieldResolver<Boardgame>(GetEntityFromContext<Boardgame>),
                Subscriber = new EventStreamResolver<Boardgame>(context => _boardgameService.Modified)
            });
        }

        private void AddBoardgameRemovedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Boardgame)}Removed",
                Description = "Fire an event when an boardgame is removed",
                Type = typeof(NonNullGraphType<BoardgameType>),
                Resolver = new FuncFieldResolver<Boardgame>(GetEntityFromContext<Boardgame>),
                Subscriber = new EventStreamResolver<Boardgame>(context => _boardgameService.Removed)
            });
        }
    }
}
