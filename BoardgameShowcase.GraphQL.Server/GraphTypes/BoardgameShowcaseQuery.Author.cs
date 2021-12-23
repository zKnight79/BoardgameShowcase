using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery
    {
        private void AddAuthorQueries()
        {
            AddGetAllAuthorsQuery();
        }

        private void AddGetAllAuthorsQuery()
        {
            Field<ListGraphType<AuthorType>>(
                name: "authors",
                description: "Get all authors",
                resolve: context => _authorService.GetAllAsync()
            ); ;
        }
    }
}
