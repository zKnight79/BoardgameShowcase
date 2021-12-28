using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Repository.Response
{
    class AuthorsResponse
    {
        public IEnumerable<Author> Authors { get; set; } = default!;
    }
}
