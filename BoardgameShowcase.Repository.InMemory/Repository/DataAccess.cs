using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Utility;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace BoardgameShowcase.Repository.InMemory.Repository
{
    class DataAccess<T> : Loggable<DataAccess<T>>, IDataAccess<T> where T : GenericEntity, new()
    {
        private readonly List<T> _entities;

        public DataAccess(ILogger<DataAccess<T>> logger)
            : base(logger)
        {
            string typeName = typeof(T).Name;

            List<T>? entities = null;
            try
            {
                Assembly assembly = GetType().Assembly;
                string resName = $"{assembly.GetName().Name}.data.{typeName.ToLower()}s.json";
                using Stream? stream = assembly.GetManifestResourceStream(resName);
                entities = JsonUtil.DeserializeWithStringEnum<List<T>>(stream, Logger);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"An error occured loading InMemory data for `{typeName}`");
            }

            _entities = entities ?? new();
        }

        private static T CloneEntity(T entity)
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

        private static IEnumerable<T> CloneEntities(IEnumerable<T> entities)
        {
            List<T> clonedEntities = new();
            foreach (T entity in entities)
            {
                clonedEntities.Add(DataAccess<T>.CloneEntity(entity));
            }
            return clonedEntities;
        }

        public IEnumerable<T> QueryEntities(Func<T, bool> predicate)
        {
            IEnumerable<T> entities = _entities.Where(predicate);
            return DataAccess<T>.CloneEntities(entities);
        }

        public T? QueryEntity(Func<T, bool> predicate)
        {
            T? entity = _entities.SingleOrDefault(predicate);
            if (entity is not null)
            {
                entity = DataAccess<T>.CloneEntity(entity);
            }
            return entity;
        }

        public string? AddEntity(T entity)
        {
            T? newEntity = null;
            if (entity.IsNew)
            {
                newEntity = DataAccess<T>.CloneEntity(entity);
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
                    _entities[index] = DataAccess<T>.CloneEntity(entity);
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
