using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.GraphQL.Repository.Response
{
    class PublishersResponse
    {
        public IEnumerable<Publisher> Publishers { get; set; } = default!;
    }
}
