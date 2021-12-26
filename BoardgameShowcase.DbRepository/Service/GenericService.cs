using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.Extensions.Logging;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace BoardgameShowcase.DbRepository.Service
{
    abstract class GenericService<T> : Loggable<GenericService<T>>, IGenericService<T> where T : GenericEntity
    {
        private readonly IGenericRepository<T> _genericRepository;
        private readonly ISubject<T> _entityAddedStream = new Subject<T>();
        private readonly ISubject<T> _entityModifiedStream = new Subject<T>();
        private readonly ISubject<T> _entityRemovedStream = new Subject<T>();
        protected GenericService(ILogger<GenericService<T>> logger, IGenericRepository<T> genericRepository)
            : base(logger)
        {
            _genericRepository = genericRepository;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            Logger.LogMethodCall();

            return _genericRepository.FindAllAsync();
        }

        public Task<T?> GetByIdAsync(string entityId)
        {
            Logger.LogMethodCall(entityId);

            return _genericRepository.FindByIdAsync(entityId);
        }

        async Task<T?> IGenericService<T>.AddAsync(T entity)
        {
            Logger.LogMethodCall(entity);

            T? addedEntity = default;

            string? newId = await _genericRepository.InsertAsync(entity);
            if (newId is not null)
            {
                addedEntity = await GetByIdAsync(newId);
                if (addedEntity is not null)
                {
                    _entityAddedStream.OnNext(addedEntity);
                }
            }
            else
            {
                Logger.LogWarning("The entity was not added");
            }

            return addedEntity;
        }

        async Task<T?> IGenericService<T>.ModifyAsync(T entity)
        {
            Logger.LogMethodCall(entity);

            T? updatedEntity = default;

            bool updated = await _genericRepository.UpdateAsync(entity);
            if (updated)
            {
                updatedEntity = await GetByIdAsync(entity.Id ?? string.Empty);
                if(updatedEntity is not null)
                {
                    _entityModifiedStream.OnNext(updatedEntity);
                }
            }
            else
            {
                Logger.LogWarning("The entity was not modified");
            }

            return updatedEntity;
        }

        public async Task<T?> RemoveByIdAsync(string entityId)
        {
            Logger.LogMethodCall(entityId);

            T? removedEntity = default;
            T? toRemove = await GetByIdAsync(entityId);

            if (toRemove is not null && toRemove.Id == entityId)
            {
                bool deleted = await _genericRepository.DeleteByIdAsync(entityId);
                if (deleted)
                {
                    removedEntity = toRemove;
                    _entityRemovedStream.OnNext(removedEntity);
                }
                else
                {
                    Logger.LogWarning("The entity was not removed");
                }
            }

            return removedEntity;
        }

        public IObservable<T> EntityAdded => _entityAddedStream;

        public IObservable<T> EntityModified => _entityModifiedStream;

        public IObservable<T> EntityRemoved => _entityRemovedStream;
    }
}
