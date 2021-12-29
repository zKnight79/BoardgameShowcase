using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Response
{
    class AuthorsResponse
    {
        public IEnumerable<Author> Authors { get; set; } = default!;
    }
}
