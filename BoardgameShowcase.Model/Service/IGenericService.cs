using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    /// <summary>
    /// The generic service interface to access an entity.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IGenericService<T> where T : GenericEntity
    {
        /// <summary>
        /// Get all records of the entity.
        /// </summary>
        /// <returns>All records of the entity.</returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Get an entity by providing it's unique ID.
        /// </summary>
        /// <param name="entityId">The unique ID of the wanted entity.</param>
        /// <returns>The entity, if found, <see langword="null"/> otherwise.</returns>
        Task<T?> GetByIdAsync(string entityId);
        /// <summary>
        /// Add a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity. <see langword="null"/> if the entity can't be added.</returns>
        protected Task<T?> AddAsync(T entity);
        /// <summary>
        /// Modify an existing entity.
        /// </summary>
        /// <param name="entity">The entity to modify.</param>
        /// <returns>The modified entity. <see langword="null"/> if the entity can't be modified.</returns>
        protected Task<T?> ModifyAsync(T entity);
        /// <summary>
        /// Save an entity, by adding or modifying it.
        /// </summary>
        /// <param name="entity">The entity to save.</param>
        /// <returns>The saved entity. <see langword="null"/> if the entity can't be saved.</returns>
        Task<T?> SaveAsync(T entity) => entity.IsNew ? AddAsync(entity) : ModifyAsync(entity);
        /// <summary>
        /// Remove an entity by providing it's unique ID.
        /// </summary>
        /// <param name="entityId">The unique ID of the entity to remove.</param>
        /// <returns>The removed entity. <see langword="null"/> if the entity can't be removed.</returns>
        Task<T?> RemoveByIdAsync(string entityId);
        /// <summary>
        /// Remove an entity.
        /// </summary>
        /// <param name="entityId">The entity to remove.</param>
        /// <returns>The removed entity. <see langword="null"/> if the entity can't be removed.</returns>
        Task<T?> RemoveAsync(T entity) => RemoveByIdAsync(entity.Id!);
        /// <summary>
        /// Get an <see cref="IObservable{T}"/> that notifies when an entity is added.
        /// </summary>
        IObservable<T> Added { get; }
        /// <summary>
        /// Get an <see cref="IObservable{T}"/> that notifies when an entity is modified.
        /// </summary>
        IObservable<T> Modified { get; }
        /// <summary>
        /// Get an <see cref="IObservable{T}"/> that notifies when an entity is removed.
        /// </summary>
        IObservable<T> Removed { get; }
    }
}
