using BoardgameShowcase.Model.Entity;
using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseMutation
    {
        private void AddSaveBoardgameMutation()
        {
            Field<BoardgameType>(
                name: $"save{nameof(Boardgame)}",
                description: "Saves an boardgame",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<BoardgameInputType>>()
                    {
                        Name = "inputBoardgame",
                        Description = "The boardgame to save",
                    }
                },
                resolve: context => _boardgameService.SaveAsync(context.GetArgument<Boardgame>("inputBoardgame"))
            );
        }

        private void AddRemoveBoardgameMutation()
        {
            Field<BoardgameType>(
                name: $"remove{nameof(Boardgame)}",
                description: "Removes an boardgame",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "boardgameId",
                        Description = "The unique ID of the boardgame to remove",
                    }
                },
                resolve: context => _boardgameService.RemoveByIdAsync(context.GetArgument<string>("boardgameId"))
            );
        }
    }
}
