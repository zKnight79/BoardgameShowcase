using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    public interface IDataAccess<T> where T : GenericEntity
    {
        IEnumerable<T> QueryEntities(Func<T, bool> predicate);
        T? QueryEntity(Func<T, bool> predicate);
        string? AddEntity(T entity);
        bool UpdateEntity(T entity);
        bool DeleteEntity(string entityId);
    }
}
