using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class PublisherType : ObjectGraphType<Publisher>
    {
        public PublisherType()
        {
            Name = nameof(Publisher);
            Description = "A boardgame publisher";

            Field(p => p.Id).Description("The unique identifier of the publisher");
            Field(p => p.Name).Description("The name of the publisher");
            Field(
                name: $"{nameof(Boardgame)}s",
                description: "The boardgames of the publisher",
                type: typeof(NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>),
                resolve: context => context.RequestServices
                                                                 .GetRequiredService<IBoardgameService>()
                                                                 .GetByPublisherAsync(context.Source)
            );
        }
    }
}
