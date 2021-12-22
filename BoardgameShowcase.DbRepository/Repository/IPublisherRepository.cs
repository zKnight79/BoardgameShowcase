using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.DbRepository.Repository
{
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        Task<IEnumerable<Publisher>> FindByNameAsync(string namePart);
    }
}
