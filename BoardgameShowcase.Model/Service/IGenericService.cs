using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    public interface IGenericService<T> where T : GenericEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(string entityId);
        protected Task<T?> AddAsync(T entity);
        protected Task<T?> ModifyAsync(T entity);
        Task<T?> SaveAsync(T entity) => entity.IsNew ? AddAsync(entity) : ModifyAsync(entity);
        Task<T?> RemoveByIdAsync(string entityId);
        Task<T?> RemoveAsync(T entity) => RemoveByIdAsync(entity.Id!);
        IObservable<T> EntityAdded { get; }
        IObservable<T> EntityModified { get; }
        IObservable<T> EntityRemoved { get; }
    }
}
