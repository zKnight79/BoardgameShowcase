using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public class IllustratorType : ObjectGraphType<Illustrator>
    {
        public IllustratorType()
        {
            Name = nameof(Illustrator);
            Description = "A boardgame illustrator";

            Field(i => i.Id).Description("The unique identifier of the illustrator");
            Field(i => i.Name).Description("The name of the illustrator");
            Field(
                name: $"{nameof(Boardgame)}s",
                description: "The boardgames of the illustrator",
                type: typeof(NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>),
                resolve: context => context.RequestServices
                                                                 .GetRequiredService<IBoardgameService>()
                                                                 .GetByIllustratorAsync(context.Source)
            );
        }
    }
}
