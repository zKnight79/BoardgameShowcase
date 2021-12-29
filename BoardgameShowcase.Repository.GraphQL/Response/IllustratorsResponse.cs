using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Response
{
    class IllustratorsResponse
    {
        public IEnumerable<Illustrator> Illustrators { get; set; } = default!;
    }
}
