using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Response
{
    class PublishersResponse
    {
        public IEnumerable<Publisher> Publishers { get; set; } = default!;
    }
}
