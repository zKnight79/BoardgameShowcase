using BoardgameShowcase.Model.Entity.Enumeration;
using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery
    {
        private void AddGetAllBoardgamesQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgames",
                description: "Get all boardgames",
                resolve: context => _boardgameService.GetAllAsync()
            );
        }
        private void AddGetBoardgameByIdQuery()
        {
            Field<BoardgameType>(
                name: "boardgame",
                description: "Get boardgame by ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "id",
                        Description = "The unique ID of the boardgame."
                    }
                },
                resolve: context => _boardgameService.GetByIdAsync(context.GetArgument<string>("id"))
            );
        }
        private void AddGetBoardgameByTitleQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByTitle",
                description: "Get boardgames containing title part",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "titlePart",
                        Description = "A part of the boardgame title."
                    }
                },
                resolve: context => _boardgameService.GetByTitleAsync(context.GetArgument<string>("titlePart"))
            );
        }

        private void AddGetBoardgamesByAuthorIdQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByAuthorId",
                description: "Get boardgames by author ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "authorId",
                        Description = "The unique ID of the author."
                    }
                },
                resolve: context => _boardgameService.GetByAuthorIdAsync(context.GetArgument<string>("authorId"))
            );
        }

        private void AddGetBoardgamesByIllustratorIdQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByIllustratorId",
                description: "Get boardgames by illustrator ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "illustratorId",
                        Description = "The unique ID of the illustrator."
                    }
                },
                resolve: context => _boardgameService.GetByIllustratorIdAsync(context.GetArgument<string>("illustratorId"))
            );
        }

        private void AddGetBoardgamesByPublisherIdQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByPublisherId",
                description: "Get boardgames by publisher ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "publisherId",
                        Description = "The unique ID of the publisher."
                    }
                },
                resolve: context => _boardgameService.GetByPublisherIdAsync(context.GetArgument<string>("publisherId"))
            );
        }

        private void AddGetBoardgamesByCategoryQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByCategory",
                description: "Get boardgames by category",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<EnumerationGraphType<Category>>>()
                    {
                        Name = "category",
                        Description = "The category."
                    }
                },
                resolve: context => _boardgameService.GetByCategoryAsync(context.GetArgument<Category>("category"))
            );
        }

        private void AddGetBoardgamesByThemeQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByTheme",
                description: "Get boardgames by theme",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<EnumerationGraphType<Theme>>>()
                    {
                        Name = "theme",
                        Description = "The theme."
                    }
                },
                resolve: context => _boardgameService.GetByThemeAsync(context.GetArgument<Theme>("theme"))
            );
        }

        private void AddGetBoardgamesByMechanismQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<BoardgameType>>>>(
                name: "boardgamesByMechanism",
                description: "Get boardgames by mechanism",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<EnumerationGraphType<Mechanism>>>()
                    {
                        Name = "mechanism",
                        Description = "The mechanism."
                    }
                },
                resolve: context => _boardgameService.GetByMechanismAsync(context.GetArgument<Mechanism>("mechanism"))
            );
        }
    }
}
