using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    public interface IIllustratorRepository : IGenericRepository<Illustrator>
    {
        Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart);
    }
}
