using BoardgameShowcase.Model.Entity;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseSubscription
    {
        private void AddAuthorAddedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Author)}Added",
                Description = "Fire an event when an author is added",
                Type = typeof(NonNullGraphType<AuthorType>),
                Resolver = new FuncFieldResolver<Author>(GetEntityFromContext<Author>),
                Subscriber = new EventStreamResolver<Author>(context => _authorService.Added)
            });
        }

        private void AddAuthorModifiedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Author)}Modified",
                Description = "Fire an event when an author is modified",
                Type = typeof(NonNullGraphType<AuthorType>),
                Resolver = new FuncFieldResolver<Author>(GetEntityFromContext<Author>),
                Subscriber = new EventStreamResolver<Author>(context => _authorService.Modified)
            });
        }

        private void AddAuthorRemovedSubscription()
        {
            AddField(new EventStreamFieldType()
            {
                Name = $"{nameof(Author)}Removed",
                Description = "Fire an event when an author is removed",
                Type = typeof(NonNullGraphType<AuthorType>),
                Resolver = new FuncFieldResolver<Author>(GetEntityFromContext<Author>),
                Subscriber = new EventStreamResolver<Author>(context => _authorService.Removed)
            });
        }
    }
}
