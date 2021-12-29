using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Response
{
    class BoardgamesResponse
    {
        public IEnumerable<Boardgame> Boardgames { get; set; } = default!;
    }
}
