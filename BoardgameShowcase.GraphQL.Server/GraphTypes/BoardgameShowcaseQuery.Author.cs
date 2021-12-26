using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery
    {
        private void AddGetAllAuthorsQuery()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<AuthorType>>>>(
                name: "authors",
                description: "Get all authors",
                resolve: context => _authorService.GetAllAsync()
            );
        }
        private void AddGetAuthorByIdQuery()
        {
            Field<AuthorType>(
                name: "author",
                description: "Get author by ID",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "id",
                        Description = "The unique ID of the author."
                    }
                },
                resolve: context => _authorService.GetByIdAsync(context.GetArgument<string>("id"))
            );
        }
        private void AddGetAuthorByName()
        {
            Field<NonNullGraphType<ListGraphType<NonNullGraphType<AuthorType>>>>(
                name: "authorsByName",
                description: "Get authors containing name part",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "namePart",
                        Description = "A part of the author name."
                    }
                },
                resolve: context => _authorService.GetByNameAsync(context.GetArgument<string>("namePart"))
            );
        }
    }
}
