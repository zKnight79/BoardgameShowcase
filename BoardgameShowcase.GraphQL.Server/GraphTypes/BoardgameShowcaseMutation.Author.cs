using BoardgameShowcase.Model.Entity;
using GraphQL;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseMutation
    {
        private void AddSaveAuthorMutation()
        {
            Field<AuthorType>(
                name: $"save{nameof(Author)}",
                description: "Saves an author",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<AuthorInputType>>()
                    {
                        Name = "inputAuthor",
                        Description = "The author to save",
                    }
                },
                resolve: context => _authorService.SaveAsync(context.GetArgument<Author>("inputAuthor"))
            );
        }

        private void AddRemoveAuthorMutation()
        {
            Field<AuthorType>(
                name: $"remove{nameof(Author)}",
                description: "Removes an author",
                arguments: new()
                {
                    new QueryArgument<NonNullGraphType<StringGraphType>>()
                    {
                        Name = "authorId",
                        Description = "The unique ID of the author to remove",
                    }
                },
                resolve: context => _authorService.RemoveByIdAsync(context.GetArgument<string>("authorId"))
            );
        }
    }
}
