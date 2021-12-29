using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Utility;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.InMemory.Repository
{
    class DataAccess<T> : Loggable<DataAccess<T>>, IDataAccess<T> where T : GenericEntity, new()
    {
        private readonly List<T> _entities;

        public DataAccess(ILogger<DataAccess<T>> logger)
            : base(logger)
        {
            string filename = $"data/{typeof(T).Name.ToLower()}s.json";
            _entities = JsonUtil.DeserialiseWithStringEnum<List<T>>(filename, Logger);
        }

        private T CloneEntity(T entity)
        {
            if (entity.Clone() is T clone)
            {
                return clone;
            }
            else
            {
                return new();
            }
        }

        private IEnumerable<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new();
            foreach (T entity in entities)
            {
                clonedEntities.Add(CloneEntity(entity));
            }
            return clonedEntities;
        }

        public IEnumerable<T> QueryEntities(Func<T, bool> predicate)
        {
            IEnumerable<T> entities = _entities.Where(predicate);
            return CloneEntities(entities);
        }

        public T? QueryEntity(Func<T, bool> predicate)
        {
            T? entity = _entities.SingleOrDefault(predicate);
            if (entity is not null)
            {
                entity = CloneEntity(entity);
            }
            return entity;
        }

        public string? AddEntity(T entity)
        {
            T? newEntity = null;
            if (entity.IsNew)
            {
                newEntity = CloneEntity(entity);
                newEntity.Id = StringUtil.NewGuid();
                _entities.Add(newEntity);
            }
            return newEntity?.Id;
        }

        public bool UpdateEntity(T entity)
        {
            bool updated = false;

            if (!entity.IsNew)
            {
                int index = _entities.IndexOf(entity);
                if (index >= 0)
                {
                    _entities[index] = CloneEntity(entity);
                    updated = true;
                }
            }

            return updated;
        }

        public bool DeleteEntity(string entityId)
        {
            return _entities.RemoveAll(e => e.Id == entityId) > 0;
        }
    }
}
