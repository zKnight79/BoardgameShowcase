using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    /// <summary>
    /// The generic repository interface to access an entity.
    /// </summary>
    public interface IGenericRepository<T> where T : GenericEntity
    {
        /// <summary>
        /// Find all records of the entity.
        /// </summary>
        /// <returns>All records of the entity.</returns>
        Task<IEnumerable<T>> FindAllAsync();
        /// <summary>
        /// Find an entity by providing it's unique ID.
        /// </summary>
        /// <param name="entityId">The unique ID of the wanted entity.</param>
        /// <returns>The entity, if found, <see langword="null"/> otherwise.</returns>
        Task<T?> FindByIdAsync(string entityId);
        /// <summary>
        /// Insert a new entity.
        /// </summary>
        /// <param name="entity">The entity to insert.</param>
        /// <returns>The unique ID of the inserted entity. <see langword="null"/> if the entity can't be inserted.</returns>
        Task<string?> InsertAsync(T entity);
        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns><see langword="true"/> if the entity was updated; <see langword="false"/> otherwise.</returns>
        Task<bool> UpdateAsync(T entity);
        /// <summary>
        /// Delete an entity by providing it's unique ID.
        /// </summary>
        /// <param name="entityId">The unique ID of the entity to delete.</param>
        /// <returns><see langword="true"/> if the entity was deleted; <see langword="false"/> otherwise.</returns>
        Task<bool> DeleteByIdAsync(string entityId);
    }
}
