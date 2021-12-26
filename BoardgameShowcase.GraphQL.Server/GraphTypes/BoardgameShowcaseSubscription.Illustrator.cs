using BoardgameShowcase.Model.Entity;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseSubscription
    {
        private void AddIllustratorAddedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Illustrator)}Added",
                Description = "Fire an event when an illustrator is added",
                Type = typeof(NonNullGraphType<IllustratorType>),
                Resolver = new FuncFieldResolver<Illustrator>(GetEntityFromContext<Illustrator>),
                Subscriber = new EventStreamResolver<Illustrator>(context => _illustratorService.EntityAdded)
            });
        }

        private void AddIllustratorModifiedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Illustrator)}Modified",
                Description = "Fire an event when an illustrator is modified",
                Type = typeof(NonNullGraphType<IllustratorType>),
                Resolver = new FuncFieldResolver<Illustrator>(GetEntityFromContext<Illustrator>),
                Subscriber = new EventStreamResolver<Illustrator>(context => _illustratorService.EntityModified)
            });
        }

        private void AddIllustratorRemovedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Illustrator)}Removed",
                Description = "Fire an event when an illustrator is removed",
                Type = typeof(NonNullGraphType<IllustratorType>),
                Resolver = new FuncFieldResolver<Illustrator>(GetEntityFromContext<Illustrator>),
                Subscriber = new EventStreamResolver<Illustrator>(context => _illustratorService.EntityRemoved)
            });
        }
    }
}
