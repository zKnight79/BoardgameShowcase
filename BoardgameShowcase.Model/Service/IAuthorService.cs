using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    public interface IAuthorService : IGenericService<Author>
    {
        Task<IEnumerable<Author>> GetByNameAsync(string namePart);
    }
}
