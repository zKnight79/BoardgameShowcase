using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    public interface IPublisherService : IGenericService<Publisher>
    {
        Task<IEnumerable<Publisher>> GetByNameAsync(string namePart);
    }
}
