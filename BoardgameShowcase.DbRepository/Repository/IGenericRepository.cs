using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.DbRepository.Repository
{
    public interface IGenericRepository<T> where T : GenericEntity
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T?> FindByIdAsync(string entityId);
        Task<string?> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteByIdAsync(string entityId);
    }
}
