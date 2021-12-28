using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Repository.Response
{
    class BoardgamesResponse
    {
        public IEnumerable<Boardgame> Boardgames { get; set; } = default!;
    }
}
