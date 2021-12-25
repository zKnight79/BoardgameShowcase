using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    abstract class GenericRepository<T> : Loggable<GenericRepository<T>>, IGenericRepository<T> where T : GenericEntity
    {
        protected IDataAccess<T> DataAccess { get; }

        protected GenericRepository(ILogger<GenericRepository<T>> logger, IDataAccess<T> dataAccess)
            : base(logger)
        {
            DataAccess = dataAccess;
        }

        public Task<IEnumerable<T>> FindAllAsync()
        {
            Logger.LogMethodCall();

            IEnumerable<T> entities = DataAccess.QueryEntities(e => true);

            return Task.FromResult(entities);
        }

        public Task<T?> FindByIdAsync(string entityId)
        {
            Logger.LogMethodCall(entityId);

            T? entity = DataAccess.QueryEntity(e => e.Id == entityId);

            return Task.FromResult(entity);
        }

        public Task<string?> InsertAsync(T entity)
        {
            Logger.LogMethodCall(entity);

            string? newId = DataAccess.AddEntity(entity);

            return Task.FromResult(newId);
        }

        public Task<bool> UpdateAsync(T entity)
        {
            Logger.LogMethodCall(entity);

            bool updated = DataAccess.UpdateEntity(entity);

            return Task.FromResult(updated);
        }

        public Task<bool> DeleteByIdAsync(string entityId)
        {
            Logger.LogMethodCall(entityId);

            bool deleted = DataAccess.DeleteEntity(entityId);

            return Task.FromResult(deleted);
        }
    }
}
