using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Common.Utility;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    abstract class GenericRepository<T> : Loggable<GenericRepository<T>>, IGenericRepository<T> where T : GenericEntity
    {
        protected static List<T> Entities { get; private set; } = default!;

        protected GenericRepository(ILogger<GenericRepository<T>> logger)
            : base(logger)
        {
            if (Entities is null)
            {
                string filename = $"data/{typeof(T).Name.ToLower()}s.json";
                Entities = JsonUtil.DeserialiseWithStringEnum<List<T>>(filename);
            }
        }

        protected abstract T CloneEntity(T entity);

        protected IEnumerable<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new();
            foreach (T entity in entities)
            {
                clonedEntities.Add(CloneEntity(entity));
            }
            return clonedEntities;
        }

        public Task<IEnumerable<T>> FindAllAsync()
        {
            Logger.LogMethodCall();

            IEnumerable<T> entities = CloneEntities(Entities);

            return Task.FromResult(entities);
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
