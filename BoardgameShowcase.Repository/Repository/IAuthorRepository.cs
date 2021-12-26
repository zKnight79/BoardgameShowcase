using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> FindByNameAsync(string namePart);
    }
}
