using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Common.Utility;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    abstract class GenericRepository<T> : Loggable<GenericRepository<T>>, IGenericRepository<T> where T : GenericEntity
    {
        protected static List<T> Entities { get; private set; } = default!;

        protected GenericRepository(ILogger<GenericRepository<T>> logger, IConfiguration configuration)
            : base(logger)
        {
            if (Entities is null)
            {
                string key = $"{typeof(T).Name.ToLower()}-data";
                IEnumerable<T> values = configuration.GetSection(key).Get<IEnumerable<T>>();
                Entities = new(values);
            }
        }

        protected abstract T CloneEntity(T entity);

        public Task<IEnumerable<T>> FindAllAsync()
        {
            Logger.LogMethodCall();

            List<T> entities = new();
            foreach (T entity in Entities)
            {
                entities.Add(CloneEntity(entity));
            }

            return Task.FromResult<IEnumerable<T>>(entities);
        }

        public Task<T?> FindByIdAsync(string entityId)
        {
            Logger.LogMethodCall(entityId);

            T? entity = Entities.FirstOrDefault(x => x.Id == entityId);
            if (entity is not null)
            {
                entity = CloneEntity(entity);
            }

            return Task.FromResult(entity);
        }

        public Task<string?> InsertAsync(T entity)
        {
            Logger.LogMethodCall(entity);

            T? newEntity = null;
            if (entity.IsNew)
            {
                newEntity = CloneEntity(entity);
                newEntity.Id = StringUtil.NewGuid();
                Entities.Add(newEntity);
            }

            return Task.FromResult(newEntity?.Id);
        }

        public Task<bool> UpdateAsync(T entity)
        {
            Logger.LogMethodCall(entity);

            bool updated = false;

            if (!entity.IsNew)
            {
                int index = Entities.IndexOf(entity);
                if (index >= 0)
                {
                    Entities[index] = CloneEntity(entity);
                    updated = true;
                }
            }

            return Task.FromResult(updated);
        }

        public Task<bool> DeleteByIdAsync(string entityId)
        {
            Logger.LogMethodCall(entityId);

            int removeCount = Entities.RemoveAll(e => e.Id == entityId);
            bool deleted = removeCount > 0;

            return Task.FromResult(deleted);
        }
    }
}
