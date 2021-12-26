using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<IEnumerable<Publisher>> FindByNameAsync(string namePart);
    }
}
