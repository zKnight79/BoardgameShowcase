using BoardgameShowcase.Model.Service;
using GraphQL.Types;

namespace BoardgameShowcase.GraphQL.Server.GraphTypes
{
    public partial class BoardgameShowcaseQuery : ObjectGraphType<object>
    {
        private readonly IAuthorService _authorService;

        public BoardgameShowcaseQuery(IAuthorService authorService)
        {
            Name = nameof(BoardgameShowcaseQuery);
            Description = "Query for Boardgame Showcase";

            _authorService = authorService;

            AddAuthorQueries();
        }
    }
}
