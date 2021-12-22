using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.DbRepository.Repository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> FindByNameAsync(string namePart);
    }
}
