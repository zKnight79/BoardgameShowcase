using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    public interface IGenericService<T> where T : GenericEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string entityId);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> SaveAsync(T entity) => entity.IsNew ? AddAsync(entity) : UpdateAsync(entity);
        Task<T> DeleteByIdAsync(string entityId);
        Task<T> DeleteAsync(T entity) => DeleteByIdAsync(entity.Id);
    }
}
